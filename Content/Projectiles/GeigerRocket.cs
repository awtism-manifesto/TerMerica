using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    public class GeigerRocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsARocketThatDealsDoubleDamageToPrimaryEnemy[Type] = true; // Deals double damage on direct hits.
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; // Damage dealt to players does not scale with difficulty in vanilla.
            ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;
            // This set handles some things for us already:
            // Sets the timeLeft to 3 and the projectile direction when colliding with an NPC or player in PVP (so the explosive can detonate).
            // Explosives also bounce off the top of Shimmer, detonate with no blast damage when touching the bottom or sides of Shimmer, and damage other players in For the Worthy worlds.
            ProjectileID.Sets.Explosive[Type] = true;

            // This set makes it so the rocket doesn't deal damage to players. Only used for vanilla rockets.
            // Simply remove the Projectile.HurtPlayer() part to stop the projectile from damaging its user.
            // ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.penetrate = -1; // Infinite penetration so that the blast can hit all enemies within its radius.
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.light = 1f; // How much light emit around the projectile
            Projectile.usesLocalNPCImmunity = true;
            Projectile.extraUpdates = 0;

            // Rockets use explosive AI, ProjAIStyleID.Explosive (16). You could use that instead here with the correct AIType.
            // But, using our own AI allows us to customize things like the dusts that the rocket creates.
            // Projectile.aiStyle = ProjAIStyleID.Explosive;
            // AIType = ProjectileID.RocketI;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 15;
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
                        Dust smokeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.CursedTorch, 0f, 0f, 100, default, 0.7f);
                        smokeDust.fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                        smokeDust.velocity *= 0.05f;
                        Dust smokeyDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.CrimsonTorch, 0f, 0f, 100, default, 0.7f);
                        smokeyDust.fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                        smokeyDust.velocity *= 0.05f;
                        Dust smokeyeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.PurpleTorch, 0f, 0f, 100, default, 0.8f);
                        smokeyeDust.fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                        smokeyeDust.velocity *= 0.05f;
                    }
                }

                // Increase the speed of the rocket if it is moving less than 1 block per second.
                // It is not recommended to increase the number past 16f to increase the speed of the rocket. It could start no clipping through blocks.
                // Instead, increase extraUpdates in SetDefaults() to make the rocket move faster.
                if (Math.Abs(Projectile.velocity.X) <= 38f && Math.Abs(Projectile.velocity.Y) <= 38f)
                {
                    Projectile.velocity *= 1.225f;
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
            Projectile.Resize(600, 600);
            // Set the knockback of the blast.
            // Rocket I: 8f, Rocket III: 10f, Mini Nuke Rocket: 12f
            Projectile.knockBack = 16f;
        }

        public override void OnKill(int timeLeft)
        {
            // Vanilla code takes care ensuring that in For the Worthy or Get Fixed Boi worlds the blast can damage other players because
            // this projectile is ProjectileID.Sets.Explosive[Type] = true;. It also takes care of hurting the owner. The Projectile.PrepareBombToBlow
            // and Projectile.HurtPlayer methods can be used directly if needed for a projectile not using ProjectileID.Sets.Explosive

            // Play an exploding sound.
            SoundEngine.PlaySound(SoundID.DD2_BetsyFireballImpact, Projectile.position);
            SoundEngine.PlaySound(SoundID.DD2_BetsyFireballShot, Projectile.position);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
            // Resize the projectile again so the explosion dust and gore spawn from the middle.
            // Rocket I: 22, Rocket III: 80, Mini Nuke Rocket: 50
            Projectile.Resize(570, 570);

            
                Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(20));
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<GeigerBoom>(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity2 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(65));
                Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                ModContent.ProjectileType<GeigerBoom>(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity3 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(110));
                Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                ModContent.ProjectileType<GeigerBoom    >(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity4 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(155));
                Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
                ModContent.ProjectileType<GeigerBoom>(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity5 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(200));
                Vector2 Peanits5 = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits5, velocity5,
                ModContent.ProjectileType<GeigerBoom>(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity6 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(245));
                Vector2 Peanits6 = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits6, velocity6,
                ModContent.ProjectileType<GeigerBoom>(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity7 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(290));
                Vector2 Peanits7 = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits7, velocity7,
                ModContent.ProjectileType<GeigerBoom>(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);
                Vector2 velocity8 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(335));
                Vector2 Peanits8 = Projectile.Center - new Vector2(Main.rand.NextFloat(-40, 40));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits8, velocity8,
                ModContent.ProjectileType<GeigerBoom>(), (int)(Projectile.damage * 0.6f), Projectile.knockBack, Projectile.owner);

            

            // Spawn a bunch of fire dusts.
            for (int j = 0; j < 52; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default, 3.9f);
                fireDust.noGravity = true;
                fireDust.velocity *= 7f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default, 1.7f);
                fireDust.velocity *= 3f;
                Dust fire1Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default, 3.9f);
                fire1Dust.noGravity = true;
                fire1Dust.velocity *= 7f;
                fire1Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default, 1.7f);
                fire1Dust.velocity *= 3f;
                Dust fire11Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 100, default, 4.2f);
                fire11Dust.noGravity = true;
                fire11Dust.velocity *= 7f;
                fire11Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 100, default, 2f);
                fire11Dust.velocity *= 3f;
            }
            for (int j = 0; j < 51; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                fireDust.noGravity = true;
                fireDust.velocity *= 4.5f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 4f);
                fireDust.velocity *= 2f;
                Dust fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 3f);
                fireeDust.noGravity = true;
                fireeDust.velocity *= 4.5f;
                fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 3.8f);
                fireeDust.velocity *= 2f;
                Dust fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2.7f);
                fireeeDust.noGravity = true;
                fireeeDust.velocity *= 4.5f;
                fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2.2f);
                fireeeDust.velocity *= 2f;
            }
            for (int j = 0; j < 34; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                fireDust.noGravity = true;
                fireDust.velocity *= 3f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
                fireDust.velocity *= 1f;
                Dust fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
                fireeDust.noGravity = true;
                fireeDust.velocity *= 3f;
                fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2.8f);
                fireeDust.velocity *= 1f;
                Dust fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2.7f);
                fireeeDust.noGravity = true;
                fireeeDust.velocity *= 3f;
                fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2.2f);
                fireeeDust.velocity *= 1f;
            }
            // Spawn a bunch of fire dusts.
            for (int j = 0; j < 39; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                fireDust.noGravity = true;
                fireDust.velocity *= 3f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GemEmerald, 0f, 0f, 100, default, 1.5f);
                fireDust.velocity *= 1f;
                Dust fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default, 3.5f);
                fireeDust.noGravity = true;
                fireeDust.velocity *= 3f;
                fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GemAmethyst, 0f, 0f, 100, default, 1.5f);
                fireeDust.velocity *= 1f;
                Dust fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Wraith, 0f, 0f, 100, default, 3.5f);
                fireeeDust.noGravity = true;
                fireeeDust.velocity *= 3f;
                fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Wraith, 0f, 0f, 100, default, 1.5f);
                fireeeDust.velocity *= 1f;
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
}