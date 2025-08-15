using gunrightsmod.Content.DamageClasses;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class RedneckTag : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            // Dust ID 5 = Blood
            if (Main.rand.NextBool(3)) // 1-in-3 chance every tick
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood,
                    npc.velocity.X * 1.31f, npc.velocity.Y * 1.31f, 70, default, 2.5f);
                Main.dust[dust].noGravity = true;
            }
        }


    }
}