using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.DamageClasses;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    /// <summary>
    /// This the class that clones the vanilla Meowmere projectile using CloneDefaults().
    /// Make sure to check out <see cref="ExampleCloneWeapon" />, which fires this projectile; it itself is a cloned version of the Meowmere.
    /// </summary>
    public class Tomato : ModProjectile
    {
        public override void SetStaticDefaults()
        {
           
            Main.projFrames[Projectile.type] = 4;
           
        }
        public override void SetDefaults()
        {
            // This method right here is the backbone of what we're doing here; by using this method, we copy all of
            // the Meowmere Projectile's SetDefault stats (such as projectile.friendly and projectile.penetrate) on to our projectile,
            // so we don't have to go into the source and copy the stats ourselves. It saves a lot of time and looks much cleaner;
            // if you're going to copy the stats of a projectile, use CloneDefaults().

            Projectile.width = 19; // The width of projectile hitbox
            Projectile.height = 19; // The height of projectile hitbox

            // To further the Cloning process, we can also copy the ai of any given projectile using AIType, since we want
            // the projectile to essentially behave the same way as the vanilla projectile.
            AIType = ProjectileID.WoodenArrowFriendly;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 1;
            Projectile.alpha = 0;
            Projectile.tileCollide = true;
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = ModContent.GetInstance<StupidDamage>();
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            // After CloneDefaults has been called, we can now modify the stats to our wishes, or keep them as they are.
            // For the sake of example, lets make our projectile penetrate enemies a few more times than the vanilla projectile.
            // This can be done by modifying projectile.penetrate

        }

        public override void AI()
        {


            int frameSpeed = 9;

            Projectile.frameCounter++;

            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;


                }
            }
            // dust, all dust
            if (Math.Abs(Projectile.velocity.X) >= 4f || Math.Abs(Projectile.velocity.Y) >= 4f)
            {
                for (int i = 0; i < 2; i++)
                {
                    float posOffsetX = 0f;
                    float posOffsetY = 0f;
                    if (i == 1)
                    {
                        posOffsetX = Projectile.velocity.X * 2.5f;
                        posOffsetY = Projectile.velocity.Y * 2.5f;
                    }
                   
                    Dust firee2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 24, Projectile.height - 24, DustID.Water_Crimson, 0f, 0f, 100, default, 0.75f);
                    firee2Dust.fadeIn = 0.1f + Main.rand.Next(4) * 0.1f;
                    firee2Dust.velocity *= 0.25f;

                }
            }
        }
       
        public override void OnKill(int timeLeft)
        {

            for (int i = 0; i < 6; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Water_BloodMoon);
                dust.noGravity = true;
                dust.velocity *= 9.95f;
                dust.scale *= 1.25f;
            }


        }
    }
}