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
    public class KnightStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
           
            Main.projFrames[Projectile.type] = 2;
           
        }
        public override void SetDefaults()
        {
            

            Projectile.width = 50; // The width of projectile hitbox
            Projectile.height = 50; // The height of projectile hitbox

           
            Projectile.timeLeft = 48;
            Projectile.aiStyle = -1;
         
            Projectile.alpha = 0;
            Projectile.tileCollide = false;
            Projectile.friendly = true; 
            Projectile.DamageType = ModContent.GetInstance<OmniDamage>();
            Projectile.penetrate = 6969; 
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void AI()
        {
            Projectile.alpha = Main.rand.Next(55,225);

            if (Projectile.timeLeft < 13)
            {
                Projectile.velocity *= 0.88f;

            }

            int frameSpeed = 33;

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
       
        public override void OnKill(int timeLeft)
        {

            Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(0));
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
            ModContent.ProjectileType<KnightStarSpawn>(), (int)(Projectile.damage * 0.45f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity2 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(60));
            Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
            ModContent.ProjectileType<KnightStarSpawnSlow>(), (int)(Projectile.damage * 0.45f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity3 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(120));
            Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
            ModContent.ProjectileType<KnightStarSpawn>(), (int)(Projectile.damage * 0.45f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity4 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(180));
            Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
            ModContent.ProjectileType<KnightStarSpawnSlow>(), (int)(Projectile.damage * 0.45f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity5 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(240));
            Vector2 Peanits5 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits5, velocity5,
            ModContent.ProjectileType<KnightStarSpawn>(), (int)(Projectile.damage * 0.45f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity6 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(300));
            Vector2 Peanits6 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits6, velocity6,
            ModContent.ProjectileType<KnightStarSpawnSlow>(), (int)(Projectile.damage * 0.45f), Projectile.knockBack, Projectile.owner);
           




        }
    }
}