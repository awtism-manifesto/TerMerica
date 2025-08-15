using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace gunrightsmod.Content.Tiles
{
    public class AstatineOrePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileMerge[TileID.Dirt][Type] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileMerge[TileID.Ebonstone][Type] = true;
            Main.tileMerge[TileID.Crimstone][Type] = true;
            Main.tileMerge[TileID.Pearlstone][Type] = true;
            Main.tileMerge[TileID.LivingFire][Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 400;
            DustType = DustID.CrimsonTorch;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(156, 42, 65));

            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileLighted[Type] = true;

        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {

            r = 1f;
            g = 0.1f;
            b = 0.285f;

        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 2 : 5;
        }
    }
}