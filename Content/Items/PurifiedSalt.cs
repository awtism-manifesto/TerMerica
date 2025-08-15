﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace gunrightsmod.Content.Items
{
    public class PurifiedSalt : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 32; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.22f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.value = 950;
            Item.maxStack = 9999;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "'cleansed of every impurity down to the atomic level'");
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
            Recipe recipe = CreateRecipe(9);

            recipe.AddIngredient(ItemID.PixieDust, 2);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient<Items.RockSalt>(9);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            




        }
    }
}