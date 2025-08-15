using gunrightsmod.Content.DamageClasses;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    public class DvdRed : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Deals double damage on direct hits.
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
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.penetrate = 6969; // Infinite penetration so that the blast can hit all enemies within its radius.
            Projectile.DamageType = ModContent.GetInstance<StupidDamage>();
            Projectile.light = 0.25f; // How much light emit around the projectile
            Projectile.usesLocalNPCImmunity = true;
            Projectile.extraUpdates = 0;
            Projectile.timeLeft = 60;
            // Rockets use explosive AI, ProjAIStyleID.Explosive (16). You could use that instead here with the correct AIType.
            // But, using our own AI allows us to customize things like the dusts that the rocket creates.
            // Projectile.aiStyle = ProjAIStyleID.Explosive;
            // AIType = ProjectileID.RocketI;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 8;
           
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



            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            // If the projectile hits the left or right side of the tile, reverse the X velocity
            if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            // If the projectile hits the top or bottom side of the tile, reverse the Y velocity
            if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }


            return false;
        }

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false; // This is important or the explosion will be in the wrong place if the rocket explodes on slopes.
            Projectile.alpha = 255; // Make the rocket invisible.

            // Resize the hitbox of the projectile for the blast "radius".
            // Rocket I: 128, Rocket III: 200, Mini Nuke Rocket: 250
            // Measurements are in pixels, so 128 / 16 = 8 tiles.
            Projectile.Resize(200, 200);
            // Set the knockback of the blast.
            // Rocket I: 8f, Rocket III: 10f, Mini Nuke Rocket: 12f
            Projectile.knockBack = 9f;
        }

        public override void OnKill(int timeLeft)
        {
            // Vanilla code takes care ensuring that in For the Worthy or Get Fixed Boi worlds the blast can damage other players because
            // this projectile is ProjectileID.Sets.Explosive[Type] = true;. It also takes care of hurting the owner. The Projectile.PrepareBombToBlow
            // and Projectile.HurtPlayer methods can be used directly if needed for a projectile not using ProjectileID.Sets.Explosive

            // Play an exploding sound.
          
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
          
            // Resize the projectile again so the explosion dust and gore spawn from the middle.
            // Rocket I: 22, Rocket III: 80, Mini Nuke Rocket: 50
            Projectile.Resize(175, 175);

           
                Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<DvdGreen>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
               
               

            

            // Spawn a bunch of fire dusts.
            for (int j = 0; j < 10; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 2.99f);
                fireDust.noGravity = true;
                fireDust.velocity *= 7f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 1.99f);
                fireDust.velocity *= 3f;
                Dust fire1Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 2.99f);
                fire1Dust.noGravity = true;
                fire1Dust.velocity *= 7f;
                fire1Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 2.5f);
                fire1Dust.velocity *= 3f;
                Dust fire11Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 3f);
                fire11Dust.noGravity = true;
                fire11Dust.velocity *= 7f;
                fire11Dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 2.5f);
                fire11Dust.velocity *= 3f;
            }
            for (int j = 0; j < 15; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 0.8f);
                fireDust.noGravity = true;
                fireDust.velocity *= 4.5f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 0.8f);
                fireDust.velocity *= 2f;
                Dust fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 0.9f);
                fireeDust.noGravity = true;
                fireeDust.velocity *= 4.5f;
                fireeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 0.5f);
                fireeDust.velocity *= 2f;
                Dust fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 0.7f);
                fireeeDust.noGravity = true;
                fireeeDust.velocity *= 4.5f;
                fireeeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 0.2f);
                fireeeDust.velocity *= 2f;
            }
           
            // Spawn a bunch of fire dusts.
           


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