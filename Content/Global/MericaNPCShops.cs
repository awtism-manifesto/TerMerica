using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gunrightsmod.Content.NPCs;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Global
{
    internal class MericaNPCShops:GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.ArmsDealer)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<fivenato>(condition: Terraria.Condition.DownedPlantera);

                shop.Add<KingslayerBullet>(condition: Terraria.Condition.ForTheWorthyWorld);
                shop.Add<CeramicDart>(condition: Terraria.Condition.Hardmode);
               

                shop.Add<Glock>(condition: Terraria.Condition.DownedEyeOfCthulhu);
                shop.Add<AK47>(condition: Terraria.Condition.DownedSkeletron);
                
              
                shop.Add(ItemID.Handgun, condition: Terraria.Condition.DownedSkeletron);
                shop.Add(ItemID.QuadBarrelShotgun,condition: Terraria.Condition.DownedSkeletron);
                shop.Add<TommyGun>(condition: Terraria.Condition.Hardmode);
                shop.Add<PoliceBaton>(condition: Terraria.Condition.NotTenthAnniversaryWorld);
                shop.Add<SacrificialPistol>(condition: Terraria.Condition.PlayerCarriesItem(ModContent.ItemType<DiseaseBlaster>()));
                shop.Add<DiseaseBlaster>(condition: Terraria.Condition.PlayerCarriesItem(ModContent.ItemType<SacrificialPistol>()));
                shop.Add<Brainderbuss>(condition: Terraria.Condition.PlayerCarriesItem(ModContent.ItemType<ToothlessWyrm>()));
                shop.Add<ToothlessWyrm>(condition: Terraria.Condition.PlayerCarriesItem(ModContent.ItemType<Brainderbuss>()));
               


               

             }
            if (shop.NpcType == NPCID.Merchant)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<EnfieldRifle>(condition: Terraria.Condition.NpcIsPresent(NPCID.ArmsDealer));
                shop.Add<M1Garand>(condition: Terraria.Condition.Hardmode);
               
                shop.Add(ItemID.Blowpipe);
               
               

            }
            if (shop.NpcType == NPCID.Demolitionist)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<Barbarossa>(condition: Terraria.Condition.DownedEmpressOfLight);
                shop.Add<RivetGun>(condition: Terraria.Condition.DownedSkeletron);
                shop.Add(ItemID.Nail, condition: Terraria.Condition.DownedSkeletron);
            }
           
            if (shop.NpcType == NPCID.PartyGirl)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<RectumsRequiem>(condition: Terraria.Condition.Hardmode);
                shop.Add<WhippetWhip>(condition: Terraria.Condition.DownedEarlygameBoss);
            }
            if (shop.NpcType == NPCID.Wizard)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<GayFrogAlchemyGuide>(condition: Terraria.Condition.DownedMechBossAny);

            }
            if (shop.NpcType == NPCID.SkeletonMerchant)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<DeadSoldiersRifle>(condition: Terraria.Condition.InJungle);
                shop.Add<PocketMortar>();
                shop.Add<RocketNeg1>();
            }
            if (shop.NpcType == NPCID.BestiaryGirl)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<TedGun>(condition: Terraria.Condition.DownedEmpressOfLight);
                shop.Add<OrcaMask>();
                shop.Add<OrcaSuit>();
                shop.Add<OrcaTail>();
            }
            if (shop.NpcType == NPCID.WitchDoctor)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<TrenboloneAcetate>();

            }
            if (shop.NpcType == NPCID.Pirate)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<Bundlebuss>();
                shop.Add<BigBuddy>(condition: Terraria.Condition.DownedMechBossAny);
            }
            if (shop.NpcType == NPCID.DD2Bartender)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add(ItemID.AleThrowingGlove);
                shop.Add<MagicCue>();
                shop.Add<BoggsGlove>(condition: Terraria.Condition.DownedOldOnesArmyT3);
            }
            if (shop.NpcType == NPCID.Cyborg)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<AutismDiagnosis>();
                shop.Add<CyberneticGunParts>(condition: Terraria.Condition.DownedGolem);
               
                shop.Add<PowerHelmet>();
                shop.Add<PowerChestplate>();
                shop.Add<PowerPants>();
            }
            if (shop.NpcType == NPCID.GoblinTinkerer)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.Add<SkibidiToilet>(condition: Terraria.Condition.DownedSkeletron);
               
                shop.Add<LegoBricks>();
                shop.Add<GoodGrades>(condition: Terraria.Condition.DownedEowOrBoc);
                shop.Add<Polymer>(condition: Terraria.Condition.DownedEowOrBoc);
                shop.Add<Kevlar>(condition: Terraria.Condition.Hardmode);
                shop.Add<ShadowflameArrow>(condition: Terraria.Condition.DownedMechBossAny);

            }


           
            
        }
    }
}
    

