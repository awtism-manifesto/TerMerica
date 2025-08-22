using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class BalkanRagePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(195, 32, 102),
                new Color(17, 155, 11),
                new Color(91, 21, 224)
            };
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(silver: 20);
            Item.buffType = ModContent.BuffType<Buffs.BalkanRage>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 21600; // Ticks
        }
       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "those who know...")
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
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {

            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind("LeadskinPotion", out ModItem LeadskinPotion))


            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(LeadskinPotion.Type);
                recipe.AddIngredient< WeedLeaves>();
                recipe.AddIngredient< PurifiedSalt>();
                recipe.AddIngredient< UraniumOre>();
                recipe.AddTile(TileID.Bottles);
                recipe.Register();

                recipe = CreateRecipe();
                recipe.AddIngredient(LeadskinPotion.Type);
                recipe.AddIngredient< WeedLeaves>();
                recipe.AddIngredient< PurifiedSalt>();
                recipe.AddIngredient< UraniumOre>();
                recipe.AddTile(TileID.AlchemyTable);
                recipe.Register();
               


            }
            else
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.BottledWater);
                recipe.AddIngredient< WeedLeaves>();
                recipe.AddIngredient< PurifiedSalt>();
                recipe.AddIngredient< UraniumOre>();
                recipe.AddTile(TileID.Bottles);
                recipe.Register();

                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.BottledWater);
                recipe.AddIngredient< WeedLeaves>();
                recipe.AddIngredient< PurifiedSalt>();
                recipe.AddIngredient< UraniumOre>();
                recipe.AddTile(TileID.AlchemyTable);
                recipe.Register();



            }
           
        }

    }
}

