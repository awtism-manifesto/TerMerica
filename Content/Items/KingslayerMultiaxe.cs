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
    public class KingslayerMultiaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 23;
            Item.DamageType =  DamageClass.Melee;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 9;
            Item.useAnimation = 22;
           
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6.5f;
            Item.scale = 1.2f;
            Item.value = Item.buyPrice(gold: 7); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost = 1;
            Item.pick = 63;
            Item.hammer = 79;
            Item.axe = 20;
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Can mine Lycopite");
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
            recipe.AddIngredient<Items.GoldMultiaxe>();
            recipe.AddIngredient<Items.KingslayerBar>(6);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient<Items.PlatinumMultiaxe>();
            recipe.AddIngredient<Items.KingslayerBar>(6);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();





        }

    }
}