using gunrightsmod.Content.DamageClasses;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class YelmutsHelmet : ModItem
    {
        public static readonly int MeleeAttackSpeedBonus = 7;
        public static readonly int MaxManaIncrease = 30;
        public static readonly int StupidArmorPenBonus = 4;
        public static readonly int RangedCritBonus = 7;
        public static readonly int ThrowingDamageBonus = 6;
        public static readonly int AdditiveSummonDamageBonus = 5;
        public static readonly int MaxMinionIncrease = 1;


        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
          
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs();
        }

        public override void SetDefaults()
        {
            Item.width = 22; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 5); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 3; // The amount of defense the item will give when equipped
           
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "+7% increased melee speed and ranged crit chance");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "+30 max mana")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "+5% summon damage and +4 stupid armor penetration")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
           
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))


            {

                line = new TooltipLine(Mod, "Face", "TerMerica Cross-Mod (Thorium) - 5% increased throwing damage")
                {
                    OverrideColor = new Color(34, 221, 240)
                };
                tooltips.Add(line);
            }

            line = new TooltipLine(Mod, "Face", "-Contributor Item-")
            {
                OverrideColor = new Color(220, 40, 245)
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
        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.RichMahoganyBreastplate  && legs.type == ItemID.RichMahoganyGreaves;
        }
        public override void UpdateEquip(Player player)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))


            {

                player.GetDamage(DamageClass.Throwing) += ThrowingDamageBonus / 106f;
            }
            player.GetAttackSpeed(DamageClass.Melee) += MeleeAttackSpeedBonus / 108f;
            player.statManaMax2 += MaxManaIncrease;
            player.GetDamage(DamageClass.Summon) += AdditiveSummonDamageBonus / 105f;
            //player.GetCritChance<StupidDamage>() += StupidCritBonus;
            player.GetCritChance(DamageClass.Ranged) += RangedCritBonus;
            player.GetArmorPenetration<StupidDamage>() += StupidArmorPenBonus;
        }
        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RichMahogany, 20);
            recipe.AddIngredient(ItemID.Fireblossom, 6);
            recipe.AddIngredient(ItemID.Deathweed, 6);
            recipe.AddIngredient(ItemID.Feather, 4);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.statDefense += 1;
            player.maxMinions += MaxMinionIncrease;
            player.setBonus = SetBonusText.Value;
           
        }
    }
}