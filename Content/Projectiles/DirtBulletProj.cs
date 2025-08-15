using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    // This example is similar to the Wooden Arrow projectile
    public class DirtBulletProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // If this arrow would have strong effects (like Holy Arrow pierce), we can make it fire fewer projectiles from Daedalus Stormbow for game balance considerations like this:
            //ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 5; // The width of projectile hitbox
            Projectile.height = 5; // The height of projectile hitbox
            Projectile.extraUpdates = 1;
            Projectile.scale = 1.2f;
          
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 250;
           
        }

        public override void AI()
        {
            // The code below was adapted from the ProjAIStyleID.Arrow behavior. Rather than copy an existing aiStyle using Projectile.aiStyle and AIType,
            // like some examples do, this example has custom AI code that is better suited for modifying directly.
            // See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#what-is-ai for more information on custom projectile AI.

            // Apply gravity after a quarter of a second
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 13f)
            {
                Projectile.ai[0] = 8f;
                Projectile.velocity.Y += 0.18f;
            }

            Projectile.rotation += 0.25f;

            // Cap downward velocity
            if (Projectile.velocity.Y > 18f)
            {
                Projectile.velocity.Y = 19f;
            }
           
               

                    Dust fire2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 0f , Projectile.position.Y + 0f ) - Projectile.velocity * 0.1f, Projectile.width - 2, Projectile.height - 2, DustID.Dirt, 0f, 0f, 100, default, 0.75f);
                    fire2Dust.fadeIn = 0.1f + Main.rand.Next(3) * 0.1f;
                    fire2Dust.velocity *= 0.15f;
                   
                
            
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int j = 0; j < 3; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt, 0f, 0f, 100, default, 1f);
                fireDust.noGravity = true;
                fireDust.velocity *= 5f;
               
            }
        }
       
    }
}