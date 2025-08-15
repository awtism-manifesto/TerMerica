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
    public class BigShot : ModProjectile
    {
        

        public override void SetDefaults()
        {
            Projectile.width = 90; // The width of projectile hitbox
            Projectile.height = 90; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = ModContent.GetInstance<OmniDamage>();
            Projectile.penetrate = 16; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 300; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.75f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = false; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.damage = (int)(Projectile.damage * 0.96f);

            for (int i = 0; i < 8; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkTorch);
                dust.noGravity = true;
                dust.velocity *= 17.5f;
                dust.scale *= 2.25f;
                Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
                dust2.noGravity = true;
                dust2.velocity *= 17.5f;
                dust2.scale *= 2.25f;
            }


        }

        public override void AI()
        {

           

            if (Projectile.timeLeft < 292)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 284)
            {
                Projectile.scale = 0.725f;
                Projectile.Resize(85, 85);
            }
            if (Projectile.timeLeft < 276)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 268)
            {
                Projectile.scale = 1.05f;
                Projectile.Resize(110, 110);
            }
            if (Projectile.timeLeft < 260)
            {
                Projectile.scale = 1.175f;

            }
            if (Projectile.timeLeft < 252)
            {
                Projectile.scale = 1.325f;
                Projectile.Resize(125, 125);
            }
            if (Projectile.timeLeft < 244)
            {
                Projectile.scale = 1.15f;

            }
            if (Projectile.timeLeft < 236)
            {
                Projectile.scale = 0.975f;
                Projectile.Resize(105, 105);
            }

            if (Projectile.timeLeft < 228)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 220)
            {
                Projectile.scale = 0.725f;
                Projectile.Resize(95, 95);
            }
            if (Projectile.timeLeft < 212)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 204)
            {
                Projectile.scale = 1.05f;
                Projectile.Resize(105, 105);
            }
            if (Projectile.timeLeft < 196)
            {
                Projectile.scale = 1.175f;

            }
            if (Projectile.timeLeft < 188)
            {
                Projectile.scale = 1.325f;
                Projectile.Resize(130, 130);
            }
            if (Projectile.timeLeft < 180)
            {
                Projectile.scale = 1.15f;

            }
            if (Projectile.timeLeft < 172)
            {
                Projectile.scale = 0.975f;
                Projectile.Resize(110, 110);
            }
            if (Projectile.timeLeft < 164)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 156)
            {
                Projectile.scale = 0.725f;
               
            }
            if (Projectile.timeLeft < 148)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 140)
            {
                Projectile.scale = 1.05f;
               
            }
            if (Projectile.timeLeft < 132)
            {
                Projectile.scale = 1.175f;

            }
            if (Projectile.timeLeft < 124)
            {
                Projectile.scale = 1.325f;
                Projectile.Resize(114, 114);
            }
            if (Projectile.timeLeft < 116)
            {
                Projectile.scale = 1.15f;

            }
            if (Projectile.timeLeft < 108)
            {
                Projectile.scale = 0.975f;
                Projectile.Resize(98, 98);
            }
            if (Projectile.timeLeft < 100)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 92)
            {
                Projectile.scale = 0.725f;
               
            }
            if (Projectile.timeLeft < 84)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 76)
            {
                Projectile.scale = 1.05f;
               
            }
            if (Projectile.timeLeft < 68)
            {
                Projectile.scale = 1.175f;

            }
            if (Projectile.timeLeft < 60)
            {
                Projectile.scale = 1.325f;
              
            }
            if (Projectile.timeLeft < 52)
            {
                Projectile.scale = 1.15f;

            }
            if (Projectile.timeLeft < 44)
            {
                Projectile.scale = 0.975f;
               
            }
            if (Projectile.timeLeft < 36)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 28)
            {
                Projectile.scale = 0.79f;
               
            }
            if (Projectile.timeLeft < 20)
            {
                Projectile.scale = 0.97f;

            }
            if (Projectile.timeLeft < 12)
            {
                Projectile.scale = 1.12f;
                Projectile.Resize(95, 95);
            }
           
            if (Projectile.timeLeft < 11)
            {
                Projectile.scale = 1.48f;
                Projectile.Resize(165, 165);
            }
          






        }

    }

}


