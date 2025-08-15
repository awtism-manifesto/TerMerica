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
    public class CiaSpawn : ModProjectile
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
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 1; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
            Projectile.light = 0f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
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
            


                Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<CiaShot2>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
                Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<CiaShot3>(), (int)(Projectile.damage * 0.33f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
            Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
            ModContent.ProjectileType<CiaShot>(), (int)(Projectile.damage * 0.67f), Projectile.knockBack, Projectile.owner);



            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            
        }

    }

}



