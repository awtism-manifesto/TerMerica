using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace gunrightsmod.Content.Tiles
{
    public class UraniumBrickTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 500;
            DustType = DustID.CursedTorch;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(89, 255, 119));



            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileLighted[Type] = true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {

            r = 0.6f;
            g = 1f;
            b = 0.6f;

        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}