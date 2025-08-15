using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace gunrightsmod.Content.Tiles
{
    public class PlutoniumGlassTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
           
           
            
            DustType = DustID.PurpleTorch;
            HitSound = SoundID.Shatter;
            AddMapEntry(new Color(215, 171, 255));
        }


        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 2 : 5;
        }
    }
}