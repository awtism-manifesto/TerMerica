using gunrightsmod.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Global
{
    internal class DamageModificationGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool stamped;

        public override void ResetEffects(NPC npc)
        {
            stamped = false;
        }

        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (stamped)
            {
                // For best results, defense debuffs should be multiplicative
                modifiers.Defense *= Stamped.DefenseMultiplier;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            // This simple color effect indicates that the buff is active
            if (stamped)
            {
                drawColor.R = 255;
                drawColor.G = 5;
                drawColor.B = 5;   
            }
        }
    }
    internal class OrangeDebuff : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool orange;

        public override void ResetEffects(NPC npc)
        {
            orange = false;
        }

        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (orange)
            {
                // For best results, defense debuffs should be multiplicative
                modifiers.Defense *= LycopiteSpores.DefenseMultiplier;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            // This simple color effect indicates that the buff is active
            if (orange)
            {
                drawColor.R = 255;
                drawColor.G = 85;
                drawColor.B = 5;
            }
        }
    }


}