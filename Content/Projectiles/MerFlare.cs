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
    public class MerFlare : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }

        public override void SetDefaults()
        {
            Projectile.width = 8; // The width of projectile hitbox
            Projectile.height = 8; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 250; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
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
            

            
                Vector2 Peanits = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 510));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
            new Vector2(16, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), (int)(Projectile.damage * 0.95f), Projectile.knockBack);
            Vector2 Im = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 600));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Im,
            new Vector2(20, 0).RotatedBy((Im).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 So = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 690));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), So,
            new Vector2(26, 0).RotatedBy((So).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Fucking = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 780));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Fucking,
            new Vector2(18, 0).RotatedBy((Fucking).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Bad = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 870));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Bad,
            new Vector2(25, 0).RotatedBy((Bad).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 At = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 960));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), At,
            new Vector2(48, 0).RotatedBy((At).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Coding = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 1050));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Coding,
            new Vector2(42, 0).RotatedBy((Coding).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Codinng = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 1140));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Codinng,
            new Vector2(23, 0).RotatedBy((Codinng).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Cooding = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 1230));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Cooding,
            new Vector2(39, 0).RotatedBy((Cooding).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Codingg = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15 ), 1320));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Codingg,
            new Vector2(32, 0).RotatedBy((Codingg).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Codiing = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 1410));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Codiing,
            new Vector2(37, 0).RotatedBy((Codiing).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Codiiing = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 1500));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Codiiing,
            new Vector2(51, 0).RotatedBy((Codiiing).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Vector2 Fuckking = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-15, 15), 1590));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Fuckking,
            new Vector2(20, 0).RotatedBy((Fuckking).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Vector2 ImAFuckingDegenerate = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-5, 5), 1680));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Fuckking,
                new Vector2(20, 0).RotatedBy((Fuckking).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<MinieMag>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            



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
                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.DungeonSpirit, 0f, 0f, 100, default, 0.55f);
                    chudDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    chudDust.velocity *= 0.05f;
                    Dust fireeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.GemSapphire, 0f, 0f, 100, default, 0.25f);
                    fireeDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireeDust.velocity *= 0.05f;
                    Dust fireeeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.Wraith, 0f, 0f, 100, default, 0.25f);
                    fireeeDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireeeDust.velocity *= 0.05f;
                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.GemRuby, 0f, 0f, 100, default, 0.25f);
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
        }

    }

}



