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
    public class Xray : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
           
        }

        public override void SetDefaults()
        {
            Projectile.width = 5; // The width of projectile hitbox
            Projectile.height = 5; // The height of projectile hitbox
           
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 2; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 63; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
            Projectile.ignoreWater = false; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = false; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 7; // Set to above 0 if you want the projectile to update multiple time in a frame
            Projectile.usesLocalNPCImmunity = true;
            
        }

        public override void AI()
        {

            if (Projectile.alpha < 169)
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



                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 4, Projectile.height - 4, DustID.PurpleTorch, 0f, 0f, 100, default, 0.95f);
                    fireDust.fadeIn = 0.1f + Main.rand.Next(1) * 0.1f;
                    fireDust.noGravity = true;
                    fireDust.velocity *= 1.25f;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            
            target.immune[Projectile.owner] = 6;
            
        }
        
        
    }
}
    

