using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    // Shortsword projectiles are handled in a special way with how they draw and damage things
    // The "hitbox" itself is closer to the player, the sprite is centered on it
    // However the interactions with the world will occur offset from this hitbox, closer to the sword's tip (CutTiles, Colliding)
    // Values chosen mostly correspond to Iron Shortsword
    public class DaggerProj : ModProjectile
    {
        public const int FadeInDuration = 8;
        public const int FadeOutDuration = 5;

        public const int TotalDuration = 14;

        // The "width" of the blade
        public float CollisionWidth => 15f * Projectile.scale;

        public int Timer
        {
            get => (int)Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new Vector2(18); // This sets width and height to the same value (important when projectiles can rotate)
            Projectile.aiStyle = 1; // Use our own AI to customize how it behaves, if you don't want that, keep this at ProjAIStyleID.ShortSword. You would still need to use the code in SetVisualOffsets() though
            Projectile.friendly = true;
            Projectile.penetrate = 3;
            Projectile.tileCollide = false;
            Projectile.width = 53;
            Projectile.height = 53;
            Projectile.scale = 1.5f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ownerHitCheck = true; // Prevents hits through tiles. Most melee weapons that use projectiles have this
            Projectile.extraUpdates = 1; // Update 1+extraUpdates times per tick
            Projectile.timeLeft = 15; // This value does not matter since we manually kill it earlier, it just has to be higher than the duration we use in AI
          
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Timer += 1;
            if (Timer >= TotalDuration)
            {
                // Kill the projectile if it reaches it's intended lifetime
               
                return;
            }
            else
            {
                // Important so that the sprite draws "in" the player's hand and not fully in front or behind the player
                player.heldProj = Projectile.whoAmI;
            }

            // Fade in and out
            // GetLerpValue returns a value between 0f and 1f - if clamped is true - representing how far Timer got along the "distance" defined by the first two parameters
            // The first call handles the fade in, the second one the fade out.
            // Notice the second call's parameters are swapped, this means the result will be reverted
            Projectile.Opacity = Utils.GetLerpValue(0f, FadeInDuration, Timer, clamped: true) * Utils.GetLerpValue(TotalDuration, TotalDuration - FadeOutDuration, Timer, clamped: true);

            // Keep locked onto the player, but extend further based on the given velocity (Requires ShouldUpdatePosition returning false to work)
            Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false);
            Projectile.Center = playerCenter + Projectile.velocity * (Timer - 1f);

            // Set spriteDirection based on moving left or right. Left -1, right 1
            Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();

            // Point towards where it is moving, applied offset for top right of the sprite respecting spriteDirection
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            // The code in this method is important to align the sprite with the hitbox how we want it to
            SetVisualOffsets();
            for (int i = 0; i < 2; i++)
            {
                float posOffsetX = 0f;
                float posOffsetY = 0f;
                if (i == 1)
                {
                    posOffsetX = Projectile.velocity.X * 2.5f;
                    posOffsetY = Projectile.velocity.Y * 2.5f;
                }

                Dust fire2Dust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 29, Projectile.height - 29, DustID.DemonTorch, 0f, 0f, 100, default, 1.15f);
                fire2Dust.fadeIn = 0.2f + Main.rand.Next(4) * 0.1f;
                fire2Dust.noGravity = true;
                fire2Dust.velocity *= 0.1f;
               
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.ShadowFlame, 155);
            target.AddBuff(BuffID.Venom, 120);
            target.immune[Projectile.owner] = 4;

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish)&&target.HasBuff(ModContent.BuffType<DeliriantTag>()))
            {

                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                 new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                 Projectile.owner);

                if (Main.rand.NextBool(7))
                {
                    Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(0));
                    Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);
                    Vector2 velocity2 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(90));
                    Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                    ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);
                    Vector2 velocity3 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(180));
                    Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                   ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);
                    Vector2 velocity4 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(270));
                    Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
                   ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);



                }
                if (Main.rand.NextBool(7))
                {
                    Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(45));
                    Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                    ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);
                    Vector2 velocity2 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(135));
                    Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                    ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);
                    Vector2 velocity3 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(225));
                    Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
                   ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);
                    Vector2 velocity4 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(315));
                    Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(0, 0));
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
                   ModContent.ProjectileType<DragonSpawnShadow>(), (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);

                }

            }

        }
        private void SetVisualOffsets()
        {
            // 32 is the sprite size (here both width and height equal)
            const int HalfSpriteWidth = 59 / 2;
            const int HalfSpriteHeight = 59 / 2;

            int HalfProjWidth = Projectile.width / 2;
            int HalfProjHeight = Projectile.height / 2;

            // Vanilla configuration for "hitbox in middle of sprite"
            DrawOriginOffsetX = 0;
            DrawOffsetX = -(HalfSpriteWidth - HalfProjWidth);
            DrawOriginOffsetY = -(HalfSpriteHeight - HalfProjHeight);

            // Vanilla configuration for "hitbox towards the end"
            //if (Projectile.spriteDirection == 1) {
            //	DrawOriginOffsetX = -(HalfProjWidth - HalfSpriteWidth);
            //	DrawOffsetX = (int)-DrawOriginOffsetX * 2;
            //	DrawOriginOffsetY = 0;
            //}
            //else {
            //	DrawOriginOffsetX = (HalfProjWidth - HalfSpriteWidth);
            //	DrawOffsetX = 0;
            //	DrawOriginOffsetY = 0;
            //}
        }

        public override bool ShouldUpdatePosition()
        {
            // Update Projectile.Center manually
            return false;
        }

        public override void CutTiles()
        {
            // "cutting tiles" refers to breaking pots, grass, queen bee larva, etc.
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 start = Projectile.Center;
            Vector2 end = start + Projectile.velocity.SafeNormalize(-Vector2.UnitY) * 10f;
            Utils.PlotTileLine(start, end, CollisionWidth, DelegateMethods.CutTiles);
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // "Hit anything between the player and the tip of the sword"
            // shootSpeed is 2.1f for reference, so this is basically plotting 12 pixels ahead from the center
            Vector2 start = Projectile.Center;
            Vector2 end = start + Projectile.velocity * 6f;
            float collisionPoint = 0f; // Don't need that variable, but required as parameter
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, CollisionWidth, ref collisionPoint);
        }
    }
}