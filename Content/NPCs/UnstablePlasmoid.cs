using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using gunrightsmod.Content.Items;

namespace gunrightsmod.Content.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class UnstablePlasmoid : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Harpy];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Pixie;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 60;
            NPC.height = 60;
            NPC.damage = 155;
            NPC.defense = 1;
            NPC.lifeMax = 12250;
            NPC.HitSound = SoundID.NPCHit44;
            NPC.DeathSound = SoundID.NPCDeath39;
            NPC.value = 300000f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 63; // slime ai
            NPC.noGravity = true;
            NPC.despawnEncouraged = false;
           
            AIType = NPCID.Flocko; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.Harpy; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
           

        }
     
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
			
				

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("\"TerMerican folklore says that even the Moon Lord trembles in fear at the destructive potential of Unstable Plasmoids. Studying them may be the key to major technological advancements...\" "),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstatineOre>(), 1, 191, 251));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstatineMarksmanRifle>(), 18));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstatinePolearm>(), 18));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlutoniumOre>(), 4, 101, 179));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UraniumOre>(), 4, 41, 79));
            npcLoot.Add(ItemDropRule.Common(ItemID.SoulofFlight, 4, 19, 39));
            npcLoot.Add(ItemDropRule.Common(ItemID.FallenStar, 4, 15, 25));
           
          
           
            npcLoot.Add(ItemDropRule.Common(ItemID.Ectoplasm, 4, 9, 19));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!Main.dayTime  & NPC.downedEmpressOfLight)
            {
                return SpawnCondition.Sky.Chance * 0.07f;
            }
            else
                return SpawnCondition.Sky.Chance * 0f;
        }

    }
}