using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace gunrightsmod.Content.Global
{
    // Very simple drop condition: drop during daytime
    public class PostMoonlordDrop : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public PostMoonlordDrop()
        {
            Description ??= Language.GetOrRegister("Drops after defeating moon lord");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return NPC.downedMoonlord;
        }

        public bool CanShowItemDropInUI()
        {
            return NPC.downedMoonlord;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
}