using gunrightsmod.Content.DamageClasses;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class BrainRotted : ModBuff
    {
        public static readonly int AdditiveStupidDamageBonus = 10;


        public override LocalizedText Description => base.Description.WithFormatArgs(AdditiveStupidDamageBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage<StupidDamage>() += AdditiveStupidDamageBonus / 110f;

        }
    }
}