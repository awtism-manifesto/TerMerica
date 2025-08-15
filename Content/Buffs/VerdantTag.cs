using gunrightsmod.Content.DamageClasses;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class VerdantTag : ModBuff
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
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.PoisonStaff,
                    npc.velocity.X * 0.96f, npc.velocity.Y * 0.96f, 70, default, 2.15f);
                Main.dust[dust].noGravity = true;
            }
        }


    }
}