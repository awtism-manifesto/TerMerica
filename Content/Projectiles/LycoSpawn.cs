using gunrightsmod.Content.Dusts;
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
    public class LycoSpawn : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }

        public override void SetDefaults()
        {
            Projectile.width = 10; // The width of projectile hitbox
            Projectile.height = 10; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 2; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255;
            Projectile.light = 0.4f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }

        public override void OnKill(int timeLeft)
        {

            Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.05f));
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.05f));
            Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));


            if (Main.rand.NextBool(5))
            {

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<LycoSporeRanged>(), (int)(Projectile.damage * 1.33f), Projectile.knockBack, Projectile.owner);
            }
            else
            {


                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<LycoShot>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
            }


        }



        
        public override void AI()
        {

            

                // dust, all dust
                if (Projectile.alpha <188)
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

                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, ModContent.DustType<LycopiteDust>(), 0f, 0f, 100, default, 0.55f);
                    chudDust.fadeIn = 0.1f + Main.rand.Next(5) * 0.1f;
                    chudDust.velocity *= 0.1f;
                }
            }
        }

       

    }

}



