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
    public class EmblemProj2 : ModProjectile
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

            Projectile.width = 24; // The width of projectile hitbox
            Projectile.height = 24; // The height of projectile hitbox

            // To further the Cloning process, we can also copy the ai of any given projectile using AIType, since we want
            // the projectile to essentially behave the same way as the vanilla projectile.
            AIType = ProjectileID.ChlorophyteBullet;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 1;
            Projectile.alpha = 0;
            Projectile.tileCollide = true;
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = ModContent.GetInstance<OmniDamage>();
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            // After CloneDefaults has been called, we can now modify the stats to our wishes, or keep them as they are.
            // For the sake of example, lets make our projectile penetrate enemies a few more times than the vanilla projectile.
            // This can be done by modifying projectile.penetrate

        }

        public override void AI()
        {


            int frameSpeed = 5;

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
                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 24, Projectile.height - 24, DustID.CrimsonTorch, 0f, 0f, 100, default, 1.15f);
                    chudDust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                    chudDust.velocity *= 0.25f;
                    Dust fireeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 24, Projectile.height - 24, DustID.PurpleTorch, 0f, 0f, 100, default, 1.16f);
                    fireeDust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                    fireeDust.velocity *= 0.25f;
                    Dust firee2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 24, Projectile.height - 24, DustID.CursedTorch, 0f, 0f, 100, default, 1.15f);
                    firee2Dust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                    firee2Dust.velocity *= 0.25f;

                }
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<EmblemTag>(), 390);
            target.immune[Projectile.owner] = 2;
        }
        public override void OnKill(int timeLeft)
        {
           
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.Next(-1, 1), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(1, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<EmblemBoom>(), (int)(Projectile.damage* 1.1f), Projectile.knockBack, Projectile.owner);
                Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.Next(-1, 1), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(1, 0).RotatedBy((Peanits2).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<GalaxyProj2>(), (int)(Projectile.damage * 0.49f), Projectile.knockBack, Projectile.owner);
                Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.Next(-1, 1), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(1, 0).RotatedBy((Peanits3).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<GalaxyProj2>(), (int)(Projectile.damage * 0.999f), Projectile.knockBack, Projectile.owner);
            
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            
        }
    }
}