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
    [AutoloadEquip(EquipType.Legs)]
    public class AstatineGreaves : ModItem
    {

        public static readonly int MoveSpeedBonus = 35;
        public static readonly int AdditiveDamageBonus = 9;
        public static readonly int AdditiveThrowDamageBonus = 13;
        public static readonly int AttackSpeedBonus = 7;
        public static readonly int MaxMinionIncrease = 2;
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
            Item.value = Item.sellPrice(gold: 70); // How many coins the item is worth
            Item.rare = ItemRarityID.Red; // The rarity of the item
            Item.defense = 22; // The amount of defense the item will give when equipped
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "35% increased movement speed and 7% increased attack speed ");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "+2 max minions and 9% increased damage")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))


            {

                line = new TooltipLine(Mod, "Face", "13% increased throwing damage")
                {
                    OverrideColor = new Color(255, 255, 255)
                };
                tooltips.Add(line);
            }
            

            // Another method of hiding can be done if you want to hide just one line.
            // tooltips.FirstOrDefault(x => x.Mod == "ExampleMod" && x.Name == "Verbose:RemoveMe")?.Hide();
        }
        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<AstatineHelmet>() && body.type == ModContent.ItemType<AstatineBreastplate>();
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

            player.GetAttackSpeed(DamageClass.Generic) += AttackSpeedBonus / 107f;
            player.maxMinions += MaxMinionIncrease;
            player.GetDamage(DamageClass.Generic) += AdditiveDamageBonus / 109f;
            player.moveSpeed += MoveSpeedBonus / 135f;
            player.runAcceleration *= 1.35f;

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))


            {

                player.GetDamage(DamageClass.Throwing) += AdditiveDamageBonus / 113f;


            }

        }
        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient< AstatineBar>(40);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.armorEffectDrawShadow = true;

           
            player.armorEffectDrawOutlines = true;
            player.armorEffectDrawOutlinesForbidden = true;
            player.setBonus = SetBonusText.Value;
        }
        public class AstatinePants : ModPlayer
        {
            public bool AstatinePantys = false;

            public override void ResetEffects()
            {
                AstatinePantys = false;
            }

            public override void PostUpdateRunSpeeds()
            {
                // We only want our additional changes to apply if ExampleStatBonusAccessory is equipped and not on a mount.
                if (Player.mount.Active || !AstatinePantys)
                {
                    return;
                }

                
                Player.runAcceleration *= 1.35f; // Modifies player run acceleration
                Player.maxRunSpeed *= 1.35f;
                Player.accRunSpeed *= 1.35f;
                Player.runSlowdown *= 1.35f;
            }
        }
    }
}
