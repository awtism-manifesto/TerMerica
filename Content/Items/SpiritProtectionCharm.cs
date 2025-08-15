using gunrightsmod.Content.DamageClasses;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class SpiritProtectionCharm : ModItem
    {
        // By declaring these here, changing the values will alter the effect, and the tooltip

        
        
        
        public static readonly int MagicCritBonus = 5;
        public static readonly int MaxManaIncrease = 50;
        // Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations


        public override void SetDefaults()
        {
            Item.width = 45;
            Item.height = 30;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = 99000;
            Item.defense = 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ManaRegenerationBand);
            recipe.AddIngredient<Items.SaltPendant>();
            recipe.AddIngredient<Items.PurifiedSalt>(99);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind("EmpoweredManaCrystal", out ModItem EmpoweredManaCrystal))


            {
                recipe.AddIngredient(EmpoweredManaCrystal.Type);


            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "5% reduced damage taken");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "+5% magic crit chance and +50 mana")
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

            player.GetCritChance(DamageClass.Magic) += MagicCritBonus;
            player.statManaMax2 += MaxManaIncrease;
            player.endurance = 1f - (0.95f * (1f - player.endurance));
        }
    }
}