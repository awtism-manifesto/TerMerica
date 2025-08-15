using gunrightsmod.Content.Buffs;
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
    public class OilBallRanged : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 15; // The width of projectile hitbox
            Projectile.height = 15; // The height of projectile hitbox
            Projectile.scale = 1.75f;
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 300; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.15f; // How much light emit around the projectile
            Projectile.ignoreWater = false; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame
           
            Projectile.aiStyle = 1;
            AIType = ProjectileID.Bullet;

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
          
            target.AddBuff(BuffID.Oiled, 240);
           
        }
        public override void AI()
        {
            int frameSpeed = 6;

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
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 17f)
            {
                Projectile.ai[0] = 17f;
                Projectile.velocity.Y += 0.1925f;
            }

            // The projectile is rotated to face the direction of travel
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Cap downward velocity
            if (Projectile.velocity.Y > 17f)
            {
                Projectile.velocity.Y = 17f;
            }


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
                    Dust fire2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.BlueFairy, 0f, 0f, 100, default, 0.4f);
                    fire2Dust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                    fire2Dust.velocity *= 0.15f;
                    fire2Dust.noGravity = true;
                    Dust fire22Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.PinkFairy, 0f, 0f, 100, default, 0.4f);
                    fire22Dust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                    fire22Dust.velocity *= 0.15f;
                    fire22Dust.noGravity = true;
                    Dust fire222Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.GreenFairy, 0f, 0f, 100, default, 0.4f);
                    fire222Dust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                    fire222Dust.velocity *= 0.15f;
                    fire222Dust.noGravity = true;

                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.Wraith, 0f, 0f, 100, default, 0.95f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                    fireDust.velocity *= 0.15f;
                    fireDust.noGravity = true;
                }
            }
        }

       
       
        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
        private void Visuals()
        {
            Projectile.rotation = Projectile.velocity.X * 0.05f;

            // This is a simple "loop through all frames from top to bottom" animation
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
        }
    }
}
    

