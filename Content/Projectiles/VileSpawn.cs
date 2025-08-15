using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Projectiles
{
    public class VileSpawn : ModProjectile
    {
        

        public override void SetDefaults()
        {
            Projectile.width = 1; // The width of projectile hitbox
            Projectile.height = 1; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = false; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 1; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
            Projectile.light = 0f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (Main.rand.NextBool(2))
            { Projectile.velocity.X = (Main.rand.NextFloat(0.66f, 1.5f)); }
            else
            { Projectile.velocity.X = (Main.rand.NextFloat(-1.5f, -0.66f)); }
        }




        public override void OnKill(int timeLeft)
        {
           
            Projectile.velocity.Y = -33.5f;

            Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(25f));
                Vector2 Peanits = Projectile.Center - new Vector2(0, -120);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ProjectileID.VilethornBase, (int)(Projectile.damage * 1.1f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(25f));
            Vector2 Peanits2 = Projectile.Center - new Vector2(120, -120);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ProjectileID.VilethornBase, (int)(Projectile.damage * 1.1f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(25f));
            Vector2 Peanits3 = Projectile.Center - new Vector2(-120, -120);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                ProjectileID.VilethornBase, (int)(Projectile.damage * 1.1f), Projectile.knockBack, Projectile.owner);


        }

    }

}



