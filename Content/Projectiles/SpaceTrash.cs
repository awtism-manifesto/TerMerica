using gunrightsmod.Content.Items;
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
    public class SpaceTrash : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 55; // The width of projectile hitbox
            Projectile.height = 55; // The height of projectile hitbox
            Projectile.aiStyle = -1;
            Projectile.extraUpdates = 1;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.scale = 0.99f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 25;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 195;
           
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
          
            target.AddBuff(BuffID.OnFire, 300);
          
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

            int frameSpeed = 5;

            Projectile.frameCounter++;

            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;


                }
            }



            if (Projectile.timeLeft <= 115)

            Projectile.ai[0] += 8.5f;
            if (Projectile.ai[0] >= 8.5f)
            {
                Projectile.ai[0] = 8.5f;
                Projectile.velocity.Y += 1.05f;
            }

            // The projectile is rotated to face the direction of travel
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Cap downward velocity
            if (Projectile.velocity.Y > 47f)
            {
                Projectile.velocity.Y = 47f;
            }

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



                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 60, Projectile.height - 60, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                    fireDust.fadeIn = 0.1f + Main.rand.Next(5) * 0.1f;
                    fireDust.velocity *= 2f;
                }
            }
        }
       
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DeerclopsRubbleAttack, Projectile.position);



            for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Iron);
                dust.noGravity = true;
                dust.velocity *= 5.5f;
                dust.scale *= 1.5f;
                Dust dusty = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
                dusty.noGravity = true;
                dusty.velocity *= 3.5f;
                dusty.scale *= 1.1f;
            }
        }
    }
}