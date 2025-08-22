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
    public class BladegunWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            

            Projectile.width = 32; // The width of projectile hitbox
            Projectile.height = 32; // The height of projectile hitbox

            Projectile.scale = 1.66f;
            Projectile.timeLeft = 250;
            Projectile.aiStyle = 1;
            AIType = ProjectileID.Bullet;
           
            Projectile.tileCollide = true;
            Projectile.friendly = true; 
            Projectile.DamageType = ModContent.GetInstance<MeleeRangedDamage>();
            Projectile.penetrate = 5; 
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.alpha = 255;

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
           
            Projectile.damage = (int)(Projectile.damage * 0.8f); 
        }
        private int tickCounter = 0;
        private int nextSpawnTick = 0;
        public override void AI()
        {
            Projectile.scale = Main.rand.NextFloat(0.66f, 0.8f);

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
            if (Projectile.timeLeft < 245)
            {
                Projectile.alpha = 190;
            }
            if (Projectile.timeLeft < 230)
            {
                Projectile.alpha = 130;
            }
            if (Projectile.timeLeft < 220)
            {
                Projectile.alpha = 75;
            }
            if (Projectile.timeLeft < 210)
            {
                Projectile.alpha = 35;
            }
            if (Projectile.timeLeft > 195)
            {

                if (nextSpawnTick == 0)
                {
                    nextSpawnTick = Main.rand.Next(18, 22);
                }

                tickCounter++;

                if (tickCounter >= nextSpawnTick)
                {
                    Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(0));
                    Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.Next(-35, 35));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                        ModContent.ProjectileType<BladegunWave2>(), (int)(Projectile.damage * 0.75f), Projectile.knockBack, Projectile.owner);

                    tickCounter = 0;
                    nextSpawnTick = Main.rand.Next(18, 22);


                    Projectile.netUpdate = true;
                }
            }

        }
       
        public override void OnKill(int timeLeft)
        {

            
           




        }
    }
}