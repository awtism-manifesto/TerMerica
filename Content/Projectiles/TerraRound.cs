using gunrightsmod.Content.Dusts;
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
    public class TerraRound : ModProjectile
    {
        

        public override void SetDefaults()
        {
            Projectile.width = 5; // The width of projectile hitbox
            Projectile.height = 5; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 240; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.4f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 15; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }
        public override Color? GetAlpha(Color lightColor)
        {

            return Color.LimeGreen;
        }

        public override void AI()
        {
            // The code below was adapted from the ProjAIStyleID.Arrow behavior. Rather than copy an existing aiStyle using Projectile.aiStyle and AIType,
            // like some examples do, this example has custom AI code that is better suited for modifying directly.
            // See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#what-is-ai for more information on custom projectile AI.


            // dust, all dust
            if (Projectile.alpha < 169)
            {
                
                for (int i = 0; i < 2; i++)
                {
                    float posOffsetX = 0f;
                    float posOffsetY = 0f;
                    if (i == 1)
                    {
                        posOffsetX = Projectile.velocity.X * 2.5f;
                        posOffsetY = Projectile.velocity.Y * 2.5f;
                    }



                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 12, Projectile.height - 12, DustID.TerraBlade, 0f, 0f, 100, default, 0.45f);
                    fireDust.fadeIn = 0.1f + Main.rand.Next(1) * 0.05f;
                    fireDust.velocity *= 0.2f;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Vanilla code takes care ensuring that in For the Worthy or Get Fixed Boi worlds the blast can damage other players because
            // this projectile is ProjectileID.Sets.Explosive[Type] = true;. It also takes care of hurting the owner. The Projectile.PrepareBombToBlow
            // and Projectile.HurtPlayer methods can be used directly if needed for a projectile not using ProjectileID.Sets.Explosive
            Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360f));
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(-216, 216), Main.rand.NextFloat(-216, 216));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<TerraRoundCopy>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);

            if (Main.rand.NextBool(100))
            {
                Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360f));
                Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(-216, 216), Main.rand.NextFloat(-216, 216));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
                    ProjectileID.ChlorophyteBullet, (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);

            }


                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.TrueNightsEdge,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  Projectile.owner);


        }



    }
}