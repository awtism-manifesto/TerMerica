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
    [AutoloadEquip(EquipType.Body)]
    public class KingslayerBreastplate : ModItem
    {
        public static readonly int AdditiveSummonDamageBonus = 7;
        public static readonly int CritBonus = 7;
        public static readonly int MaxMinionIncrease = 1;
        public static readonly int MoveSpeedBonus = 6;
        public static readonly int AdditiveDamageBonus = 5;
        public static readonly int CritBonus2 = 5;
        public static readonly int ArmorPenetration = 3;
        public static readonly int AttackSpeedBonus = 3;
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;


            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs();
        }

        public override void SetDefaults()
        {
            Item.width = 32; // Width of the item
            Item.height = 28; // Height of the item
            Item.value = Item.sellPrice(gold: 10); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 8; // The amount of defense the item will give when equipped
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "7% increased crit chance and summon damage");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "+1 minion slot")
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
        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<KingslayerHelmet>() && legs.type == ModContent.ItemType<KingslayerGreaves>();
        }
        public override void UpdateEquip(Player player)
        {
            // GetDamage returns a reference to the specified damage class' damage StatModifier.
            // Since it doesn't return a value, but a reference to it, you can freely modify it with mathematics operators (+, -, *, /, etc.).
            // StatModifier is a structure that separately holds float additive and multiplicative modifiers, as well as base damage and flat damage.
            // When StatModifier is applied to a value, its additive modifiers are applied before multiplicative ones.
            // Base damage is added directly to the weapon's base damage and is affected by damage bonuses, while flat damage is applied after all other calculations.
            // In this case, we're doing a number of things:
            // - Adding 25% damage, additively. This is the typical "X% damage increase" that accessories use, use this one.
            // - Adding 12% damage, multiplicatively. This effect is almost never used in Terraria, typically you want to use the additive multiplier above. It is extremely hard to correctly balance the game with multiplicative bonuses.
            // - Adding 4 base damage.
            // - Adding 5 flat damage.
            // Since we're using DamageClass.Generic, these bonuses apply to ALL damage the player deals.
            player.GetDamage(DamageClass.Summon) += AdditiveSummonDamageBonus / 107f;
            player.maxMinions += MaxMinionIncrease;
            player.GetCritChance(DamageClass.Generic) += CritBonus;
          
        }
        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            
            recipe.AddIngredient<Items.KingslayerBar>(22);
            
            recipe.AddIngredient(ItemID.FlinxFurCoat);
          
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
        }
        public override void UpdateArmorSet(Player player)
        {

            if (NPC.AnyDanger())
                {



                player.statLifeMax2 = (int)(player.statLifeMax2 * 1.05f);
                player.GetDamage(DamageClass.Generic) += AdditiveDamageBonus / 105f;
                player.moveSpeed += MoveSpeedBonus / 108f;
                player.runAcceleration *= 1.1f;
                player.GetArmorPenetration(DamageClass.Generic) += ArmorPenetration;
                player.lifeRegen = (int)(player.lifeRegen + 2.5f);
                player.GetCritChance(DamageClass.Generic) += CritBonus2;
                player.GetAttackSpeed(DamageClass.Generic) += AttackSpeedBonus / 103f;
            }


           
            player.setBonus = SetBonusText.Value;
            
        }
    }
}