using gunrightsmod.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Projectiles
{
    public class KingShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode

        }

        public override void SetDefaults()
        {
            Projectile.width = 10; // The width of projectile hitbox
            Projectile.height = 10; // The height of projectile hitbox

            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 3; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 359; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
                                       // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.

            Projectile.ignoreWater = false; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 3; // Set to above 0 if you want the projectile to update multiple time in a frame
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
            Projectile.scale = 0.5f;
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            Projectile.damage = (int)(Projectile.damage * 0.75f);


            for (int i = 0; i < 6; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HallowedWeapons);
                dust.noGravity = true;
                dust.velocity *= 9.5f;
                dust.scale *= 1f;
            }



        }
        public override void AI()
        {

            // dust, all dust
            if (Projectile.alpha <202)
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
                    Dust chudDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 6, Projectile.height - 6, DustID.HallowedWeapons, 0f, 0f, 100, default, 0.75f);
                    chudDust.fadeIn = 0.1f + Main.rand.Next(3) * 0.1f;
                    chudDust.velocity *= 0.16f;
                    Dust kms = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 6, Projectile.height - 6, DustID.YellowTorch, 0f, 0f, 100, default, 0.75f);
                    kms.fadeIn = 0.1f + Main.rand.Next(3) * 0.1f;
                    kms.velocity *= 0.16f;

                    Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 1f + posOffsetX, Projectile.position.Y + 1f + posOffsetY) - Projectile.velocity * 0.1f, Projectile.width - 6, Projectile.height - 6, DustID.BunnySlime, 0f, 0f, 100, Color.LightSkyBlue, 0.48f);
                    fireDust.fadeIn = 0.1f + Main.rand.Next(2) * 0.1f;
                    fireDust.velocity *= 0.115f;
                    fireDust.alpha = 100;
                    fireDust.noGravity = true;
                }
            }




        }
    }
}
    

