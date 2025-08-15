using gunrightsmod.Content.DamageClasses;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    // This example is similar to the Wooden Arrow projectile
    public class SaltGrav : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 6; // The width of projectile hitbox
            Projectile.height = 6; // The height of projectile hitbox
            
            Projectile.arrow = true;
            Projectile.friendly = true;
            Projectile.DamageType =  ModContent.GetInstance<StupidDamage>();
            Projectile.timeLeft = 66;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            // The code below was adapted from the ProjAIStyleID.Arrow behavior. Rather than copy an existing aiStyle using Projectile.aiStyle and AIType,
            // like some examples do, this example has custom AI code that is better suited for modifying directly.
            // See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#what-is-ai for more information on custom projectile AI.

            
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 18f)
            {
                Projectile.ai[0] = 17f;
                Projectile.velocity.Y += 0.08f;
            }

            // The projectile is rotated to face the direction of travel
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Cap downward velocity
            if (Projectile.velocity.Y > 5f)
            {
                Projectile.velocity.Y = 6f;
            }
            // dust
           
        }
        
        public override void OnKill(int timeLeft)
        {
             // Plays the basic sound most projectiles make when hitting blocks.
            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Silver);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            }
        }
    }
}