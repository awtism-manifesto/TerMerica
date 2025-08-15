using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class DragonBreathShell : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 17; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;

            Item.width = 13;
            Item.height = 13;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 0f;
            Item.value = 30;
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ModContent.ProjectileType<DragonSpawn>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 7.25f; // The speed of the projectile.
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

            line = new TooltipLine(Mod, "Face", "Shoots a ton of flaming sparks out of your gun")
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
           
            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind<ModItem>("FireDiamond", out ModItem FireDiamond))
            {
                recipe = CreateRecipe(300);
                recipe.AddIngredient<Items.RefinedOil>();
                recipe.AddIngredient(FireDiamond.Type);
                recipe.AddIngredient<Items.PurifiedSalt>();
                recipe.AddIngredient(ItemID.EmptyBullet, 300);
                recipe.AddTile(TileID.Furnaces);

                recipe.Register();
            }
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("SoulofPlight", out ModItem SoulofPlight))


            {

                recipe = CreateRecipe(350);
                recipe.AddIngredient<Items.RefinedOil>();
                recipe.AddIngredient(SoulofPlight.Type);
                recipe.AddIngredient<Items.PurifiedSalt>();
                recipe.AddIngredient(ItemID.EmptyBullet, 350);
                recipe.AddTile(TileID.Furnaces);

                recipe.Register();

            }
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica2) && ThorMerica2.TryFind("SoulofPlight", out ModItem SoulofPlight2)
                && ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica2) && MagMerica.TryFind<ModItem>("FireDiamond", out ModItem FireDiamond2))


            {

                recipe = CreateRecipe(425);
                recipe.AddIngredient<Items.RefinedOil>();
                recipe.AddIngredient(SoulofPlight2.Type);
                recipe.AddIngredient<Items.PurifiedSalt>();
                recipe.AddIngredient(FireDiamond2.Type);
                recipe.AddIngredient(ItemID.EmptyBullet, 425);
                recipe.AddTile(TileID.Furnaces);

                recipe.Register();

            }
            else
            {
                recipe = CreateRecipe(175);
                recipe.AddIngredient<Items.RefinedOil>();
                recipe.AddIngredient<Items.PurifiedSalt>();
                recipe.AddIngredient(ItemID.EmptyBullet, 175);
                recipe.Register();
            }
        }
    }



}
