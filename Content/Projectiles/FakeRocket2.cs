using gunrightsmod.Content.DamageClasses;
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
    public class FakeRocket2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7; // The length of old position to be recorded
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
            Projectile.timeLeft = 1; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
            Projectile.light = 1f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 3; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
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
                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.IceTorch, 0f, 0f, 100, default, 0.55f);
                    chudDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    chudDust.velocity *= 0.05f;


                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.Torch, 0f, 0f, 100, default, 0.25f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireDust.velocity *= 0.05f;
                }
            }
        }

        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            
                Vector2 Peanits = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-188,188), 1050));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(36, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<UsaFlag2>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Vector2 Peanits2 = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-188, 188), 1050));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2,
                new Vector2(42, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<UsaFlag2>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            
        }
        }

    }



