using gunrightsmod.Content.DamageClasses;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class DoombringerSigil : ModItem
    {
        // By declaring these here, changing the values will alter the effect, and the tooltip

        public static readonly int AdditiveDamageBonus = 15;
        public static readonly int CritBonus = 7;
        public static readonly int ArmorPenBonus = 5;
        public static readonly int OmniCritBonus = -15;
        public static readonly int AttackSpeedBonus = 7;
        public static readonly int OmniAttackSpeedBonus = -17;
        public static readonly int OmniArmorPenBonus = -10;

        // Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveDamageBonus);
        public override void SetStaticDefaults()
        {
            // Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)


           
            ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the item have no gravity

           
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;
            Item.value = 4900000;
        }
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Increases melee, ranged, magic, summon, and stupid damage by 15%");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Increases melee, ranged, magic, summon, and stupid crit chance and attack speed by 7%")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Increases melee, ranged, magic, summon, and stupid armor penetration by 5")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Slightly less effective with Omni-class weapons")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))


            {

                line = new TooltipLine(Mod, "Face", "TerMerica Cross-Mod (Thorium) - Also grants the same stat increases to Throwing class")
                {
                    OverrideColor = new Color(34, 221, 240)
                };
                tooltips.Add(line);
            }
            line = new TooltipLine(Mod, "Face", "'Epicenter of entropy'")
            {
                OverrideColor = new Color(Main.rand.Next(166), Main.rand.Next(166), Main.rand.Next(166))
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
            recipe.AddIngredient(ItemID.CelestialSigil);
            recipe.AddIngredient<Items.RadioactiveEmblem>();
            recipe.AddIngredient<Items.AmalgamatedFragment>();
          

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("AscendantSpiritEssence", out ModItem AscendantSpiritEssence))


            {
                recipe.AddIngredient(AscendantSpiritEssence.Type, 5);


            }

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
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
            player.GetDamage(DamageClass.Melee) += AdditiveDamageBonus / 115f;
            player.GetDamage(DamageClass.Ranged) += AdditiveDamageBonus / 115f;
            player.GetDamage(DamageClass.Magic) += AdditiveDamageBonus / 115f;
            player.GetDamage(DamageClass.Summon) += AdditiveDamageBonus / 115f;   
            player.GetDamage<StupidDamage>() += AdditiveDamageBonus / 115f;
            player.GetDamage<OmniDamage>() -= AdditiveDamageBonus / 72f;

            player.GetCritChance<OmniDamage>() += OmniCritBonus;
            player.GetCritChance<StupidDamage>() += CritBonus;
            player.GetCritChance(DamageClass.Melee) += CritBonus;
            player.GetCritChance(DamageClass.Ranged) += CritBonus;
            player.GetCritChance(DamageClass.Magic) += CritBonus;
            player.GetCritChance(DamageClass.Summon) += CritBonus;


            player.GetAttackSpeed(DamageClass.Melee) += AttackSpeedBonus / 107f;
            player.GetAttackSpeed(DamageClass.Ranged) += AttackSpeedBonus / 107f;
            player.GetAttackSpeed(DamageClass.Magic) += AttackSpeedBonus / 107f;
            player.GetAttackSpeed(DamageClass.Summon) += AttackSpeedBonus / 107f;
            player.GetAttackSpeed<StupidDamage>() += AttackSpeedBonus / 107f;
            player.GetAttackSpeed<OmniDamage>() -= AttackSpeedBonus / 92f;

            player.GetArmorPenetration(DamageClass.Melee) += ArmorPenBonus;
            player.GetArmorPenetration(DamageClass.Ranged) += ArmorPenBonus;
            player.GetArmorPenetration(DamageClass.Magic) += ArmorPenBonus;
            player.GetArmorPenetration(DamageClass.Summon) += ArmorPenBonus;
            player.GetArmorPenetration<StupidDamage>() += ArmorPenBonus;
            player.GetCritChance<OmniDamage>() += OmniArmorPenBonus;

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))


            {
                player.GetDamage(DamageClass.Throwing) += AdditiveDamageBonus / 115f;
                player.GetAttackSpeed(DamageClass.Throwing) += AttackSpeedBonus / 107f;
                player.GetCritChance(DamageClass.Throwing) += CritBonus;
                player.GetArmorPenetration(DamageClass.Throwing) += ArmorPenBonus;
            }
        }
    }
}
