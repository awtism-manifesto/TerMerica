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
    // This example is similar to the Wooden Arrow projectile
    public class RadShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // If this arrow would have strong effects (like Holy Arrow pierce), we can make it fire fewer projectiles from Daedalus Stormbow for game balance considerations like this:
            //ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 12; // The width of projectile hitbox
            Projectile.height = 12; // The height of projectile hitbox
            AIType = ProjectileID.Bullet;
            Projectile.extraUpdates = 2;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 31;
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

            Projectile.damage = (int)(Projectile.damage * 0.525f);

        }
        public override void AI()
        {
           
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



                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 8, Projectile.height - 8, DustID.CursedTorch, 0f, 0f, 100, default, 0.1f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireDust.velocity *= 0.05f;
                }
            }
        }
       
        public override void OnKill(int timeLeft)
        {
            
                for (int i = -1; i <= 1; i++)
                {
                    float angle = 11 * i; // gives -15, 0, 15
                    Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(11));
                    Vector2 Peanits = Projectile.Center - new Vector2(0,0);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<RadShotMini>(), (int)(Projectile.damage * 0.455f), Projectile.knockBack, Projectile.owner);
                }
                
            
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position); // Plays the basic sound most projectiles make when hitting blocks.
            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
                dust.noGravity = true;
                dust.velocity *= 5.5f;
                dust.scale *= 2f;
            }
        }
    }
}