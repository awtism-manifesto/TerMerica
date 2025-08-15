using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using gunrightsmod.Content.DamageClasses;

namespace gunrightsmod.Content.Items
{
    public class KevlarWhip : ModItem
    {
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DildoWhipBuff.TagDamage);

        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<KevlarWhipProj>(), 33, 4, 7f);
            Item.rare = ItemRarityID.Orange;
            Item.damage = 33;
            Item.useTime = 29;
            Item.useAnimation = 29;
            Item.knockBack = 3;
            Item.ArmorPenetration = 12;
            Item.width = 14;
            Item.height = 14;
            Item.value = 10000;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "6 summon tag damage");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "ignores 12 enemy armor")
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
            recipe.AddIngredient(ItemID.BlandWhip);
            recipe.AddIngredient<Items.Kevlar>(10);
            recipe.Register();
        }

        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}