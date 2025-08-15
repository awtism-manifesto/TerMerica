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
    public class StupiderFuckingPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 999999;
            Item.DamageType = ModContent.GetInstance<StupidDamage>();
            Item.width = 100;
            Item.height = 100;
            Item.useTime = 1;
            Item.useAnimation = 10;
            Item.scale = 2.5f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.crit = 69416;
            Item.ArmorPenetration = 999;
            Item.value = Item.buyPrice(gold: 147860);
            Item.rare = ModContent.RarityType<HotPink>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost = 696969;
            Item.pick = 3000; // How strong the pickaxe is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "WARNING: DISABLE SMART CURSOR BEFORE HOLDING THIS ITEM");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "I'm gonna disassemble your molecules!")
            {
                OverrideColor = new Color(55, 70, 254)
            };
            tooltips.Add(line);
        }

      
       

        }
    }
