using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.DamageClasses;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    // This example is similar to the Wooden Arrow projectile
    public class GalaxyProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // If this arrow would have strong effects (like Holy Arrow pierce), we can make it fire fewer projectiles from Daedalus Stormbow for game balance considerations like this:
            //ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 18; // The width of projectile hitbox
            Projectile.height = 18; // The height of projectile hitbox
            Projectile.aiStyle = 1;
            Projectile.arrow = true;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<OmniDamage>();
            Projectile.timeLeft = 640;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.WoodenArrowFriendly;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<GalaxyTag>(), 330);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;

        }
        public override void AI()
        {
            // The code below was adapted from the ProjAIStyleID.Arrow behavior. Rather than copy an existing aiStyle using Projectile.aiStyle and AIType,
            // like some examples do, this example has custom AI code that is better suited for modifying directly.
            // See https://github.com/tModLoader/tModLoader/wiki/Basic-Projectile#what-is-ai for more information on custom projectile AI.

            // Apply gravity after a quarter of a second
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 13f)
            {
                Projectile.ai[0] = 8f;
                Projectile.velocity.Y += 0.24f;
            }

            // The projectile is rotated to face the direction of travel
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Cap downward velocity
            if (Projectile.velocity.Y > 13f)
            {
                Projectile.velocity.Y = 19f;
            }
           
            
        }
       
        public override void OnKill(int timeLeft)
        {

           
                Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
                new Vector2(11, 5).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<GalaxyBoom>(), Projectile.damage = (int)(Projectile.damage * 0.425f), Projectile.knockBack, Projectile.owner);
                Vector2 JorkinMy = Projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), JorkinMy,
                new Vector2(-3, 8).RotatedBy((JorkinMy).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<GalaxyShard>(), Projectile.damage = (int)(Projectile.damage * 0.85f), Projectile.knockBack, Projectile.owner);
                Vector2 InDaClerb = Projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), InDaClerb,
                new Vector2(6, -10).RotatedBy((InDaClerb).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<GalaxyShard>(), Projectile.damage = (int)(Projectile.damage * 0.999f), Projectile.knockBack, Projectile.owner);
                Vector2 UwU = Projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), UwU,
                new Vector2(-5, -11).RotatedBy((UwU).DirectionTo(Projectile.Center).ToRotation()),
                ModContent.ProjectileType<GalaxyShard>(), Projectile.damage = (int)(Projectile.damage * 0.999f), Projectile.knockBack, Projectile.owner);
               
            

            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position); // Plays the basic sound most projectiles make when hitting blocks.
           
        }
    }
}