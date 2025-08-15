using gunrightsmod.Content.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    public class ShroomBoom: ModProjectile
    {
        public override void SetStaticDefaults()
        {
           
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; // Damage dealt to players does not scale with difficulty in vanilla.
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 25; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
          
            // This set handles some things for us already:
            // Sets the timeLeft to 3 and the projectile direction when colliding with an NPC or player in PVP (so the explosive can detonate).
            // Explosives also bounce off the top of Shimmer, detonate with no blast damage when touching the bottom or sides of Shimmer, and damage other players in For the Worthy worlds.
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;
            Main.projFrames[Projectile.type] = 4;
            // This set makes it so the rocket doesn't deal damage to players. Only used for vanilla rockets.
            // Simply remove the Projectile.HurtPlayer() part to stop the projectile from damaging its user.
            // ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.tileCollide = false;
            Projectile.scale = 1f;
            Projectile.friendly = false;
            Projectile.hostile = false;
         
            Projectile.penetrate = 696969; // Infinite penetration so that the blast can hit all enemies within its radius.
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.light = 0.7f; // How much light emit around the projectile
            Projectile.usesLocalNPCImmunity = true;
            Projectile.extraUpdates = 2;
            Projectile.timeLeft = 179;
       
            Projectile.localNPCHitCooldown = -1;
            Projectile.aiStyle = -1;
            Projectile.alpha = 85;
            // Rockets use explosive AI, ProjAIStyleID.Explosive (16). You could use that instead here with the correct AIType.
            // But, using our own AI allows us to customize things like the dusts that the rocket creates.
            // Projectile.aiStyle = ProjAIStyleID.Explosive;
            // AIType = ProjectileID.RocketI;
        }

        
        public override void AI()
        {


            if (Projectile.timeLeft < 136)
            {
               
                Projectile.friendly = true;
               
            }

            if (Projectile.timeLeft> 158)
            {
                int frameSpeed = 17;

                Projectile.frameCounter++;

                if (Projectile.frameCounter >= frameSpeed)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;

                    if (Projectile.frame >= Main.projFrames[Projectile.type])
                    {
                        Projectile.frame = 0;


                    }
                }


            }
            if (Projectile.timeLeft < 158)
            {
                int frameSpeed = 14;

                Projectile.frameCounter++;

                if (Projectile.frameCounter >= frameSpeed)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;

                    if (Projectile.frame >= Main.projFrames[Projectile.type])
                    {
                        Projectile.frame = 0;


                    }
                }


            }
            if (Projectile.timeLeft < 134)
            {
                int frameSpeed = 12;

                Projectile.frameCounter++;

                if (Projectile.frameCounter >= frameSpeed)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;

                    if (Projectile.frame >= Main.projFrames[Projectile.type])
                    {
                        Projectile.frame = 0;


                    }
                }


            }
            if (Projectile.timeLeft < 98)
            {
                int frameSpeed = 9;

                Projectile.frameCounter++;

                if (Projectile.frameCounter >= frameSpeed)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;

                    if (Projectile.frame >= Main.projFrames[Projectile.type])
                    {
                        Projectile.frame = 0;


                    }
                }


            }
            if (Projectile.timeLeft < 31)
            {
                int frameSpeed = 6;

                Projectile.frameCounter++;

                if (Projectile.frameCounter >= frameSpeed)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;

                    if (Projectile.frame >= Main.projFrames[Projectile.type])
                    {
                        Projectile.frame = 0;


                    }
                }


            }

           


            Projectile.velocity *= 0f;

            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 5)
            {
                Projectile.PrepareBombToBlow();
            }
           

           
        }

       
      

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false; // This is important or the explosion will be in the wrong place if the rocket explodes on slopes.
            Projectile.alpha = 255; // Make the rocket invisible.

            // Resize the hitbox of the projectile for the blast "radius".
            // Rocket I: 128, Rocket III: 200, Mini Nuke Rocket: 250
            // Measurements are in pixels, so 128 / 16 = 8 tiles.
            Projectile.Resize(135, 135);
            // Set the knockback of the blast.
            // Rocket I: 8f, Rocket III: 10f, Mini Nuke Rocket: 12f
            Projectile.knockBack = 5f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.damage = (int)(Projectile.damage * 0.96f);
            
        }
        public override void OnKill(int timeLeft)
        {
            // Vanilla code takes care ensuring that in For the Worthy or Get Fixed Boi worlds the blast can damage other players because
            // this projectile is ProjectileID.Sets.Explosive[Type] = true;. It also takes care of hurting the owner. The Projectile.PrepareBombToBlow
            // and Projectile.HurtPlayer methods can be used directly if needed for a projectile not using ProjectileID.Sets.Explosive

            // Play an exploding sound.
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
            

            // Resize the projectile again so the explosion dust and gore spawn from the middle.
            // Rocket I: 22, Rocket III: 80, Mini Nuke Rocket: 50
            Projectile.Resize(100, 100);

            // Spawn a bunch of smoke dusts.
            for (int i = 0; i < 15; i++)
            {
                Dust smokeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<BlueLycopiteDust>(), 0f, 0f, 100, default, 1.1f);
                smokeDust.velocity *= 5f;
            }

            // Spawn a bunch of fire dusts.
            for (int j = 0; j < 10; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                fireDust.noGravity = true;
                fireDust.velocity *= 5.25f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                fireDust.velocity *= 5f;
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
