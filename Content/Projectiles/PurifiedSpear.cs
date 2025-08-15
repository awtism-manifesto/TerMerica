
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    public class PurifiedSpear : ModProjectile
    {
        // Define the range of the Spear Projectile. These are overridable properties, in case you'll want to make a class inheriting from this one.
        protected virtual float HoldoutRangeMin => 30f;
        protected virtual float HoldoutRangeMax => 305f;

        public override void SetDefaults()
        {
           
            Projectile.usesOwnerMeleeHitCD = true;
           
            Projectile.CloneDefaults(ProjectileID.AdamantiteGlaive);
            Projectile.width = 40;
            Projectile.height = 40;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3))
            {
                Vector2 Peanits = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-150, 150), 840));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(24, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<PurifiedSaltProj>(), (int)(Projectile.damage * 0.35f), Projectile.knockBack, Projectile.owner);
            }
            if (Main.rand.NextBool(2))
            {
                Vector2 Jorkin = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-70, 70), 925));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Jorkin,
                new Vector2(28, 0).RotatedBy((Jorkin).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<PurifiedSaltProj>(), (int)(Projectile.damage * 0.35f), Projectile.knockBack, Projectile.owner);
            }
            Vector2 Stripped = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-30, 30), 770));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Stripped,
            new Vector2(32, 0).RotatedBy((Stripped).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<PurifiedSaltProj>(), (int)(Projectile.damage * 0.35f), Projectile.knockBack, Projectile.owner);
        }
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner]; // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            int duration = player.itemAnimationMax; // Define the duration the projectile will exist in frames

            player.heldProj = Projectile.whoAmI; // Update the player's held projectile id

            // Reset projectile time left if necessary
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            Projectile.velocity = Vector2.Normalize(Projectile.velocity); // Velocity isn't used in this spear implementation, but we use the field to store the spear's attack direction.

            float halfDuration = duration * 0.5f;
            float progress;

            // Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
            if (Projectile.timeLeft < halfDuration)
            {
                progress = Projectile.timeLeft / halfDuration;
            }
            else
            {
                Projectile.Resize(72, 72);
                progress = (duration - Projectile.timeLeft) / halfDuration;
            }

            // Move the projectile from the HoldoutRangeMin to the HoldoutRangeMax and back, using SmoothStep for easing the movement
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            // Apply proper rotation to the sprite.
            if (Projectile.spriteDirection == -1)
            {
                // If sprite is facing left, rotate 45 degrees
                Projectile.rotation += MathHelper.ToRadians(45f);
            }
            else
            {
                // If sprite is facing right, rotate 135 degrees
                Projectile.rotation += MathHelper.ToRadians(135f);
            }

            // Avoid spawning dusts on dedicated servers
            if (!Main.dedServ)
            {
                // These dusts are added later, for the 'ExampleMod' effect
                if (Main.rand.NextBool(3))
                {
                    Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HallowedTorch, Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, Alpha: 1, Scale: 1.4f);
                }

                if (Main.rand.NextBool(4))
                {
                    Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Ghost, Alpha: 1, Scale: 1f);
                }
            }

            return false; // Don't execute vanilla AI.
        }
    }
}