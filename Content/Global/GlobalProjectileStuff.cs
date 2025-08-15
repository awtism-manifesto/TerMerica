using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Global
{
    public class CrystalBeef : GlobalProjectile
    {
        public bool fromGoldenAK;

        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {

            if (fromGoldenAK)
            {

                projectile.scale = 1.66f;


            }
        }
    }
    public class FastBow : GlobalProjectile
    {
        public bool fromCompoundBow;

        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {

            if (fromCompoundBow)
            {

                projectile.extraUpdates = 1;


            }
        }
    }
    public class FastBees : GlobalProjectile
    {
        public bool fromBeeSniper;

        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {

            if (fromBeeSniper)
            {

                projectile.extraUpdates = 3;


            }
        }
    }
    public class RedneckCombo : GlobalProjectile
    {
        public bool fromRedneckGun;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!fromRedneckGun)
                return; // Don't run if this isn't a right-click combo shot

            if (target.HasBuff(ModContent.BuffType<RedneckTag>()))
            {
                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.TrueNightsEdge,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  projectile.owner);
                SoundEngine.PlaySound(SoundID.Item37, projectile.position);

            }

        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromRedneckGun && target.HasBuff(ModContent.BuffType<RedneckTag>()))
            {
                modifiers.SourceDamage *= 1.5f;
            }
        }

    }
    public class VPCombo : GlobalProjectile
    {
        public bool fromVP70;

        public override bool InstancePerEntity => true;
        public override void AI(Projectile projectile)
        {
            if (fromVP70)
            {

                projectile.extraUpdates = 4;


            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!fromVP70)
                return; // Don't run if this isn't a right-click combo shot

            if (target.HasBuff(ModContent.BuffType<VpTag>()))
            {
                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  projectile.owner);

                SoundEngine.PlaySound(SoundID.Item37, projectile.position);
            }

        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromVP70 && target.HasBuff(ModContent.BuffType<VpTag>()))
            {
                modifiers.SourceDamage *= 1.66f;
            }
        }

    }
    public class VPCombo2 : GlobalProjectile
    {
        public bool fromVP702;

        public override bool InstancePerEntity => true;
        public override void AI(Projectile projectile)
        {
            if (fromVP702)
            {

                projectile.extraUpdates = 3;


            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!fromVP702)
                return; // Don't run if this isn't a right-click combo shot

            if (target.HasBuff(ModContent.BuffType<VpTag>()))
            {
                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  projectile.owner);

                SoundEngine.PlaySound(SoundID.Item37, projectile.position);
            }

        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromVP702 && target.HasBuff(ModContent.BuffType<VpTag>()))
            {
                modifiers.SourceDamage *= 1.66f;
            }
        }

    }
    public class VPCombo3 : GlobalProjectile
    {
        public bool fromVP703;

        public override bool InstancePerEntity => true;
        public override void AI(Projectile projectile)
        {
            if (fromVP703)
            {

                projectile.extraUpdates = 2;


            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!fromVP703)
                return; // Don't run if this isn't a right-click combo shot

            if (target.HasBuff(ModContent.BuffType<VpTag>()))
            {
                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  projectile.owner);

                SoundEngine.PlaySound(SoundID.Item37, projectile.position);
            }

        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromVP703 && target.HasBuff(ModContent.BuffType<VpTag>()))
            {
                modifiers.SourceDamage *= 1.66f;
            }
        }

    }
    public class VPComboSetup : GlobalProjectile
    {
        public bool fromtheVP70;

        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {
            if (fromtheVP70)
            {

                projectile.extraUpdates = 3;


            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {



            if (!fromtheVP70)
                return; // Only apply buff if this is a left-click setup shot

            target.AddBuff(ModContent.BuffType<VpTag>(), 37);




        }
    }
    public class KnightComboSetup : GlobalProjectile
    {
        public bool fromtheBlackshard;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {



            if (!fromtheBlackshard)
                return; // Only apply buff if this is a left-click setup shot

            target.AddBuff(ModContent.BuffType<BlackshardDebuff>(), 196);




        }
    }


    public class DeliriantComboSetup : GlobalProjectile
    {
        public bool fromtheDeliriantDagger;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {



            if (!fromtheDeliriantDagger)
                return; // Only apply buff if this is a left-click setup shot


          

                target.AddBuff(ModContent.BuffType<DeliriantTag>(), 155);

            


        }
    }


    public class VerdantComboSetup : GlobalProjectile
    {
        public bool fromtheVerdantClaymore;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {



            if (!fromtheVerdantClaymore)
                return; // Only apply buff if this is a left-click setup shot

            target.AddBuff(ModContent.BuffType<VerdantTag>(), 125);




        }
    }


    public class VerdantCombo : GlobalProjectile
    {
        public bool fromVerdantClaymore;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!fromVerdantClaymore)
                return; // Don't run if this isn't a right-click combo shot

            if (target.HasBuff(ModContent.BuffType<VerdantTag>()))
            {
                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.TrueNightsEdge,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  projectile.owner);

                // Apply a buff to the player
                Player player = Main.player[projectile.owner];
                player.AddBuff(ModContent.BuffType<JungleHealing>(), 100); // 300 = 5 seconds (60 ticks per second)

            }




        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromVerdantClaymore && target.HasBuff(ModContent.BuffType<VerdantTag>()))
            {
                modifiers.SourceDamage *= 1.85f;
            }
        }







    }
}