using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Items;

namespace gunrightsmod.Common.GlobalItems
{
    public class BossBagLoot : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            // In addition to this code, we also do similar code in Common/GlobalNPCs/ExampleNPCLoot.cs to edit the boss loot for non-expert drops. Remember to do both if your edits should affect non-expert drops as well.
            if (item.type == ItemID.KingSlimeBossBag)
            {
                // The following code is attempting to retrieve the ItemDropRule found in the ItemDropDatabase.RegisterBossBags method:
                // RegisterToItem(item, ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.BeeGun, ItemID.BeeKeeper, ItemID.BeesKnees));
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is OneFromOptionsNotScaledWithLuckDropRule oneFromOptionsDrop && oneFromOptionsDrop.dropIds.Contains(ItemID.KingSlimeMask))
                    {
                        var original = oneFromOptionsDrop.dropIds.ToList();
                        original.Add(ModContent.ItemType<SuperSamuraiSlicer>());
                        oneFromOptionsDrop.dropIds = original.ToArray();
                    }
                }
            }
        }
    }
}