using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using gunrightsmod.Content.Items;
using Newtonsoft.Json.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace gunrightsmod.Content.Items
{
    /// <summary>
    /// A potion that applies the ExampleWeaponImbue buff to the player.
    /// See also ExampleWeaponImbue and ExampleWeaponEnchantmentPlayer.
    /// </summary>
    public class FlaskOfOil : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;

            ItemID.Sets.DrinkParticleColors[Type] = [
                new Color(24, 20, 20),
                new Color(0, 20, 20),
                new Color(10, 10, 40)
            ];
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Melee and Whip attacks inflict enemies with Oiled");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'Crude oil. I can't stop drinking it, i can't stop guzzling crude oil.'")
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

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.width = 14;
            Item.height = 24;
            Item.buffType = ModContent.BuffType<WeaponImbueOil>();
            Item.buffTime = Item.flaskTime;
            Item.value = Item.sellPrice(0, 0, 5);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient<Items.CrudeOil>(5)
                .AddTile(TileID.ImbuingStation)
                .Register();
        }
    }
}