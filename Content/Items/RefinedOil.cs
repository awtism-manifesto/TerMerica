using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class RefinedOil : ModItem
    {

        public override void SetStaticDefaults()
        {
            // Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)



            Item.ResearchUnlockCount = 99; // Configure the amount of this item that's needed to research it in Journey mode.
        }

        public override void SetDefaults()
        {
            Item.damage = 11; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;
            
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 0.5f;
            Item.value = 11500;
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ProjectileID.Flames;
            Item.shootSpeed = 0f; // The speed of the projectile.
            Item.ammo = AmmoID.Gel; // The ammo class this ammo belongs to.
        }
       
        

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Usable as ammo in flamethrowers");
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
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(5);

            recipe.AddIngredient<Items.CrudeOil>(10);
            recipe.AddIngredient(ItemID.LivingFireBlock);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

           
            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind<ModItem>("FireDiamond", out ModItem FireDiamond))
            {
                recipe = CreateRecipe(8);
                recipe.AddIngredient<Items.CrudeOil>(10);
                recipe.AddIngredient(ItemID.LivingFireBlock);
                recipe.AddIngredient(FireDiamond.Type);
                
                recipe.AddTile(TileID.AdamantiteForge);

                recipe.Register();
            }



        }
    }
}