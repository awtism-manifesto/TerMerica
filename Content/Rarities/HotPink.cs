using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Rarities
{
    public class HotPink : ModRarity
    {
        public override Color RarityColor => new Color(188, 45, 0);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset > 0)
            { // If the offset is 1 or 2 (a positive modifier).
               return ModContent.RarityType<Seizure>();  // Make the rarity of items that have this rarity with a positive modifier the higher tier one.
            }
            if (offset > 1)
            { // If the offset is 1 or 2 (a positive modifier).
                return ModContent.RarityType<Seizure2>();  // Make the rarity of items that have this rarity with a positive modifier the higher tier one.
            }

            return ItemRarityID.Purple;  // no 'lower' tier to go to, so return the type of this rarity.
        }
    }
}