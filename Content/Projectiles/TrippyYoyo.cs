using gunrightsmod.Content.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    public class TrippyYoyo : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // The following sets are only applicable to yoyo that use aiStyle 99.

            // YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
            // Vanilla values range from 3f (Wood) to 16f (Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 10f;

            // YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
            // Vanilla values range from 130f (Wood) to 400f (Terrarian), and defaults to 200f.
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 235f;

            // YoyosTopSpeed is top speed of the yoyo Projectile.
            // Vanilla values range from 9f (Wood) to 17.5f (Terrarian), and defaults to 10f.
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13.15f;
        }
        private int tickCounter = 0;
        private int nextSpawnTick = 0;

        public override void AI()
        {
           
                // Only run on the server
                if (nextSpawnTick == 0)
                {
                    nextSpawnTick = Main.rand.Next(24, 26);
                }

                tickCounter++;

                if (tickCounter >= nextSpawnTick)
                {
                    Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
                    Vector2 Peanits = Projectile.Center - new Vector2(-5, 5);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                        ModContent.ProjectileType<BoomShroom>(), (int)(Projectile.damage * 1.05f), Projectile.knockBack, Projectile.owner);

                    tickCounter = 0;
                    nextSpawnTick = Main.rand.Next(24, 26);

                    // Optionally: flag to sync the projectile state
                    Projectile.netUpdate = true;
                }
            

            // dust code (visual only, fine to run on all clients)
            if (Projectile.alpha < 187)
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
                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 6, Projectile.height - 6, ModContent.DustType<LycopiteDust>(), 0f, 0f, 100, default, 0.2f);
                    chudDust.fadeIn = 0.1f + Main.rand.Next(2) * 0.1f;
                    chudDust.velocity *= 0.25f;
                }
            }
        }

        public override void SetDefaults()
        {
            Projectile.width = 16; // The width of the projectile's hitbox.
            Projectile.height = 16; // The height of the projectile's hitbox.
            Projectile.light = 0.5f;
            Projectile.aiStyle = ProjAIStyleID.Yoyo; // The projectile's ai style. Yoyos use aiStyle 99 (ProjAIStyleID.Yoyo). A lot of yoyo code checks for this aiStyle to work properly.
            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true; // Player shot projectile. Does damage to enemies but not to friendly Town NPCs.
            Projectile.DamageType = DamageClass.MeleeNoSpeed; // Benefits from melee bonuses. MeleeNoSpeed means the item will not scale with attack speed.
            Projectile.penetrate = -1; // All vanilla yoyos have infinite penetration. The number of enemies the yoyo can hit before being pulled back in is based on YoyosLifeTimeMultiplier.
                                       // Projectile.scale = 1f; // The scale of the projectile. Most yoyos are 1f, but a few are larger. The Kraken is the largest at 1.2f
        }
    }
}