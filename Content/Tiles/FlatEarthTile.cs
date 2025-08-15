using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace gunrightsmod.Content.Tiles
{
    public class FlatEarthTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 400;
            DustType = DustID.CursedTorch;
            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(45, 200, 178));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {

            r = 0.1f;
            g = 0.95f;
            b = 0.85f;

        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}