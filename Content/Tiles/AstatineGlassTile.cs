using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace gunrightsmod.Content.Tiles
{
    public class AstatineGlassTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
           
           
            
            DustType = DustID.CrimsonTorch;
            HitSound = SoundID.Shatter;
            AddMapEntry(new Color(196, 62, 90));
        }


        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 2 : 5;
        }
    }
}