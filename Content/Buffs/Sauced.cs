using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class Sauced : ModBuff
    {
        public static readonly int DefenseBonus = 6;
       

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += DefenseBonus; // Grant a +10 defense boost to the player while the buff is active.
            
        }
    }
}