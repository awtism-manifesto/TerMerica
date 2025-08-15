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
    public class FidgetSpinner2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            Main.projFrames[Projectile.type] = 4;

        }
        public override void SetDefaults()
        {
            Projectile.width = 20; // The width of projectile hitbox
            Projectile.height = 20; // The height of projectile hitbox
            Projectile.aiStyle = -1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = ModContent.GetInstance<StupidDamage>(); // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 7; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 325; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.scale = 1.15f;
            Projectile.light = 0.25f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {


            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

                // If the projectile hits the left or right side of the tile, reverse the X velocity
                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }

                // If the projectile hits the top or bottom side of the tile, reverse the Y velocity
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }

            return false;
        }
        public override void AI()
        {

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 17f)
            {
                Projectile.ai[0] = 17f;
                Projectile.velocity.Y += 0.13f;
            }

            // The projectile is rotated to face the direction of travel
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Cap downward velocity
            if (Projectile.velocity.Y > 17f)
            {
                Projectile.velocity.Y = 17f;
            }

            int frameSpeed = 7;

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
            
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(9))
            {

                target.AddBuff(BuffID.Poisoned, 240);
            }
            if (Main.rand.NextBool(9))
            {

                target.AddBuff(BuffID.OnFire, 240);
            }
            if (Main.rand.NextBool(9))
            {

                target.AddBuff(BuffID.Confused, 240);
            }


            if (Main.rand.NextBool(6))
            {

                target.AddBuff(BuffID.Oiled, 240);
            }
            if (Main.rand.NextBool(6))
            {

                target.AddBuff(BuffID.Frostburn2, 240);
            }
            if (Main.rand.NextBool(6))
            {

                target.AddBuff(BuffID.ShadowFlame, 240);
            }

        }
        
    }
}