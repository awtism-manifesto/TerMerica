using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Projectiles
{
    public class BloodshotSpawn : ModProjectile
    {
        

        public override void SetDefaults()
        {
            Projectile.width = 1; // The width of projectile hitbox
            Projectile.height = 1; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = false; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 1; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            
            Projectile.light = 0f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 0; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }

        public override void OnSpawn(IEntitySource source)
        {
           
        }




        public override void OnKill(int timeLeft)
        {



            Vector2 Peanits = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-105, 105), 940));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
            new Vector2(24, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<BloodIchor>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
            Vector2 Peanit1s = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-125, 125), 960));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanit1s,
            new Vector2(24, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
               ModContent.ProjectileType<BloodIchor>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
            Vector2 Jorkin = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-65, 65), 925));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Jorkin,
            new Vector2(28, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<BloodIchor>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
            Vector2 Stripped = (Main.player[Projectile.owner].Center - new Vector2(Main.rand.Next(-25, 25), 970));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Stripped,
            new Vector2(32, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<BloodIchor>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);


        }

    }

}



