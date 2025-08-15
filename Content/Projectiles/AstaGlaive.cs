using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    public class AstaGlaive : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 32; // The width of projectile hitbox
            Projectile.height = 32; // The height of projectile hitbox
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Melee; // Is the projectile shoot by a ranged weapon?
            Projectile.CloneDefaults(ProjectileID.Trimarang);
            AIType = ProjectileID.Trimarang;
            Projectile.penetrate += 4; 
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1;

            Projectile.usesLocalNPCImmunity = true;


        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 3;

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



                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 15, Projectile.height - 15, DustID.CrimsonTorch, 0f, 0f, 100, default, 1.3f);
                    fireDust.fadeIn = 0.1f + Main.rand.Next(1) * 0.1f;
                    fireDust.noGravity = true;
                    fireDust.velocity *= 1.44f;
                }
            }
        }
        
        


    }

}
