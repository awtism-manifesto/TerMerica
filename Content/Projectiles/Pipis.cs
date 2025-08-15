using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;



namespace gunrightsmod.Content.Projectiles
{
    public class Pipis : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<OmniDamage>();
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {


            Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(0));
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity2 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(40));
            Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity3 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(80));
            Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity4 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(120));
            Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity5 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(160));
            Vector2 Peanits5 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits5, velocity5,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity6 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(200));
            Vector2 Peanits6 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits6, velocity6,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity7 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(240));
            Vector2 Peanits7 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits7, velocity7,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity8 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(280));
            Vector2 Peanits8 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits8, velocity8,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity9 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(320));
            Vector2 Peanits9 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits9, velocity9,
            ModContent.ProjectileType<SpamtonHead>(), (int)(Projectile.damage * 0.25f), Projectile.knockBack, Projectile.owner);

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

            Projectile.rotation += 0.275f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 21f)
            {
                Projectile.ai[0] = 21f;
                Projectile.velocity.Y += 0.1775f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
    }
}