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
    public class SawedOffSparkplug : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.1f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.value = Item.buyPrice(silver: 705);


            // Use Properties
            Item.useTime = 33; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 33; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = SoundID.Item74;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 39; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 6.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.ArmorPenetration = 5;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ModContent.ProjectileType<OilBallRanged>();

            Item.shootSpeed = 17.5f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = ItemID.MusketBall;


        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.DragonSpawn>();
            SoundEngine.PlaySound(SoundID.Item38, player.position);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                
                Vector2 newVelocity = velocity.RotatedBy(MathHelper.ToRadians(28.5f));
                Vector2 new2Velocity = velocity.RotatedBy(MathHelper.ToRadians(-28.5f));
                Vector2 new3Velocity = velocity.RotatedBy(MathHelper.ToRadians(13.5f));
                Vector2 new5Velocity = velocity.RotatedBy(MathHelper.ToRadians(-13.5f));
                Vector2 new4Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3.5f));
              

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.45f);
                new2Velocity *= 1f - Main.rand.NextFloat(0.45f);
                new3Velocity *= 1f - Main.rand.NextFloat(0.45f);
                new4Velocity *= 1f - Main.rand.NextFloat(0.25f);

                type = ModContent.ProjectileType<DragonSpawn>();
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawn>();
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawn>();
                Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<OilBallRanged>();
                Projectile.NewProjectileDirect(source, position, new4Velocity, type, (int)(damage*1.66f), knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawn>();
                Projectile.NewProjectileDirect(source, position, new5Velocity, type, damage, knockback, player.whoAmI);
            }

            return true; // Return false because we don't want tModLoader to shoot projectile
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Converts bullets into sparks that go flying everywhere");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Also shoots a large ball of oil that makes enemies more vulnerable to the flame")
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
            recipe.AddIngredient<RefinedOil>(50);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.Boomstick);
            
           
           
           
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind("SparkSpreader", out ModItem SparkSpreader))
            {
                recipe.AddIngredient(SparkSpreader.Type);

            }



            }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -1f);
        }
    }
}