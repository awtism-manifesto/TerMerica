using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace gunrightsmod.Content.Tiles
{
    public class SovietFlagPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };

            AddMapEntry(new Color(142, 142, 142), Language.GetText("Flag")); // localized text for "Metal Bar"
        }
    }
}