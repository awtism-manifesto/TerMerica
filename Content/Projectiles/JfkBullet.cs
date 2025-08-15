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
    public class JfkBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }

        public override void SetDefaults()
        {
            Projectile.width = 13; // The width of projectile hitbox
            Projectile.height = 13; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 250; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
            Projectile.light = 0.4f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 25; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            
                
                    
                    Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(0));
                    Vector2 Peanits = Projectile.Center - new Vector2(70, 20);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<JfkBlood>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity2 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(72));
                Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(-70, 20));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<JfkBlood>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity3 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(144));
                Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 80));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                ModContent.ProjectileType<JfkBlood>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity4 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(216));
                Vector2 Peanits4 = Projectile.Center - new Vector2(-60, -60);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
                ModContent.ProjectileType<JfkBlood>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity5 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(288));
                Vector2 Peanits5 = Projectile.Center - new Vector2(60, -60);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits5, velocity5,
                ModContent.ProjectileType<JfkBlood>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            

            for (int i = 0; i < 20; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
                dust.noGravity = true;
                dust.velocity *= 11.5f;
                dust.scale *= 2f;
            }



        }
        public override void AI()
        {

            

                // dust, all dust
                if (Math.Abs(Projectile.velocity.X) >= 4f || Math.Abs(Projectile.velocity.Y) >= 4f)
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
                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.GemSapphire, 0f, 0f, 100, default, 0.75f);
                    chudDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    chudDust.velocity *= 0.05f;
                    Dust kms = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.GemDiamond, 0f, 0f, 100, default, 0.75f);
                    kms.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    kms.velocity *= 0.05f;

                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.GemRuby, 0f, 0f, 100, default, 0.75f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireDust.velocity *= 0.25f;
                }
            }
        }

        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }

    }

}



