using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using gunrightsmod.Content.Projectiles;


namespace gunrightsmod.Content.Items
{
    public class MidnightAfterburner : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightPurple; // The color that the item's name will be in-game.
            Item.value = Item.buyPrice(silver: 5950);


            // Use Properties
            Item.useTime = 37; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 37; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = SoundID.Item74;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 61; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 7.75f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.ArmorPenetration = 5;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ModContent.ProjectileType<OilBallRanged>();

            Item.shootSpeed = 14.75f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = ItemID.MusketBall;
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("DarkMatter", out ModItem DarkMatter))


            {
                Item.damage = 67;
                Item.useTime = 33; 
                Item.useAnimation = 33;
            }
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.DragonSpawnShadow>();
            SoundEngine.PlaySound(SoundID.Item38, player.position);

            SoundEngine.PlaySound(SoundID.Item45, player.position);
            SoundEngine.PlaySound(SoundID.Item88, player.position);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {


                Vector2 newVelocity = velocity.RotatedBy(MathHelper.ToRadians(52.5f));
               
                Vector2 new2Velocity = velocity.RotatedBy(MathHelper.ToRadians(15));
                Vector2 new3Velocity = velocity.RotatedBy(MathHelper.ToRadians(32.5f));
                Vector2 new4Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(2, 4)));
                Vector2 new5Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(2, 4)));
                Vector2 new6Velocity = velocity.RotatedBy(MathHelper.ToRadians(-52.5f));
                Vector2 new7Velocity = velocity.RotatedBy(MathHelper.ToRadians(-32.5f));
                Vector2 new8Velocity = velocity.RotatedBy(MathHelper.ToRadians(-15));



                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.15f);
                new2Velocity *= 1f - Main.rand.NextFloat(0.55f);
                new3Velocity *= 1f - Main.rand.NextFloat(0.45f);
                new4Velocity *= 1f - Main.rand.NextFloat(0.25f);
                new5Velocity *= 1f - Main.rand.NextFloat(0.25f);
                new6Velocity *= 1f - Main.rand.NextFloat(0.55f);
                new7Velocity *= 1f - Main.rand.NextFloat(0.22f);

                type = ModContent.ProjectileType<DragonSpawnShadow>();
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawnShadow>();
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawnShadow>();
                Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<OilBallRanged>();
                Projectile.NewProjectileDirect(source, position, new4Velocity*1.25f, type, (int)(damage*1.66f), knockback, player.whoAmI);
                type = ProjectileID.BlackBolt;
                Projectile.NewProjectileDirect(source, position, new5Velocity*1.5f, type, (int)(damage * 1.66f), knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawnShadow>();
                Projectile.NewProjectileDirect(source, position, new6Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawnShadow>();
                Projectile.NewProjectileDirect(source, position, new7Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawnShadow>();
                Projectile.NewProjectileDirect(source, position, new8Velocity, type, damage, knockback, player.whoAmI);

            }

            return true; // Return false because we don't want tModLoader to shoot projectile
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Burns all enemies in front of you with a storm of shadowflame sparks");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Also augmented with an explosive shot of dark energy and a large oil ball")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);



            // Here we will hide all tooltips whose title end with ':RemoveMe'
            // One like that is added at the start of this method
            foreach (var l in tooltips)
            {
                if (l.Name.EndsWith(":RemoveMe"))
                {
                    l.Hide();
                }
            }

            // Another method of hiding can be done if you want to hide just one line.
            // tooltips.FirstOrDefault(x => x.Mod == "ExampleMod" && x.Name == "Verbose:RemoveMe")?.Hide();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.OnyxBlaster);
            recipe.AddIngredient<SawedOffSparkplug>();
            recipe.AddIngredient<PlutoniumBar>(15);

            recipe.AddIngredient<Shadowflame>(35);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("DarkMatter", out ModItem DarkMatter))


            {
               

                recipe.AddIngredient(DarkMatter.Type, 10);
            }





        }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9.5f, -2f);
        }
    }
}