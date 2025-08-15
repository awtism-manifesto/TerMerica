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
    public class FerrousThornSmooth : ModItem
    {
        

        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<FerroWhipSmooth>(), 33, 9, 5.15f, 27);
            Item.rare = ItemRarityID.LightRed;
            Item.damage = 54;
            Item.useTime = 27;
            Item.useAnimation = 27;
            Item.knockBack = 5.75f;
            Item.ArmorPenetration = 1;
            Item.width = 18;
            Item.height = 18;
            Item.value = 90000;
           
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "14 summon tag damage");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Variants can freely be crafted between each other")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "Smooth variant: Higher speed and tag damage, but lower direct damage and no base armor penetration")
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

            recipe = CreateRecipe();

            recipe.AddIngredient<Items.FerrousThornSpiky>();


            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 15);
            recipe.AddIngredient<Items.CrudeOil>(35);
            recipe.AddIngredient<Items.RefinedOil>(35);
            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
           

        }

        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}