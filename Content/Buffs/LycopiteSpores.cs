using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using gunrightsmod.Content.Global;
using System.Drawing;



namespace gunrightsmod.Content.Buffs
{
    public class LycopiteSpores : ModBuff
    {
        public const int DefenseReductionPercent = (int)27.5f;
        public static float DefenseMultiplier = 0.725f;

        public override void SetStaticDefaults()
        {
            Main.pvpBuff[Type] = true; // This buff can be applied by other players in Pvp, so we need this to be true.

          
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<OrangeDebuff>().orange = true;
            
        }

        public override void Update(Player player, ref int buffIndex)
        {
            
            player.statDefense *= DefenseMultiplier;
        }
    }
}