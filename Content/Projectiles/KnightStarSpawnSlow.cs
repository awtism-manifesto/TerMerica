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
    public class KnightStarSpawnSlow : ModProjectile
    {
        
        public override void SetDefaults()
        {
            

            Projectile.width = 12; // The width of projectile hitbox
            Projectile.height = 12; // The height of projectile hitbox

           
            Projectile.timeLeft = 59;
            Projectile.aiStyle = -1;
           
            Projectile.alpha = 0;
            Projectile.tileCollide = false;
            Projectile.friendly = true; 
            Projectile.DamageType = ModContent.GetInstance<OmniDamage>();
            Projectile.penetrate = 3; 
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            AIType = ProjectileID.Bullet; // Act exactly like default Bullet

        }

        public override void AI()
        {
            Projectile.scale = Main.rand.NextFloat(0.66f, 1.25f);

           
            
        }
       
        public override void OnKill(int timeLeft)
        {

            
           




        }
    }
}