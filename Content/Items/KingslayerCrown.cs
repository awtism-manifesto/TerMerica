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
    [AutoloadEquip(EquipType.Head)]
    public class KingslayerCrown : ModItem
    {


        public override void SetStaticDefaults()
        {
            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;

            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;

        }



        public override void SetDefaults()
        {
            Item.width = 22; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(silver: 66); // How many coins the item is worth
            Item.rare = ItemRarityID.Blue; // The rarity of the item
            Item.accessory = true;
            Item.vanity = true;
            
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldCrown);
            recipe.AddIngredient<Items.KingslayerBar>(2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();


            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PlatinumCrown);
            recipe.AddIngredient<Items.KingslayerBar>(2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient<Items.KingslayerBar>(5);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

           



        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
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
        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
       
        
       
    }
}