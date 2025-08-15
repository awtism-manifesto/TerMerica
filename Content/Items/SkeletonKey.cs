using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Tile_Entities;
using Terraria.ModLoader;
using Terraria;

namespace gunrightsmod.Content.Items
{
    public class SkeletonKey : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.
            Item.CloneDefaults(ItemID.GoldenKey);
            // Common Properties
            Item.width = 32; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.value = 350000;
            Item.maxStack = 1;
           
            Item.consumable = false;

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Opens nothing lol");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'Chaotic energy pulsates from the key'")
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
            Recipe
                 recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.BoneKey);
            recipe.AddIngredient(ItemID.Bone, 10);

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();




            
           
           




        }


    }

}