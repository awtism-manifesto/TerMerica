using gunrightsmod.Content.DamageClasses;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    // This example is similar to the Wooden Arrow item
    public class EldritchArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 36;

            Item.damage = 19; // Keep in mind that the arrow's final damage is combined with the bow weapon damage.
            Item.DamageType = ModContent.GetInstance<RangedSummonDamage>();
            Item.rare = ItemRarityID.Cyan;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 5f;
            Item.ArmorPenetration = 5;
            Item.value = Item.sellPrice(silver: 1);
            Item.shoot = ModContent.ProjectileType<Projectiles.EldritchProj>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 2.5f; // The speed of the projectile.
            Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Large, devastating arrows that inflict Cursed Flames, Shadowflame,and Ichor");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "5 summon tag damage")
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
            Recipe recipe = CreateRecipe(666);
          
            recipe.AddIngredient(ItemID.CursedArrow, 222);
            recipe.AddIngredient<Items.ShadowflameArrow>(222);
            recipe.AddIngredient(ItemID.IchorArrow, 222);
            recipe.AddIngredient(ItemID.Ectoplasm, 3);
            recipe.Register();
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("CursedCloth", out ModItem CursedCloth))


            {
                recipe.AddIngredient(CursedCloth.Type, 2);


            }
        }

    }
}