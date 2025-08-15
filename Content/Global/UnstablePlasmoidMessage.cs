using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;
using static System.Net.Mime.MediaTypeNames;

namespace gunrightsmod.Content.Global
{
    public class UnstablePlasmoidMessage : GlobalNPC
    {
        public override bool AppliesToEntity(NPC npc, bool lateInstantiation)
        {
            return npc.type == NPCID.HallowBoss;
        }
        
        public override void OnKill(NPC npc)
        {
            if (!NPC.downedEmpressOfLight)
            {

                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Ominous red orbs can be seen looming high up in the night sky..."), new Color(185, 15, 15));
            }
            
        }
    }
}