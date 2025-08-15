using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    [AutoloadEquip(EquipType.Balloon)]
    public class CarbonDioxideCeram : ModItem
    {

        public override void SetDefaults()
        {
            Item.DefaultToAccessory(20, 26);
            Item.SetShopValues(ItemRarityColor.LightRed4, Item.buyPrice(silver: 799));
            Item.defense = 2;
        }

        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.GetJumpState<SimpleExtraJump>().Enable();
            player.jumpBoost = true;
            player.jumpSpeedBoost = 0.48f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient<Items.CarbonDioxideBalloon>();
            recipe.AddIngredient<Items.CeramicSheet>(25);

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Allows the player to double jump, and jump slightly higher");
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

    }
}
    