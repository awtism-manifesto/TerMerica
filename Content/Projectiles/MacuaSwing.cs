using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    // This is a copy of the Excalibur's projectile
    public class MacuaSwing : ModProjectile
    {
        // We could use a vanilla texture if we want instead of supplying our own.
        // public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Excalibur;

        public override void SetStaticDefaults()
        {
            // If a Jellyfish is zapping and we attack it with this projectile, it will deal damage to us.
            // This set has the projectiles for the Night's Edge, Excalibur, Terra Blade (close range), and The Horseman's Blade (close range).
            // This set does not have the True Night's Edge, True Excalibur, or the long range Terra Beam projectiles.
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;
          
        }

        public override void SetDefaults()
        {
            // The width and height don't really matter here because we have custom collision.
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 3; // The projectile can hit 3 enemies.
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true; // A line of sight check so the projectile can't deal damage through tiles.
            Projectile.ownerHitCheckDistance = 104f; // The maximum range that the projectile can hit a target. 300 pixels is 18.75 tiles.
            Projectile.usesOwnerMeleeHitCD = true; // This will make the projectile apply the standard number of immunity frames as normal melee attacks.
                                                   // Normally, projectiles die after they have hit all the enemies they can.
                                                   // But, for this case, we want the projectile to continue to live so we can have the visuals of the swing.
            Projectile.stopsDealingDamageAfterPenetrateHits = true;

            // We will be using custom AI for this projectile. The original Excalibur uses aiStyle 190.
            Projectile.aiStyle = -1;
            // Projectile.aiStyle = ProjAIStyleID.NightsEdge; // 190
            // AIType = ProjectileID.Excalibur;

            // If you are using custom AI, add this line. Otherwise, visuals from Flasks will spawn at the center of the projectile instead of around the arc.
            // We will spawn the visuals around the arc ourselves in the AI().
            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {
            // In our item, we spawn the projectile with the direction, max time, and scale
            // Projectile.ai[0] == direction
            // Projectile.ai[1] == max time
            // Projectile.ai[2] == scale
            // Projectile.localAI[0] == current time

            // Terra Blade makes an extra sound when spawning.
            // if (Projectile.localAI[0] == 0f) {
            // 	SoundEngine.PlaySound(SoundID.Item60 with { Volume = 0.65f }, Projectile.position);
            // }

            Projectile.localAI[0]++; // Current time that the projectile has been alive.
            Player player = Main.player[Projectile.owner];
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; // The current time over the max time.
            float direction = Projectile.ai[0];
            float velocityRotation = Projectile.velocity.ToRotation();
            float adjustedRotation = MathHelper.Pi * direction * percentageOfLife + velocityRotation + direction * MathHelper.Pi + player.fullRotation;
            Projectile.rotation = adjustedRotation; // Set the rotation to our to the new rotation we calculated.

            float scaleMulti = 0.6f; // Excalibur, Terra Blade, and The Horseman's Blade is 0.6f; True Excalibur is 1f; default is 0.2f 
            float scaleAdder = 1f; // Excalibur, Terra Blade, and The Horseman's Blade is 1f; True Excalibur is 1.2f; default is 1f 

            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) - Projectile.velocity;
            Projectile.scale = scaleAdder + percentageOfLife * scaleMulti;

            // The other sword projectiles that use AI Style 190 have different effects.
            // This example only includes the Excalibur.
            // Look at AI_190_NightsEdge() in Projectile.cs for the others.

            // Here we spawn some dust inside the arc of the swing.
            
           

          

            Projectile.scale *= Projectile.ai[2]; // Set the scale of the projectile to the scale of the item.

            // If the projectile is as old as the max animation time, kill the projectile.
            if (Projectile.localAI[0] >= Projectile.ai[1])
            {
                Projectile.Kill();
            }

            // This for loop spawns the visuals when using Flasks (weapon imbues)
            for (float i = -MathHelper.PiOver4; i <= MathHelper.PiOver4; i += MathHelper.PiOver2)
            {
                Rectangle rectangle = Utils.CenteredRectangle(Projectile.Center + (Projectile.rotation + i).ToRotationVector2() * 70f * Projectile.scale, new Vector2(60f * Projectile.scale, 60f * Projectile.scale));
                Projectile.EmitEnchantmentVisualsAt(rectangle.TopLeft(), rectangle.Width, rectangle.Height);
            }
        }

        // Here is where we have our custom collision.
        // This collision will only run if the projectile is within range of target with the range being Projectile.ownerHitCheckDistance
        // Or if the projectile hasn't already hit all of the targets it can with Projectile.penetrate
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // This is how large the circumference is, aka how big the range is. Vanilla uses 94f to match it to the size of the texture.
            float coneLength = 50f * Projectile.scale;
            // This number affects how much the start and end of the collision will be rotated.
            // Bigger Pi numbers will rotate the collision counter clockwise.
            // Smaller Pi numbers will rotate the collision clockwise.
            // (Projectile.ai[0] is the direction)
            float collisionRotation = MathHelper.Pi * 2f / 25f * Projectile.ai[0];
            float maximumAngle = MathHelper.PiOver4; // The maximumAngle is used to limit the rotation to create a dead zone.
            float coneRotation = Projectile.rotation + collisionRotation;

            // Uncomment this line for a visual representation of the cone. The dusts are not perfect, but it gives a general idea.
            // Dust.NewDustPerfect(Projectile.Center + coneRotation.ToRotationVector2() * coneLength, DustID.Pixie, Vector2.Zero);
            // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(maximumAngle) * Projectile.ai[0], (float)Math.Sin(maximumAngle)) * 5f); // Assumes collisionRotation was not changed

            // First, we check to see if our first cone intersects the target.
            if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation, maximumAngle))
            {
                return true;
            }

            // The first cone isn't the entire swinging arc, though, so we need to check a second cone for the back of the arc.
            float backOfTheSwing = Utils.Remap(Projectile.localAI[0], Projectile.ai[1] * 0.3f, Projectile.ai[1] * 0.5f, 1f, 0f);
            if (backOfTheSwing > 0f)
            {
                float coneRotation2 = coneRotation - MathHelper.PiOver4 * Projectile.ai[0] * backOfTheSwing;

                // Uncomment this line for a visual representation of the cone. The dusts are not perfect, but it gives a general idea.
                // Dust.NewDustPerfect(Projectile.Center + coneRotation2.ToRotationVector2() * coneLength, DustID.Enchanted_Pink, Vector2.Zero);
                // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(backOfTheSwing) * -Projectile.ai[0], (float)Math.Sin(backOfTheSwing)) * 5f); // Assumes collisionRotation was not changed

                if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation2, maximumAngle))
                {
                    return true;
                }
            }

            return false;
        }

        public override void CutTiles()
        {
            // Here we calculate where the projectile can destroy grass, pots, Queen Bee Larva, etc.
            Vector2 starting = (Projectile.rotation - MathHelper.PiOver4).ToRotationVector2() * 60f * Projectile.scale;
            Vector2 ending = (Projectile.rotation + MathHelper.PiOver4).ToRotationVector2() * 60f * Projectile.scale;
            float width = 60f * Projectile.scale;
            Utils.PlotTileLine(Projectile.Center + starting, Projectile.Center + ending, width, DelegateMethods.CutTiles);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);


            for (int i = -1; i <= 1; i++)
            {
                float angle = 11 * i; // gives -15, 0, 15
                Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(70));
                Vector2 Peanits = Projectile.Center - new Vector2(0, 0);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<ObsidianScrap>(), (int)(Projectile.damage * 0.6f), (int)(Projectile.knockBack * 0.3f), Projectile.owner);
            }


        }





    }
}