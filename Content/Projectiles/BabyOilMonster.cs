using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gunrightsmod.Content.Projectiles
{
    public class BabyOilMonster : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            

            Main.projFrames[Projectile.type] = 15;
            Main.projPet[Projectile.type] = true;

            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (Main.rand.NextBool(5))
            {

                target.AddBuff(BuffID.Oiled, 240);
            }

            if (target.HasBuff(BuffID.Oiled))
            {
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.Next(-1, 1), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(1, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<OilBoomSmall>(), (int)(Projectile.damage * 1.25f), Projectile.knockBack, Projectile.owner);

            }

        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.PirateCaptain);
            AIType = ProjectileID.PirateCaptain;

            Projectile.netImportant = true;
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.timeLeft = 13000;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1f;
            Projectile.DamageType = DamageClass.Summon;

            Projectile.penetrate = -1;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!CheckActive(owner))
            {
                return;
            }
        }

        public override void PostAI()
        {
            foreach (var gore in Main.gore)
            {
                if (gore != null)
                {
                    if (gore.type == 580 || gore.type == 581 || gore.type == 582)
                    {
                        gore.active = false;
                    }
                }
            }
        }

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<OilMonsterBuff>());

                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<OilMonsterBuff>()))
            {
                Projectile.timeLeft = 3;
            }

            return true;
        }
    }
}