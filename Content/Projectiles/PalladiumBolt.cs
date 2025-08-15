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
    public class PalladiumBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
           
        }

        public override void SetDefaults()
        {
            Projectile.width = 13; // The width of projectile hitbox
            Projectile.height = 13; // The height of projectile hitbox
           
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Melee; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 130; 
                                   
            Projectile.light = 0.3f;
            Projectile.ignoreWater = false; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame
            Projectile.usesLocalNPCImmunity = true;
            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
        }

        public override void AI()
        {

            if (Projectile.alpha <180)
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


                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 11, Projectile.height - 11, DustID.OrangeTorch, 0f, 0f, 100, default, 2f);
                    fireDust.fadeIn = 0.2f + Main.rand.Next(6) * 0.1f;
                    fireDust.noGravity = true;
                    fireDust.velocity *= 0.05f;
                    Dust fire2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 11, Projectile.height - 11, DustID.Palladium, 0f, 0f, 100, default, 2f);
                    fire2Dust.fadeIn = 0.2f + Main.rand.Next(6) * 0.1f;
                    fire2Dust.noGravity = true;
                    fire2Dust.velocity *= 0.05f;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
           
            target.immune[Projectile.owner] = 6;
           
        }
        
        
    }
}
    

