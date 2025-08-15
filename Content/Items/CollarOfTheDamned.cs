using gunrightsmod.Content.DamageClasses;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Beard)]
    public class CollarOfTheDamned : ModItem
    {
       
        
        

       

        public override void SetDefaults()
        {
            Item.width = 22; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(silver: 666); // How many coins the item is worth
            Item.rare = ItemRarityID.Red; // The rarity of the item
            Item.accessory = true;
            Item.vanity = true;
            
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();


            recipe.AddIngredient(ItemID.PinkDye);
            recipe.AddIngredient(ItemID.CrabBanner);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
           






        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "'Attracts a strange shopkeeper when held in the inventory'");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "-Dedicated Item-")
            {
                OverrideColor = new Color(252, 141, 204)
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
        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
       
        
       
    }
}