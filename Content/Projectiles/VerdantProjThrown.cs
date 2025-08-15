using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using Terraria.Audio;


namespace gunrightsmod.Content.Projectiles
{
    public class VerdantProjThrown : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 35;
            Projectile.height = 35;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
           
            target.AddBuff(BuffID.Poisoned, 120);
           

        }
        public override void AI()
        {

            if (Projectile.timeLeft < 589)
            {
                
                Projectile.Resize(60, 60);
            }

            Projectile.rotation += 0.21f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 28f)
            {
                Projectile.ai[0] = 28f;
                Projectile.velocity.Y += 0.225f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }
    }
}