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
    public class HammerNSickle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // If this arrow would have strong effects (like Holy Arrow pierce), we can make it fire fewer projectiles from Daedalus Stormbow for game balance considerations like this:
            //ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 18; // The width of projectile hitbox
            Projectile.height = 18; // The height of projectile hitbox
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 1;
            Projectile.friendly = true;
            Projectile.penetrate += 2;
            Projectile.CloneDefaults(ProjectileID.Shuriken);
            Projectile.usesLocalNPCImmunity = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 300;
            AIType = ProjectileID.Shuriken;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 5;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {


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
        
        public override void AI()
        {
            // The code below was adapted from the ProjAIStyleID.Arrow behavior. Rather than copy an existing aiStyle using Projectile.aiStyle and AIType,
            // like some examples do, this example has custom AI code that is better suited for modifying directly.
            // See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#what-is-ai for more information on custom projectile AI.
            


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



                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 8, Projectile.height - 8, DustID.CrimsonTorch, 0f, 0f, 100, default, 0.22f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                    fireDust.velocity *= 0.05f;
                }
            }
        }
       
        public override void OnKill(int timeLeft)
        {
            


           
            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Silver);
                dust.noGravity = true;
                dust.velocity *= 1.5f;
                dust.scale *= 0.9f;
            }
        }
    }
}