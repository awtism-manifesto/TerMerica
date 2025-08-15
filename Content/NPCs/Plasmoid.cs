using gunrightsmod.Content.Global;
using gunrightsmod.Content.Items;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace gunrightsmod.Content.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class Plasmoid : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Pixie];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Pixie;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }
        
        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 48;
            NPC.defense = 3;
            NPC.lifeMax = 395;
            NPC.HitSound = SoundID.NPCHit44;
            NPC.DeathSound = SoundID.NPCDeath39;
            NPC.value = 10000f;
            NPC.knockBackResist = 0.31f;
            NPC.aiStyle = 14; // slime ai

            AIType = NPCID.CaveBat; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.Pixie; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
           

        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
			
				

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("\"These odd, barely-corporeal creatures appear to feed on radiation. Their intelligence level is unknown\" "),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {


            npcLoot.Add(ItemDropRule.Common(ItemID.FallenStar, 4, 2, 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UraniumOre>(),1,34, 69));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlasmoidWand>(), 15));
            npcLoot.Add(ItemDropRule.ByCondition(new HardmodeDrop(), ModContent.ItemType<RadBullet>(),4, 40, 120));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if ( NPC.downedMechBoss1 & NPC.downedMechBoss2 & NPC.downedMechBoss3 & NPC.downedEmpressOfLight)
            {
                return SpawnCondition.Sky.Chance * 0.13f;
            }
            if ( NPC.downedMechBoss1 & NPC.downedMechBoss2 & NPC.downedMechBoss3)
            {
                return SpawnCondition.Sky.Chance * 0.15f;
            }
            if (NPC.downedDeerclops & NPC.downedBoss2)
            {
                return SpawnCondition.Sky.Chance * 0.51f;
            }
            if (NPC.downedDeerclops)
            {
                return SpawnCondition.Sky.Chance * 0.43f;
            }

            if (NPC.downedBoss2)
            {
                return SpawnCondition.Sky.Chance * 0.43f;
            }
          
            else
                return SpawnCondition.Sky.Chance * 0.00f;

        }

    }
}