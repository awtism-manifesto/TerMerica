using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class OtherworldPoisoning : ModBuff
    {

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;



        }



        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = (int)(player.lifeRegen - 625f);
           
           
        }
    }
}