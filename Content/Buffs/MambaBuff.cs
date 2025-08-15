using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class MambaBuff : ModBuff
    {

        public static readonly int MoveSpeedBonus = 30;

       // player.wingTimeMax += 115;
           // player.jumpSpeedBoost += 1.15f;
           // player.maxFallSpeed = player.maxFallSpeed* 1.05f;
           // player.wingRunAccelerationMult += 1.2f;
           // player.wingAccRunSpeed += 1.2f;

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = (int)(player.lifeRegen + 4f);
            player.moveSpeed += MoveSpeedBonus / 130f;
            player.runAcceleration *= 1.25f;
            player.wingRunAccelerationMult += 1.2f;
        }
    }
}