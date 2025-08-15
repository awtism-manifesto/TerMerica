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
    public class VaxNeedle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // If this arrow would have strong effects (like Holy Arrow pierce), we can make it fire fewer projectiles from Daedalus Stormbow for game balance considerations like this:
            //ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 8; // The width of projectile hitbox
            Projectile.height = 8; // The height of projectile hitbox
            Projectile.usesLocalNPCImmunity = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 30;
            Projectile.arrow = true;
            Projectile.extraUpdates = 2;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<StupidDamage>();
            Projectile.timeLeft = 200;
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
                Projectile.velocity.Y += 0.19f;
            }

           
           
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Cap downward velocity
            if (Projectile.velocity.Y > 13f)
            {
                Projectile.velocity.Y = 19f;
            }
            for (int i = 0; i < 2; i++)
            {
                float posOffsetX = 0f;
                float posOffsetY = 0f;
                if (i == 1)
                {
                    posOffsetX = Projectile.velocity.X * 2.5f;
                    posOffsetY = Projectile.velocity.Y * 2.5f;
                }



                Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 5, Projectile.height - 5, DustID.Blood, 0f, 0f, 100, default, 0.85f);
                fireDust.fadeIn = 0.1f + Main.rand.Next(4) * 0.1f;
                fireDust.velocity *= 0.25f;
                Dust fire2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 5, Projectile.height - 5, DustID.GemRuby, 0f, 0f, 100, default, 0.5f);
                fire2Dust.fadeIn = 0.1f + Main.rand.Next(4) * 0.1f;
                fire2Dust.velocity *= 0.115f;
            }

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Venom, 250);

            Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits = Projectile.Center - new Vector2(-50, 50);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
            ModContent.ProjectileType<VaxNanobot>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits2 = Projectile.Center - new Vector2(-50, 50);

            Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits3 = Projectile.Center - new Vector2(-50, 50);

            Vector2 velocity4 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits4 = Projectile.Center - new Vector2(-50, 50);

            Vector2 velocity5 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits5 = Projectile.Center - new Vector2(-50, 50);



            if (Main.rand.NextBool(3))
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
           ModContent.ProjectileType<VaxNanobot>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);

            }

            if (Main.rand.NextBool(3))
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
            ModContent.ProjectileType<VaxNanobot>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);

            }


            if (Main.rand.NextBool(3))
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
           ModContent.ProjectileType<VaxNanobot>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);

            }

            if (Main.rand.NextBool(3))
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits5, velocity5,
           ModContent.ProjectileType<VaxNanobot>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);

            }


        }
        public override void OnKill(int timeLeft)
        {
           
                
                   
                   


           
            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            }
        }
    }
}