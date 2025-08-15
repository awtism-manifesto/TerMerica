using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Projectiles
{
    /// <summary>
    /// This the class that clones the vanilla Meowmere projectile using CloneDefaults().
    /// Make sure to check out <see cref="ExampleCloneWeapon" />, which fires this projectile; it itself is a cloned version of the Meowmere.
    /// </summary>
    public class JevilScythe : ModProjectile
    {
        public override void SetDefaults()
        {
            // This method right here is the backbone of what we're doing here; by using this method, we copy all of
            // the Meowmere Projectile's SetDefault stats (such as projectile.friendly and projectile.penetrate) on to our projectile,
            // so we don't have to go into the source and copy the stats ourselves. It saves a lot of time and looks much cleaner;
            // if you're going to copy the stats of a projectile, use CloneDefaults().

            Projectile.CloneDefaults(ProjectileID.WoodenBoomerang);
            Projectile.width = 31;
            Projectile.height = 31;
            // To further the Cloning process, we can also copy the ai of any given projectile using AIType, since we want
            // the projectile to essentially behave the same way as the vanilla projectile.
            AIType = ProjectileID.WoodenBoomerang;
            Projectile.extraUpdates = 1;
            Projectile.scale = 1.95f;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            // After CloneDefaults has been called, we can now modify the stats to our wishes, or keep them as they are.
            // For the sake of example, lets make our projectile penetrate enemies a few more times than the vanilla projectile.
            // This can be done by modifying projectile.penetrate

        }
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<JevilTag>(), 300);

            Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(45));
                Vector2 Peanits = Projectile.Center - new Vector2(-30, 30);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
                ModContent.ProjectileType<JevilScythe2>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity2 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(135));
            Vector2 Peanits2 = Projectile.Center - new Vector2(-30, 30);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
            ModContent.ProjectileType<JevilScythe2>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity3 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(225));
            Vector2 Peanits3 = Projectile.Center - new Vector2(-30, 30);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
            ModContent.ProjectileType<JevilScythe2>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity4 = Projectile.velocity.RotatedBy(MathHelper.ToRadians(315));
            Vector2 Peanits4 = Projectile.Center - new Vector2(-30, 30);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
            ModContent.ProjectileType<JevilScythe2>(), (int)(Projectile.damage * 0.66f), Projectile.knockBack, Projectile.owner);
            Projectile.Kill();
        }
        public override void OnKill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            
        }
    }
}