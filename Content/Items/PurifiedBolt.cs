using Microsoft.Build.Evaluation;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    // This example is similar to the Wooden Arrow item
    public class PurifiedBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 36;

            Item.damage = 13; // Keep in mind that the arrow's final damage is combined with the bow weapon damage.
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Pink;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(copper: 122);
            Item.shoot = ModContent.ProjectileType<Projectiles.PurifiedBoltProj>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 4.7f; // The speed of the projectile.
            Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Flies incredibly fast");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Gains damage as it pierces more enemies")
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
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient<Items.PurifiedSalt>();
            recipe.AddIngredient<Items.CrossbowBolt>(25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

           



        }

    }
}