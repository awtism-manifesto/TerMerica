using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Items;

namespace gunrightsmod.Content.Global
{
    public class PlantDrops : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            // Check if the tile destroyed is a leaf tile
            if (type == TileID.CorruptThorns || type == TileID.CrimsonThorns)
            {
                if (!fail && !effectOnly)
                {
                    // Roll a 1 in 25 chance
                    if (Main.rand.Next(20) == 0)
                    {
                        // Spawn your custom item at the tile position
                        Item.NewItem(null, i * 16, j * 16, 16, 16, ModContent.ItemType<WeedLeaves>());
                    }
                }
            }
            // Check if the tile destroyed is a leaf tile
            if (type == TileID.CorruptVines || type == TileID.CrimsonVines)
            {
                if (!fail && !effectOnly)
                {
                    // Roll a 1 in 25 chance
                    if (Main.rand.Next(30) == 0)
                    {
                        // Spawn your custom item at the tile position
                        Item.NewItem(null, i * 16, j * 16, 16, 16, ModContent.ItemType<WeedLeaves>());
                    }
                }
            }
        }
    }
}