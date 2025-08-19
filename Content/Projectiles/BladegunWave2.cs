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
    public class BladegunWave2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            

            Projectile.width = 35; // The width of projectile hitbox
            Projectile.height = 35; // The height of projectile hitbox

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
           

        }
       
        public override void OnKill(int timeLeft)
        {

            
           




        }
    }
}