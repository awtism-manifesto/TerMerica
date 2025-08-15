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
    public class DracoRound : ModProjectile
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
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 150; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 0;
            Projectile.light = 0.3f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 2; // Set to above 0 if you want the projectile to update multiple time in a frame

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
       

        public override void OnKill(int timeLeft)
        {
           
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            
                Vector2 Peanits = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-150, 150), 940));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(24, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<DracoDrop>(), (int)(Projectile.damage * 1.15f), Projectile.knockBack, Projectile.owner);
                Vector2 Peanit1s = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-150, 150), 960));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanit1s,
                new Vector2(24, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<DracoDrop>(), (int)(Projectile.damage * 1.15f), Projectile.knockBack, Projectile.owner);
                Vector2 Jorkin = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-120, 120), 925));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Jorkin,
                new Vector2(28, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<DracoDrop>(), (int)(Projectile.damage * 1.15f), Projectile.knockBack, Projectile.owner);
                Vector2 Stripped = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-30, 30), 970));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Stripped,
                new Vector2(32, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<DracoDrop>(), (int)(Projectile.damage * 1.15f), Projectile.knockBack, Projectile.owner);
            
        }

    }

}



