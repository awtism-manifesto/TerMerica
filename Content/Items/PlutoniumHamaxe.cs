using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using gunrightsmod.Content.Rarities;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class PlutoniumHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType =  DamageClass.Melee;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 9;
            Item.useAnimation = 19;
           
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 8.5f;

            Item.value = 190000; // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            
            
            Item.hammer = 115;
            Item.axe = 29;
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
        


        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();



            recipe.AddIngredient<Items.PlutoniumBar>(15);
            
            
            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
            
        }
    }
}