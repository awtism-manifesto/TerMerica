using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class PermafrostDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 13; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;

            Item.width = 11;
            Item.height = 11;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 4.5f;
            Item.value = 80;
            Item.rare = ItemRarityID.Pink;
            Item.shoot = ModContent.ProjectileType<FrostDart>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 5.8f; // The speed of the projectile.
            Item.ammo = AmmoID.Dart; // The ammo class this ammo belongs to.
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Causes a small explosion and shatters into frost chunks on impact")
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

            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind("EssenceofEleum", out ModItem EssenceofEleum))
            {
                recipe = CreateRecipe(100);

               
                recipe.AddIngredient(EssenceofEleum.Type, 5);
               
                recipe.Register();
            }
           
            {
                recipe = CreateRecipe(350);
                recipe.AddIngredient(ItemID.FrostCore);

                recipe.Register();
            }
        }

    }
}


