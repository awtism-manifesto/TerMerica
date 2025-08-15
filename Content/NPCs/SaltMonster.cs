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
    public class SaltMonster : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BloodZombie];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Demon;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 48;
            NPC.height = 64;
            NPC.damage = 44;
            NPC.defense = 10;
            NPC.lifeMax = 196;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 3000f;
            NPC.knockBackResist = 0.08f;
            NPC.aiStyle = 3; // slime ai

            AIType = NPCID.BloodZombie; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.BloodZombie; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
           

        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
			
				

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("\"A seemingly cobbled together monster made of pure rock salt. It is extremely hydrophobic and prefers desert environments.\" "),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RockSalt>(), 1, 11, 24));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Naclslash>(), 11));
            npcLoot.Add(ItemDropRule.ByCondition(new HardmodeDrop(), ItemID.LightShard, chanceDenominator: 149, chanceNumerator: 3));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SaltPendant>(), 7));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

           
            if (NPC.downedBoss1 & NPC.downedSlimeKing)
            {
                return SpawnCondition.DesertCave.Chance * 0.18f;
            }
            if (NPC.downedBoss1)
            {
                return SpawnCondition.DesertCave.Chance * 0.066f;
            }
            if (NPC.downedSlimeKing)
            {
                return SpawnCondition.DesertCave.Chance * 0.033f;
            }
            else
                return SpawnCondition.DesertCave.Chance * 0.00f;

        }

    }
}