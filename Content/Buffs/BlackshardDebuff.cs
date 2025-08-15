using gunrightsmod.Content.DamageClasses;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class BlackshardDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
           
            if (Main.rand.NextBool(2)) 
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.WhiteTorch,
                    npc.velocity.X * 1.5f, npc.velocity.Y * 1.5f, 70, default, 3f);
                Main.dust[dust].noGravity = true;
            }
        }


    }
}