using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class OtherworldlySixPack : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(255, 120, 255),
                new Color(111, 245, 6),
                new Color(122, 251, 114)
            };
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.buyPrice(silver: 11500);
            Item.buffType = ModContent.BuffType<Buffs.OtherworldPoisoning>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 69000; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Grants an otherworldly set of buffs to the player");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'WARNING: effects have NOT been tested in this universe'")
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
        
       
    }
}
    
