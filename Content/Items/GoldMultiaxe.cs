using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class GoldMultiaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType =  DamageClass.Melee;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 10;
            Item.useAnimation = 25;
           
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5;
            Item.scale = 1.2f;
            Item.value = Item.buyPrice(gold: 4); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost = 1;
            Item.pick = 60;
            Item.hammer = 75;
            Item.axe = 18;
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
        }
        

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.GoldBar, 11);
            recipe.AddIngredient(ItemID.GoldAxe);
            recipe.AddIngredient(ItemID.GoldHammer);
            recipe.AddIngredient(ItemID.GoldPickaxe);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

           




        }

    }
}