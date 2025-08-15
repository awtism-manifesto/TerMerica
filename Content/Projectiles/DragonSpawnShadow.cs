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
    public class DragonSpawnShadow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }

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

            AIType = ProjectileID.WoodenArrowFriendly; // Act exactly like default Bullet
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // If collide with tile, reduce the penetrate.
            // So the projectile can reflect at most 5 times
            Projectile.penetrate--;
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

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;

            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
       
       

        public override void OnKill(int timeLeft)
        {
           


                Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<DragonBreathShadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<DragonBreathShadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);

                Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                ModContent.ProjectileType<DragonBreathShadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity4 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
                ModContent.ProjectileType<DragonBreathShadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity5 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits5 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits5, velocity5,
                ModContent.ProjectileType<DragonBreath2Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity6 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits6 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits6, velocity6,
                ModContent.ProjectileType<DragonBreath2Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity7 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits7 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits7, velocity7,
                ModContent.ProjectileType<DragonBreath2Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity8 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits8 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits8, velocity8,
                ModContent.ProjectileType<DragonBreath2Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity9 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits9 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits9, velocity9,
                ModContent.ProjectileType<DragonBreath3Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity10 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits10 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits10, velocity10,
                ModContent.ProjectileType<DragonBreath3Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity11 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits11 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits11, velocity11,
                ModContent.ProjectileType<DragonBreath3Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity12 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits12 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits12, velocity12,
                ModContent.ProjectileType<DragonBreath4Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity13 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits13 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits13, velocity13,
                ModContent.ProjectileType<DragonBreath4Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity14 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits14 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits14, velocity14,
                ModContent.ProjectileType<DragonBreath4Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity15 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits15 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits15, velocity15,
                ModContent.ProjectileType<DragonBreath4Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity16 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12));
                Vector2 Peanits16 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits16, velocity16,
                ModContent.ProjectileType<DragonBreath3Shadow>(), (int)(Projectile.damage * 0.375f), Projectile.knockBack, Projectile.owner);

            
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }

    }

}



