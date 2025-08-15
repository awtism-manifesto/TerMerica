using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace gunrightsmod.Content.Global
{
    // Very simple drop condition: drop during daytime
    public class HardmodeDrop : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public HardmodeDrop()
        {
            Description ??= Language.GetOrRegister("Drops in Hardmode");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return Main.hardMode;
        }

        public bool CanShowItemDropInUI()
        {
            return Main.hardMode;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
}