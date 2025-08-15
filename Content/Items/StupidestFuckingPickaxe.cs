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
    public class StupidestFuckingPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 9999999;
            Item.DamageType = ModContent.GetInstance<StupidDamage>();
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 1;
            Item.useAnimation = 10;
            Item.ArmorPenetration = 99999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.crit = 69416;
            Item.value = Item.buyPrice(gold: 247861);
            Item.rare = ModContent.RarityType<HotPink>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost = 20;
            Item.pick = 9999; // How strong the pickaxe is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "I be placing blocks and shit 'cuz I'm in fucking Minecraft")
            {
                OverrideColor = new Color(70, 255, 70)
            };
            tooltips.Add(line);
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        
    }
}