﻿using gunrightsmod.Content.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    public class ShroomiteMissileProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
           
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; // Damage dealt to players does not scale with difficulty in vanilla.

            // This set handles some things for us already:
            // Sets the timeLeft to 3 and the projectile direction when colliding with an NPC or player in PVP (so the explosive can detonate).
            // Explosives also bounce off the top of Shimmer, detonate with no blast damage when touching the bottom or sides of Shimmer, and damage other players in For the Worthy worlds.
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;

            // This set makes it so the rocket doesn't deal damage to players. Only used for vanilla rockets.
            // Simply remove the Projectile.HurtPlayer() part to stop the projectile from damaging its user.
            // ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.penetrate = -1; // Infinite penetration so that the blast can hit all enemies within its radius.
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.light = 0.33f; // How much light emit around the projectile
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.scale = 0.8f;
            // Rockets use explosive AI, ProjAIStyleID.Explosive (16). You could use that instead here with the correct AIType.
            // But, using our own AI allows us to customize things like the dusts that the rocket creates.
            // Projectile.aiStyle = ProjAIStyleID.Explosive;
            // AIType = ProjectileID.RocketI;
        }
        public override void AI()
        {
            // If timeLeft is <= 3, then explode the rocket.
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                // Spawn dusts if the rocket is moving at or greater than half of its max speed.
                if (Math.Abs(Projectile.velocity.X) >= 8f || Math.Abs(Projectile.velocity.Y) >= 8f)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        float posOffsetX = 0f;
                        float posOffsetY = 0f;
                        if (i == 1)
                        {
                            posOffsetX = Projectile.velocity.X * 0.5f;
                            posOffsetY = Projectile.velocity.Y * 0.5f;
                        }



                        // Used by the liquid rockets which leave trails of their liquid instead of fire.
                        // if (fireDust.type == Dust.dustWater()) {
                        //	fireDust.scale *= 0.65f;
                        //	fireDust.velocity += Projectile.velocity * 0.1f;
                        // }

                        // Spawn smoke dusts at the back of the rocket.
                        Dust smokeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f, Projectile.width - 22, Projectile.height - 22, DustID.BlueTorch, 0f, 0f, 100, default, 1.25f);
                        smokeDust.fadeIn = 0.2f + Main.rand.Next(5) * 0.1f;
                        smokeDust.velocity *= 0.55f;
                        smokeDust.noGravity = true;
                    }
                }

                // Increase the speed of the rocket if it is moving less than 1 block per second.
                // It is not recommended to increase the number past 16f to increase the speed of the rocket. It could start no clipping through blocks.
                // Instead, increase extraUpdates in SetDefaults() to make the rocket move faster.
                if (Math.Abs(Projectile.velocity.X) <= 15f && Math.Abs(Projectile.velocity.Y) <= 15f)
                {
                    Projectile.velocity *= 1.1f;
                }
            }

            // Rotate the rocket in the direction that it is moving.
            if (Projectile.velocity != Vector2.Zero)
            {
                Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.PiOver2;
            }
        }

        // When the rocket hits a tile, NPC, or player, get ready to explode.
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity *= 0f; // Stop moving so the explosion is where the rocket was.
            Projectile.timeLeft = 3; // Set the timeLeft to 3 so it can get ready to explode.
            return false; // Returning false is important here. Otherwise the projectile will die without being resized (no blast radius).
        }

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false; // This is important or the explosion will be in the wrong place if the rocket explodes on slopes.
            Projectile.alpha = 255; // Make the rocket invisible.

            // Resize the hitbox of the projectile for the blast "radius".
            // Rocket I: 128, Rocket III: 200, Mini Nuke Rocket: 250
            // Measurements are in pixels, so 128 / 16 = 8 tiles.
            Projectile.Resize(216, 216);
            // Set the knockback of the blast.
            // Rocket I: 8f, Rocket III: 10f, Mini Nuke Rocket: 12f
            Projectile.knockBack = 9f;
        }

        public override void OnKill(int timeLeft)
        {
            // Vanilla code takes care ensuring that in For the Worthy or Get Fixed Boi worlds the blast can damage other players because
            // this projectile is ProjectileID.Sets.Explosive[Type] = true;. It also takes care of hurting the owner. The Projectile.PrepareBombToBlow
            // and Projectile.HurtPlayer methods can be used directly if needed for a projectile not using ProjectileID.Sets.Explosive
            Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(-136, 136), Main.rand.NextFloat(-136, 136));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<ShroomBoom>(), (int)(Projectile.damage * 0.67f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
            Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(-136, 136), Main.rand.NextFloat(-136, 136));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<ShroomBoom>(), (int)(Projectile.damage * 0.67f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));
            Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(-136, 136), Main.rand.NextFloat(-136, 136));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                ModContent.ProjectileType<ShroomBoom>(), (int)(Projectile.damage * 0.67f), Projectile.knockBack, Projectile.owner);
            // Play an exploding sound.
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            // Resize the projectile again so the explosion dust and gore spawn from the middle.
            // Rocket I: 22, Rocket III: 80, Mini Nuke Rocket: 50
            Projectile.Resize(156, 156);

            // Spawn a bunch of smoke dusts.
            for (int i = 0; i < 20; i++)
            {
                Dust smokeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                smokeDust.velocity *= 1.4f;
                Dust smoke2Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<BlueLycopiteDust>(), 0f, 0f, 100, default, 1.1f);
                smoke2Dust.velocity *= 5f;
            }

            // Spawn a bunch of fire dusts.
            for (int j = 0; j < 35; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 3.65f);
                fireDust.noGravity = true;
                fireDust.velocity *= 7f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 1.75f);
                fireDust.velocity *= 3f;
            }

           
        }
       

        // Rocket II explosion that damages tiles.
        //if (Projectile.owner == Main.myPlayer) {
        //	int blastRadius = 3; // Rocket IV: 5, Mini Nuke Rocket II: 7

        //	int minTileX = (int)(Projectile.Center.X / 16f - blastRadius);
        //	int maxTileX = (int)(Projectile.Center.X / 16f + blastRadius);
        //	int minTileY = (int)(Projectile.Center.Y / 16f - blastRadius);
        //	int maxTileY = (int)(Projectile.Center.Y / 16f + blastRadius);

        // Make sure the tiles are inside the world.
        // Utils.ClampWithinWorld(ref minTileX, ref maxTileX, ref minTileY, ref maxTileY);

        // Check to see if the walls should be destroyed, too.
        //	bool wallSplode = Projectile.ShouldWallExplode(Projectile.position, blastRadius, minTileX, maxTileX, minTileY, maxTileY);
        // Do the damage.
        //	Projectile.ExplodeTiles(Projectile.position, blastRadius, minTileX, maxTileX, minTileY, maxTileY, wallSplode);
        //}
    }
}
