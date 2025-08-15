using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Projectiles
{
    public class RedneckShovelHallow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            target.AddBuff(ModContent.BuffType<RedneckTag>(), 136);


        }
        public override void AI()
        {
            Projectile.rotation += 0.225f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 19f)
            {
                Projectile.ai[0] = 19f;
                Projectile.velocity.Y += 0.2f;
            }
            if (Projectile.velocity.Y > 18f)
            {
                Projectile.velocity.Y = 20f;
            }
        }
    }
}