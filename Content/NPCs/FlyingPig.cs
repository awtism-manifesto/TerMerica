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
    public class FlyingPig : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.PigronHallow];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.ExplosiveBunny;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 70;
            NPC.height = 50;
            NPC.damage = 25;
            NPC.defense = 8;
            NPC.lifeMax = 185;
            NPC.HitSound = SoundID.NPCHit10;
            NPC.DeathSound = SoundID.NPCDeath20;
            NPC.value = 99999f;
            NPC.knockBackResist = 0.525f;
            NPC.aiStyle = 2; // slime ai
            NPC.noGravity = true;
            NPC.despawnEncouraged = false;
            
            AIType = NPCID.PigronHallow; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.PigronHallow; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
           

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
			
				

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("\"TerMerican folklore says that these strange, pig-like creatures with mouths sewn shut are reincarnations of evil and greedy people who've died. This form is a punishment for those souls.\" "),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Ruby, 3, 5, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.Diamond, 3, 4, 8));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KulakWings>(), 20));
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldBar, 2, 13, 21));
            npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumBar, 2, 12, 19));
            npcLoot.Add(ItemDropRule.ByCondition(new HardmodeDrop(), ItemID.CoinGun, chanceDenominator: 4999, chanceNumerator: 2));
        }
        //NPC.downedEmpressOfLight
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            
                return SpawnCondition.Overworld.Chance * 0.0096f;
        }

    }
}