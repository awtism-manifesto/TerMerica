using gunrightsmod.Content.DamageClasses;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class BalkanRage : ModBuff
    {
        public static readonly int AttackSpeedBonus = 6;
        public static readonly int CritBonus = 12;
        public static readonly int DefenseBonus = -6;




        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Generic) += CritBonus;
            player.GetAttackSpeed(DamageClass.Generic) += AttackSpeedBonus / 105f;
            player.statDefense += DefenseBonus; // Grant a +10 defense boost to the player while the buff is active.
        }
    }
}