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
    public class LargePlasmoidMessage1 : GlobalNPC
    {
        public override bool AppliesToEntity(NPC npc, bool lateInstantiation)
        {
            return npc.type == NPCID.SkeletronPrime;
        }

        public override void OnKill(NPC npc)
        {
            if (!NPC.downedMechBoss3 && NPC.downedMechBoss1 && NPC.downedMechBoss2)
            {

                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Strange purple blobs can be seen high up in the night sky..."), new Color(145, 5, 5));
            }

        }
    }
    public class LargePlasmoidMessage2 : GlobalNPC
    {
        public override bool AppliesToEntity(NPC npc, bool lateInstantiation)
        {
            return npc.type == NPCID.Retinazer;
        }

        public override void OnKill(NPC npc)
        {
            if (!NPC.downedMechBoss2 && NPC.downedMechBoss1 && NPC.downedMechBoss3)
            {

                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Strange purple blobs can be seen high up in the night sky..."), new Color(145, 5, 5));
            }

        }
    }
    public class LargePlasmoidMessage3 : GlobalNPC
    {
        public override bool AppliesToEntity(NPC npc, bool lateInstantiation)
        {
            return npc.type == NPCID.Spazmatism;
        }

        public override void OnKill(NPC npc)
        {
            if (!NPC.downedMechBoss2 && NPC.downedMechBoss1 && NPC.downedMechBoss3)
            {

                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Strange purple blobs can be seen high up in the night sky..."), new Color(145, 5, 5));
            }

        }
    }
    public class LargePlasmoidMessage4 : GlobalNPC
    {
        public override bool AppliesToEntity(NPC npc, bool lateInstantiation)
        {
            return npc.type == NPCID.TheDestroyer;
        }

        public override void OnKill(NPC npc)
        {
            if (!NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {

                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Strange purple blobs can be seen high up in the night sky..."), new Color(145, 5, 5));
            }

        }
    }
}