using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using gunrightsmod.Content.Buffs;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;

namespace gunrightsmod.Content.Projectiles
{
    public class FerroWhipSpiky : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // This makes the projectile use whip collision detection and allows flasks to be applied to it.
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            Projectile.DefaultToWhip();
            Projectile.WhipSettings.Segments = 36;
            Projectile.WhipSettings.RangeMultiplier = 1.2f;
            Projectile.width = 220;
            Projectile.height = 220;
            // use these to change from the vanilla defaults
            // Projectile.WhipSettings.Segments = 20;
            // Projectile.WhipSettings.RangeMultiplier = 1f;
        }

        private float Timer
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        private float ChargeTime
        {
            get => Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }

        // This example uses PreAI to implement a charging mechanic.
        // If you remove this, also remove Item.channel = true from the item's SetDefaults.
        

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
           
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;

            target.AddBuff(ModContent.BuffType<SpikyTag>(), 310);
            target.AddBuff(BuffID.Oiled, 310);

            Projectile.damage = (int)(Projectile.damage * 0.66f); // Multihit penalty. Decrease the damage the more enemies the whip hits.
        }

       

        public override bool PreDraw(ref Color lightColor)
        {
            List<Vector2> list = new List<Vector2>();
            Projectile.FillWhipControlPoints(Projectile, list);

           

            //Main.DrawWhip_WhipBland(Projectile, list);
            // The code below is for custom drawing.
            // If you don't want that, you can remove it all and instead call one of vanilla's DrawWhip methods, like above.
            // However, you must adhere to how they draw if you do.

            SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Vector2 pos = list[0];

            for (int i = 0; i < list.Count - 1; i++)
            {
                // These two values are set to suit this projectile's sprite, but won't necessarily work for your own.
                // You can change them if they don't!
                Rectangle frame = new Rectangle(0, 0, 14, 18); // The size of the Handle (measured in pixels)
                Vector2 origin = new Vector2(5, 8); // Offset for where the player's hand will start measured from the top left of the image.
                float scale = 1f;

                // These statements determine what part of the spritesheet to draw for the current segment.
                // They can also be changed to suit your sprite.
                if (i == list.Count - 2)
                {
                    // This is the head of the whip. You need to measure the sprite to figure out these values.
                    frame.Y = 1; // Distance from the top of the sprite to the start of the frame.
                    frame.Height = 114; // Height of the frame.

                   
                }
                else if (i > 35)
                {
                    // Third segment
                    frame.Y = 96;
                    frame.Height = 20;
                }
                else if (i > 10)
                {
                    // Third segment
                    frame.Y = 45;
                    frame.Height = 12;
                }
                else if (i > 5)
                {
                    // Second Segment
                    frame.Y = 34;
                    frame.Height = 12;
                }
                else if (i > 0)
                {
                    // First Segment
                    frame.Y = 24;
                    frame.Height = 12;
                }

                Vector2 element = list[i];
                Vector2 diff = list[i + 1] - element;

                float rotation = diff.ToRotation() - MathHelper.PiOver2; // This projectile's sprite faces down, so PiOver2 is used to correct rotation.
                Color color = Lighting.GetColor(element.ToTileCoordinates());

                Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

                pos += diff;
            }
            return false;
        }
    }
}