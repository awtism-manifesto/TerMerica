using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class LaserCharge : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 11; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;
            Item.ArmorPenetration = 2;
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 0.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<ChargeLaser>();
            Item.shootSpeed = 15f; // The speed of the projectile.
            Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
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

            line = new TooltipLine(Mod, "Face", "Emits high velocity lasers instead of bullets")
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
            Recipe recipe = CreateRecipe(250);
            recipe.AddIngredient(ItemID.CopperBar, 5);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe(250);
            recipe.AddIngredient(ItemID.TinBar, 5);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}