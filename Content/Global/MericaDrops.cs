using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Items;


namespace gunrightsmod.Content.Global
{


    public class ExampleNPCLoot : GlobalNPC
    {
        // ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
        // Here we go through all of them, and how they can be used.
        // There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.PirateShip)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BigBuddy>(), chanceDenominator: 8));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScreamingSoyjak>(), chanceDenominator: 25));

            }
            if (npc.type == NPCID.PirateCaptain)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 15));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Bundlebuss>(), chanceDenominator: 7));


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScreamingSoyjak>(), chanceDenominator: 20));

            }
            if (npc.type == NPCID.PirateDeckhand)
            {


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScreamingSoyjak>(), chanceDenominator: 66));

            }
            if (npc.type == NPCID.PirateCorsair)
            {


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScreamingSoyjak>(), chanceDenominator: 40));

            }
            if (npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheMoon>(), chanceDenominator: 4));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AmalgamatedFragment>(), chanceDenominator: 1));

            }
           
            if (npc.type == NPCID.Hellhound)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SmallSausageSpammer>(), chanceDenominator: 20));



            }
            if (npc.type == NPCID.DD2Betsy)
            {


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PhotonShotgun>(), chanceDenominator: 2));

            }
            if (npc.type == NPCID.Crab)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheFishStick>(), chanceDenominator: 20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CollarOfTheDamned>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlasticScrap>(), 20, 4, 9));

            }
            if (npc.type == NPCID.Nymph)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Heartache>(), chanceDenominator: 3));



            }
            if (npc.type == NPCID.Moth)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Casanova>(), chanceDenominator: 4));



            }
            if (npc.type == NPCID.MossHornet)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Casanova>(), chanceDenominator: 50));



            }
            if (npc.type == NPCID.BigMossHornet)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Casanova>(), chanceDenominator: 50));



            }
            if (npc.type == NPCID.LittleMossHornet)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Casanova>(), chanceDenominator: 50));



            }
            if (npc.type == NPCID.GiantMossHornet)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Casanova>(), chanceDenominator: 50));



            }
            if (npc.type == NPCID.TinyMossHornet)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Casanova>(), chanceDenominator: 50));



            }
            if (npc.type == NPCID.DoctorBones)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DeadSoldiersRifle>(), chanceDenominator: 4));



            }
            if (npc.type == NPCID.PinkJellyfish)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheFishStick>(), chanceDenominator: 12));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlasticScrap>(), 15, 4, 9));

            }
            if (npc.type == NPCID.BoneSerpentHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiantBone>(), chanceDenominator: 100));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuckyCigarette>(), chanceDenominator: 20));

            }
            if (npc.type == NPCID.HallowBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrismaticBullet>(),1, 1449,2749));



            }
            if (npc.type == NPCID.IceGolem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheIcebreaker>(), 7));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IcicleMinigun>(), 7));


            }
            if (npc.type == NPCID.BloodNautilus)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EcologicalOvershot>(), 2));



            }
            if (npc.type == NPCID.LunarTowerVortex)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FragmentFlatEarth>(), 1, 24, 49));



            }
            if (npc.type == NPCID.LunarTowerSolar)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FragmentFlatEarth>(), 1, 24, 49));



            }
            if (npc.type == NPCID.LunarTowerStardust)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FragmentFlatEarth>(), 1, 24, 49));



            }
            if (npc.type == NPCID.LunarTowerNebula)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FragmentFlatEarth>(), 1, 24, 49));



            }
            if (npc.type == NPCID.GoblinSummoner)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Shadowflame>(), 1, 14, 36));



            }
            if (npc.type == NPCID.Zombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));


            }
            if (npc.type == NPCID.BaldZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));

            }
            if (npc.type == NPCID.BigBaldZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));

            }
            if (npc.type == NPCID.SmallBaldZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));

            }
            if (npc.type == NPCID.ZombieDoctor)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));

            }
            if (npc.type == NPCID.ZombieEskimo)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));
                npcLoot.Add(ItemDropRule.Common(ItemID.RedRyder, 20));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.ArmedZombieEskimo)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));
                npcLoot.Add(ItemDropRule.Common(ItemID.RedRyder, 20));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.ZombieRaincoat)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));

                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.PincushionZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 1000));

                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.BigPincushionZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 999));

                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.TorchZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 999));

                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.ArmedTorchZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 999));

                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.ArmedZombieSlimed)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 999));

                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.ArmedZombiePincussion)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ItemID.Handgun, 999));

                npcLoot.Add(ItemDropRule.Common(ItemID.BloodyMachete, 125));
            }
            if (npc.type == NPCID.Skeleton)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 20));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 2500));

            }
            if (npc.type == NPCID.AngryBones)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiantBone>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 250));

            }
            if (npc.type == NPCID.AngryBonesBig)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiantBone>(), chanceDenominator: 50));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 250));

            }
            if (npc.type == NPCID.AngryBonesBigHelmet)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiantBone>(), chanceDenominator: 50));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 250));
            }
            if (npc.type == NPCID.AngryBonesBigMuscle)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadGrades>(), chanceDenominator: 10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiantBone>(), chanceDenominator: 48));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 250));
            }
            if (npc.type == NPCID.CursedSkull)
            {
              
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiantBone>(), chanceDenominator: 150));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 225));
            }
            if (npc.type == NPCID.Bee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Libeerator>(), chanceDenominator: 24));



            }
            if (npc.type == NPCID.BeeSmall)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Libeerator>(), chanceDenominator: 25));



            }
            if (npc.type == NPCID.DarkCaster)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WaterflameSword>(), chanceDenominator: 15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheCommunistManifesto>(), chanceDenominator: 25));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 225));
                npcLoot.Add(ItemDropRule.Common(ItemID.MagicCuffs, 20));
            }
          
            if (npc.type == NPCID.DesertScorpionWalk)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyScorpion>(), chanceDenominator: 11));


            }
            if (npc.type == NPCID.DesertScorpionWall)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyScorpion>(), chanceDenominator: 11));


            }
            if (npc.type == NPCID.SandShark)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyScorpion>(), chanceDenominator: 17));


            }
            if (npc.type == NPCID.SandsharkCorrupt)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyScorpion>(), chanceDenominator: 17));


            }
            if (npc.type == NPCID.SandsharkCrimson)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyScorpion>(), chanceDenominator: 17));


            }
            if (npc.type == NPCID.SandsharkHallow)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyScorpion>(), chanceDenominator: 17));


            }
            if (npc.type == NPCID.DungeonSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Liquidation>(), chanceDenominator: 15));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 175));


            }
            if (npc.type == NPCID.RedDevil)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CardinalSin>(), chanceDenominator: 19));



            }
            if (npc.type == NPCID.Unicorn)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnicornPoacher>(), chanceDenominator: 19));



            }
            if (npc.type == NPCID.GiantTortoise)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 15));



            }
            if (npc.type == NPCID.Nurse)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Heartache>(), chanceDenominator: 25));



            }
            if (npc.type == NPCID.Cyborg)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DvdLogo>(), chanceDenominator: 2));



            }
            if (npc.type == NPCID.Nutcracker)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedNuts>(), chanceDenominator: 15));



            }
            if (npc.type == NPCID.NutcrackerSpinning)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedNuts>(), chanceDenominator: 12));



            }
            if (npc.type == NPCID.Mimic)
            {


               
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BowlingBaller>(), chanceDenominator: 7));

                
               



            }
           
            if (npc.type == NPCID.DiabolistRed)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 25));



            }
            if (npc.type == NPCID.Gastropod)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 90));



            }
            if (npc.type == NPCID.SkeletonArcher)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 70));



            }
            if (npc.type == NPCID.RuneWizard)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 5));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RunicRaygun>(), chanceDenominator: 2));

            }
            if (npc.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PocketBees>(), chanceDenominator: 5));



            }
            if (npc.type == NPCID.SantaNK1)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GagGifter>(), chanceDenominator: 6));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Bergentrucking>(), chanceDenominator: 10));

            }
            if (npc.type == NPCID.PirateDeadeye)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 66));

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Bundlebuss>(), chanceDenominator: 33));

            }
            
              
            
            if (npc.type == NPCID.Scutlix)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PulsePistols>(), chanceDenominator: 18));



            }
            if (npc.type == NPCID.RayGunner)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PulsePistols>(), chanceDenominator: 18));



            }
            if (npc.type == NPCID.MartianSaucerCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PulsePistols>(), chanceDenominator: 7));
                npcLoot.Add(ItemDropRule.ByCondition(new PostMoonlordDrop(), ModContent.ItemType<FissionDrive>(), chanceDenominator: 4, chanceNumerator: 3));


            }
            if (npc.type == NPCID.Golem)
            {

                npcLoot.Add(ItemDropRule.ByCondition(new PostMoonlordDrop(), ModContent.ItemType<FissionDrive>(), chanceDenominator: 5, chanceNumerator: 4));


            }
            if (npc.type == NPCID.TheDestroyer)
            {
               
                npcLoot.Add(ItemDropRule.ByCondition(new PostMoonlordDrop(), ModContent.ItemType<FissionDrive>(), chanceDenominator: 5, chanceNumerator: 3));


            }
            if (npc.type == NPCID.SkeletronPrime)
            {

                npcLoot.Add(ItemDropRule.ByCondition(new PostMoonlordDrop(), ModContent.ItemType<FissionDrive>(), chanceDenominator: 5, chanceNumerator: 3));


            }
            if (npc.type == NPCID.Retinazer)
            {

                npcLoot.Add(ItemDropRule.ByCondition(new PostMoonlordDrop(), ModContent.ItemType<FissionDrive>(), chanceDenominator: 10, chanceNumerator: 3));


            }
            if (npc.type == NPCID.Spazmatism)
            {

                npcLoot.Add(ItemDropRule.ByCondition(new PostMoonlordDrop(), ModContent.ItemType<FissionDrive>(), chanceDenominator: 10, chanceNumerator: 3));


            }
            if (npc.type == NPCID.ScutlixRider)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PulsePistols>(), chanceDenominator: 18));



            }
            if (npc.type == NPCID.Necromancer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroGun>(), chanceDenominator: 20));



            }
            if (npc.type == NPCID.BlueArmoredBones)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroGun>(), chanceDenominator: 25));
                npcLoot.Add(ItemDropRule.Common(ItemID.ShroomiteBar, 4, 2, 4));


            }
            if (npc.type == NPCID.Lavabat)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.LivingFireBlock, 5, 25, 54));


            }
            if (npc.type == NPCID.HellArmoredBones)
            {
                
                npcLoot.Add(ItemDropRule.Common(ItemID.HellstoneBar, 2, 2, 4));


            }
            if (npc.type == NPCID.RustyArmoredBonesAxe)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.MeteoriteBar, 1, 2, 4));


            }
            if (npc.type == NPCID.RustyArmoredBonesFlail)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.MeteoriteBar, 3, 2, 4));


            }
            if (npc.type == NPCID.RustyArmoredBonesSword)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.MeteoriteBar, 4, 2, 4));


            }
            if (npc.type == NPCID.RustyArmoredBonesSwordNoArmor)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.MeteoriteBar, 2, 2, 4));


            }
            if (npc.type == NPCID.HellArmoredBonesMace)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.HellstoneBar, 3, 2, 4));


            }
            if (npc.type == NPCID.HellArmoredBonesSword)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.HellstoneBar, 4, 2, 4));


            }
            if (npc.type == NPCID.HellArmoredBonesSpikeShield)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.HellstoneBar, 4, 2, 4));


            }
            if (npc.type == NPCID.BlueArmoredBonesNoPants)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroGun>(), chanceDenominator: 20));
                npcLoot.Add(ItemDropRule.Common(ItemID.ShroomiteBar, 1, 2, 4));


            }
            if (npc.type == NPCID.BlueArmoredBonesMace)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroGun>(), chanceDenominator: 25));
                npcLoot.Add(ItemDropRule.Common(ItemID.ShroomiteBar, 2, 2, 4));


            }
            if (npc.type == NPCID.BlueArmoredBonesSword)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroGun>(), chanceDenominator: 25));
                npcLoot.Add(ItemDropRule.Common(ItemID.ShroomiteBar, 2, 2, 4));


            }
            if (npc.type == NPCID.SkeletonSniper)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroGun>(), chanceDenominator: 9));



            }
            if (npc.type == NPCID.AncientCultistSquidhead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StupidFuckingPickaxe>(), chanceDenominator: 2502));



            }
            if (npc.type == NPCID.BigMimicHallow)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DartShotgun>(), chanceDenominator: 5));



            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroGun>(), chanceDenominator: 15));



            }
            if (npc.type == NPCID.AngryTrapper)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 60));



            }
            if (npc.type == NPCID.Wraith)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShatteredKeyboard>(), chanceDenominator: 115));



            }
            if (npc.type == NPCID.KingSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SuperSamuraiSlicer>(), chanceDenominator: 4));
                npcLoot.Add(ItemDropRule.Common(ItemID.Trimarang, 9));
                npcLoot.Add(ItemDropRule.Common(ItemID.Katana, 2));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Bergentrucking>(), chanceDenominator: 10));

            }
            if (npc.type == NPCID.SkeletronHead)
            {
                
              
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 8));

            }
            if (npc.type == NPCID.DungeonGuardian)
            {


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletonKey>(), chanceDenominator: 2));

            }
            if (npc.type == NPCID.DD2DarkMageT1)
            {


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ArcaneDartgun>(), chanceDenominator: 5));

            }
            if (npc.type == NPCID.DD2DarkMageT3)
            {


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ArcaneDartgun>(), chanceDenominator: 6));

            }
            if (npc.type == NPCID.DemonEye)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.Lens, 2));


            }
            if (npc.type == NPCID.DemonEyeSpaceship)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.Lens, 2));


            }
           
            if (npc.type == NPCID.DemonEye2)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.Lens, 2));


            }
            if (npc.type == NPCID.QueenSlimeBoss)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MaximGelgun>(), chanceDenominator: 2));


            }
            if (npc.type == NPCID.BrainofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoodGrades>(), chanceDenominator: 2));



            }
            if (npc.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeedBomber>(), chanceDenominator: 7));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OtherworldlySixPack>(), chanceDenominator: 5));


            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.BlackLens, 2, 2,3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeRifle>(), chanceDenominator: 4));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyePoker>(), chanceDenominator: 4));
                npcLoot.Add(ItemDropRule.Common(ItemID.VampireFrogStaff, 4));
                npcLoot.Add(ItemDropRule.Common(ItemID.BloodRainBow, 4));
            }
            if (npc.type == NPCID.EyeballFlyingFish)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.BlackLens, 1, 1, 10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeRifle>(), chanceDenominator: 8));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyePoker>(), chanceDenominator: 8));
               
            }
            if (npc.type == NPCID.Deerclops)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CaribousCatastrophe>(), chanceDenominator: 2));
                npcLoot.Add(ItemDropRule.Common(ItemID.FlinxFur, 1, 6, 15));
            }
            if (npc.type == NPCID.ManEater)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Stinger, 2, 2, 3));
            }
            if (npc.type == NPCID.Snatcher)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Stinger, 3, 1, 2));
            }
            if (npc.type == NPCID.LittleHornetLeafy)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Vine, 3, 1, 2));
            }
            if (npc.type == NPCID.HornetLeafy)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Vine, 2, 2, 2));
            }
            if (npc.type == NPCID.BigHornetLeafy)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Vine, 1, 2, 3));
            }
            if (npc.type == NPCID.SandElemental)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Nazar, 5));
            }
            if (npc.type == NPCID.Demon)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DemonConch, 25));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuckyCigarette>(), chanceDenominator: 20));
            }
            if (npc.type == NPCID.VoodooDemon)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DemonConch, 20));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuckyCigarette>(), chanceDenominator: 20));
            }
            if (npc.type == NPCID.Butcher)
            {

                npcLoot.Add(ItemDropRule.Common(ItemID.HamBat, 20));


            }
            if (npc.type == NPCID.Harpy)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.CreativeWings, 35));
            }
            if (npc.type == NPCID.Derpling)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Uzi, 30));
            }
            if (npc.type == NPCID.MeteorHead)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Meteorite, 2, 1, 3));
            }
            if (npc.type == NPCID.BigMimicCrimson)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofNight, 1, 9, 14));
            }
            if (npc.type == NPCID.BigMimicCorruption)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofNight, 1, 9, 14));
            }
            if (npc.type == NPCID.BigMimicHallow)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofLight, 1, 9, 14));
            }
            if (npc.type == NPCID.Shark)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheFishStick>(), chanceDenominator: 7));
                npcLoot.Add(ItemDropRule.Common(ItemID.Minishark, 10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlasticScrap>(), 25, 4, 9));
            }
            if (npc.type == NPCID.Squid)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheFishStick>(), chanceDenominator: 9));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlasticScrap>(), 15, 4, 9));
            }
            if (npc.type == NPCID.SnowFlinx)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FlinxsFurblade>(), chanceDenominator: 9));
            }
            if (npc.type == NPCID.UndeadViking)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.RedRyder, 15));
                npcLoot.Add(ItemDropRule.Common(ItemID.FlinxFur, 8, 1, 3));
            }
            if (npc.type == NPCID.Werewolf)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Sextant, 20));
            }
            if (npc.type == NPCID.TacticalSkeleton)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.OnyxBlaster, 20));
            }
            if (npc.type == NPCID.SpikedJungleSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DPSMeter, 33));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VerdantClaymore>(), chanceDenominator: 25));
                npcLoot.Add(ItemDropRule.Common(ItemID.JungleSpores, 3, 2, 4));
            }
            if (npc.type == NPCID.Poltergeist)
            {
                
                npcLoot.Add(ItemDropRule.Common(ItemID.Ectoplasm, 3, 1, 4));
            }
            if (npc.type == NPCID.SpikedIceSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.BlizzardinaBottle, 20));
                npcLoot.Add(ItemDropRule.Common(ItemID.IceBlade, 33));
            }
            if (npc.type == NPCID.SandSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SandstorminaBottle, 20));
            }
            if (npc.type == NPCID.AngryNimbus)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.WeatherRadio, 20));
            }
            if (npc.type == NPCID.Crawdad)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FeralClaws, 10));
            }
            if (npc.type == NPCID.WalkingAntlion)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SandBoots, 20));
            }
            if (npc.type == NPCID.GiantWalkingAntlion)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.SandBoots, 15));
            }
            if (npc.type == NPCID.Corruptor)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Toxikarp,33));
            }
            if (npc.type == NPCID.Herpling)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Bladetongue, 33));
            }
            if (npc.type == NPCID.FlyingFish)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FishermansGuide, 100));
            }
            if (npc.type == NPCID.Hellbat)
            {
               
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuckyCigarette>(), chanceDenominator: 20));
            }
            if (npc.type == NPCID.FireImp)
            {
               
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuckyCigarette>(), chanceDenominator: 20));
            }
            if (npc.type == NPCID.LavaSlime)
            {

                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LuckyCigarette>(), chanceDenominator: 20));
            }
           
            if (npc.type == NPCID.BoneLee)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.MasterNinjaGear, 60));
            }
            if (npc.type == NPCID.Drippler)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Terragrim, 200));
            }
            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StalingradSpewer>(), chanceDenominator: 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StupidEmblem>(), chanceDenominator: 4));


            }
        }
    }
}