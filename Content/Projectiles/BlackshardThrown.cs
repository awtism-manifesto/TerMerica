using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Projectiles
{
    public class BlackshardThrown : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 2;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<BlackshardDebuff>(), 296);
          
        }
        public override void AI()
        {
            Projectile.rotation += 0.66f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 19f)
            {
                Projectile.ai[0] = 19f;
                Projectile.velocity.Y += 0.15f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
    }
}