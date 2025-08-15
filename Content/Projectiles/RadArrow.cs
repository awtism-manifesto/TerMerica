using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    // This example is similar to the Wooden Arrow projectile
    public class RadArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // If this arrow would have strong effects (like Holy Arrow pierce), we can make it fire fewer projectiles from Daedalus Stormbow for game balance considerations like this:
            //ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 12; // The width of projectile hitbox
            Projectile.height = 12; // The height of projectile hitbox
            
            Projectile.arrow = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 35;
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
                Projectile.velocity.Y += 0.15f;
            }

            // The projectile is rotated to face the direction of travel
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Cap downward velocity
            if (Projectile.velocity.Y > 13f)
            {
                Projectile.velocity.Y = 19f;
            }
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



                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 8, Projectile.height - 8, DustID.CursedTorch, 0f, 0f, 100, default, 0.25f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireDust.velocity *= 0.05f;
                }
            }
        }
       
        public override void OnKill(int timeLeft)
        {
            
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(9, 9).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<RadArrowMini>(), Projectile.damage = (int)(Projectile.damage * 0.65f), Projectile.knockBack, Projectile.owner);
                Vector2 JorkinMy = Projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), JorkinMy,
                new Vector2(-9, 9).RotatedBy((JorkinMy).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<RadArrowMini>(), Projectile.damage = (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
                Vector2 InDaClerb = Projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), InDaClerb,
                new Vector2(9, -9).RotatedBy((InDaClerb).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<RadArrowMini>(), Projectile.damage = (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
                Vector2 UwU = Projectile.Center - new Vector2(Main.rand.Next(-1, 1), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), UwU,
                new Vector2(-9, -9).RotatedBy((UwU).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<RadArrowMini>(), Projectile.damage = (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);

            
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position); // Plays the basic sound most projectiles make when hitting blocks.
            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
                dust.noGravity = true;
                dust.velocity *= 5.5f;
                dust.scale *= 2f;
            }
        }
    }
}