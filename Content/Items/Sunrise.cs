using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.Localization;

using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using gunrightsmod.Content.Projectiles;


namespace gunrightsmod.Content.Items
{
    public class Sunrise : ModItem
    {
        
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.8f;
            Item.rare = ItemRarityID.Pink; // The color that the item's name will be in-game.
            Item.value = 150000;


            // Use Properties
            Item.useTime = 31; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 31; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.crit = 10;

            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item72;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 122; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 5.25f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
           


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.


            Item.shootSpeed = 11.75f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<SunDart>();


        }

       

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
           
            type = ModContent.ProjectileType<SunDart>();
        }
       

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Converts all darts into high velocity, burning sun darts");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
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

            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("AerialiteBar", out ModItem AerialiteBar)
                && CalMerica.TryFind("EssenceofSunlight", out ModItem EssenceofSunlight))
            {
                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.HallowedBar, 10);
                recipe.AddIngredient(AerialiteBar.Type, 10);
                recipe.AddIngredient<Items.LycopiteBar>(10);
                recipe.AddIngredient(EssenceofSunlight.Type, 6);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }
            else
            {
                recipe = CreateRecipe();
               
                recipe.AddIngredient(ItemID.HallowedBar, 12);
                recipe.AddIngredient(ItemID.HellstoneBar, 12);
                recipe.AddIngredient<Items.LycopiteBar>(10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

               

            }

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-28f, -1f);
        }
    }
}