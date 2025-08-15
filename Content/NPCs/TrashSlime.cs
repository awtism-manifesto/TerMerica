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
    public class TrashSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlueSlime];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.MotherSlime;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 44;
            NPC.height = 32;
            NPC.damage = 25;
            NPC.defense = 6;
            NPC.lifeMax = 75;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 125f;
            NPC.knockBackResist = 0.6f;
            NPC.aiStyle = 1; // Fighter AI, important to choose the aiStyle that matches the NPCID that we want to mimic

            AIType = NPCID.GreenSlime; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.GreenSlime; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
            Banner = Item.NPCtoBanner(NPCID.GreenSlime); // Makes this NPC get affected by the normal zombie banner.
            BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.

        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
			
				

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("\"A natural result of the horrific ecological overshoot that has been brought upon this world by humanity...\" "),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Since Party Zombie is essentially just another variation of Zombie, we'd like to mimic the Zombie drops.
            // To do this, we can either (1) copy the drops from the Zombie directly or (2) just recreate the drops in our code.
            // (1) Copying the drops directly means that if Terraria updates and changes the Zombie drops, your ModNPC will also inherit the changes automatically.
            // (2) Recreating the drops can give you more control if desired but requires consulting the wiki, bestiary, or source code and then writing drop code.

            // (1) This example shows copying the drops directly. For consistency and mod compatibility, we suggest using the smallest positive NPCID when dealing with npcs with many variants and shared drop pools.
            var zombieDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.GreenSlime, false); // false is important here
            foreach (var zombieDropRule in zombieDropRules)
            {
                // In this foreach loop, we simple add each drop to the PartyZombie drop pool. 
                npcLoot.Add(zombieDropRule);
            }

            // (2) This example shows recreating the drops. This code is commented out because we are using the previous method instead.
            // npcLoot.Add(ItemDropRule.Common(ItemID.Shackle, 50)); // Drop shackles with a 1 out of 50 chance.
            // npcLoot.Add(ItemDropRule.Common(ItemID.ZombieArm, 250)); // Drop zombie arm with a 1 out of 250 chance.

            // Finally, we can add additional drops. Many Zombie variants have their own unique drops: https://terraria.fandom.com/wiki/Zombie

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlasticScrap>(), 1, 7, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.TinCan, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.OldShoe, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.FishingSeaweed, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LegoBricks>(), 20, 50, 101));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PolymerSlimeStaff>(), 100, 1, 1));
           
            npcLoot.Add(ItemDropRule.Common(ItemID.JojaCola, 33));
            npcLoot.Add(ItemDropRule.Common(ItemID.ChainKnife, 25));
            npcLoot.Add(ItemDropRule.Common(ItemID.FlintlockPistol, 25));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return SpawnCondition.Ocean.Chance * 1.11f;

        }

    }
}