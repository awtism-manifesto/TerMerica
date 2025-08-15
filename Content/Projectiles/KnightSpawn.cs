using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Projectiles
{
    public class KnightSpawn : ModProjectile
    {
        

        public override void SetDefaults()
        {
            Projectile.width = 1; // The width of projectile hitbox
            Projectile.height = 1; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 1; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
            Projectile.light = 0f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }

       
       
       
       

        public override void OnKill(int timeLeft)
        {
            


                Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
                Vector2 Peanits = Projectile.Center - new Vector2(66, 66);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<KnightSwordDown>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);

            Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
            Vector2 Peanits3 = Projectile.Center - new Vector2(-66, 66);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                ModContent.ProjectileType<KnightSwordDown>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);

            Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
                Vector2 Peanits2 = Projectile.Center - new Vector2(-66, -66);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<KnightSwordUp>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);

            Vector2 velocity24 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
            Vector2 Peanits24 = Projectile.Center - new Vector2(66, -66);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits24, velocity24,
            ModContent.ProjectileType<KnightSwordUp>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);

        }

    }

}



