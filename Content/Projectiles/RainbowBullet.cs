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
    public class RainbowBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }

        public override void SetDefaults()
        {
            Projectile.width = 15; // The width of projectile hitbox
            Projectile.height = 15; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 250; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255;
            Projectile.light = 0.4f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 4; // Set to above 0 if you want the projectile to update multiple time in a frame

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
            
                
            


        }
        public override void AI()
        {



            // dust, all dust
             if (Projectile.alpha < 190)
            {
                for (int i = 0; i < 2; i++)
                {
                    float posOffsetX = 0f;
                    float posOffsetY = 0f;
                    if (i == 1)
                    {
                        posOffsetX = Projectile.velocity.X * 2.75f;
                        posOffsetY = Projectile.velocity.Y * 2.75f;
                    }
                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.RedTorch, 0f, 0f, 100, default, 1.15f);
                    chudDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    chudDust.velocity *= 0.64f;
                    chudDust.noGravity = true;
                    Dust kms = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.YellowTorch, 0f, 0f, 100, default, 1.15f);
                    kms.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    kms.velocity *= 0.64f;
                    kms.noGravity = true;
                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.OrangeTorch, 0f, 0f, 100, default, 1.15f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireDust.velocity *= 0.64f;
                    fireDust.noGravity = true;
                    Dust fire2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.GreenTorch, 0f, 0f, 100, default, 1.15f);
                    fire2Dust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fire2Dust.velocity *= 0.64f;
                    fire2Dust.noGravity = true;
                    Dust fire3Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.BlueTorch, 0f, 0f, 100, default, 1.15f);
                    fire3Dust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fire3Dust.velocity *= 0.64f;
                    fire3Dust.noGravity = true;
                    Dust fire4Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.PurpleTorch, 0f, 0f, 100, default, 1.15f);
                    fire4Dust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fire4Dust.velocity *= 0.64f;
                    fire4Dust.noGravity = true;
                    Dust fire5Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.PinkTorch, 0f, 0f, 100, default, 1.15f);
                    fire5Dust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fire5Dust.velocity *= 0.64f;
                    fire5Dust.noGravity = true;
                    Dust fire6Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 16, Projectile.height - 16, DustID.CoralTorch, 0f, 0f, 100, default, 1.15f);
                    fire6Dust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fire6Dust.velocity *= 0.64f;
                    fire6Dust.noGravity = true;
                }
            }
        }

        public override void OnKill(int timeLeft)
        {

            Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<RainbowShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            if (Main.rand.NextBool(2))
            {
                Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
                Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<RainbowShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            }
            if (Main.rand.NextBool(3))
            {
                Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
                Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                ModContent.ProjectileType<RainbowShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            }
            if (Main.rand.NextBool(5))
            {
                Vector2 velocity4 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
                Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
                ModContent.ProjectileType<RainbowShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            }


            for (int i = 0; i < 3; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch);
                dust.noGravity = true;
                dust.velocity *= 11.5f;
                dust.scale *= 1.66f;
                Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
                dust2.noGravity = true;
                dust2.velocity *= 11.5f;
                dust2.scale *= 1.66f;
                Dust dust3 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
                dust3.noGravity = true;
                dust3.velocity *= 11.5f;
                dust3.scale *= 1.66f;
                Dust dust4 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch);
                dust4.noGravity = true;
                dust4.velocity *= 11.5f;
                dust4.scale *= 1.66f;
                Dust dust5 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch);
                dust5.noGravity = true;
                dust5.velocity *= 11.5f;
                dust5.scale *= 1.66f;
                Dust dust6 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch);
                dust6.noGravity = true;
                dust6.velocity *= 11.5f;
                dust6.scale *= 1.66f;
                Dust dust7 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkTorch);
                dust7.noGravity = true;
                dust7.velocity *= 11.5f;
                dust7.scale *= 1.66f;
            }

        }

    }

}



