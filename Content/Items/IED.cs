using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class IED : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 66; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.width = 13;
            Item.height = 13;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 7f;
            Item.value = 22000;
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ModContent.ProjectileType<IedThrown>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 13.25f; // The speed of the projectile.

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                Item.DamageType = DamageClass.Throwing;
            }
        }
       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Throws a dangerous IED that has a chance to randomly go off at any point");
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "Does not damage tiles or the player, deals extra damage on direct hits")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "'IMPROVISED?? I'll have you know I spent several hours meticulously crafting this with high quality materials'")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

        
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Thorium): Now deals Throwing damage") { OverrideColor = Color.LightSeaGreen });
            }


        

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
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.CobaltBar, 2);
            recipe.AddIngredient(ItemID.Wire, 3);
            recipe.AddIngredient(ItemID.Dynamite, 3);
            recipe.AddIngredient<RefinedOil>(5);
            recipe.Register();
            recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.PalladiumBar, 2);
            recipe.AddIngredient(ItemID.Wire, 3);
            recipe.AddIngredient(ItemID.Dynamite, 3);
            recipe.AddIngredient<RefinedOil>(5);
            recipe.Register();

        }
    }



}
