using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using gunrightsmod.Content.Items;
using gunrightsmod.Content.DamageClasses;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Global
{
    public class MericaRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.AvengerEmblem);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient<Items.StupidEmblem>();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipeenar = Recipe.Create(ItemID.Torch, 10);
           
            recipeenar.AddRecipeGroup("Wood");
            recipeenar.AddIngredient<Items.CrudeOil>();
            
            recipeenar.Register();

            Recipe brecipe = Recipe.Create(ItemID.Celeb2);
            brecipe.AddIngredient(ItemID.FireworksLauncher);
           
            brecipe.AddIngredient<Items.FissionDrive>();
            brecipe.AddTile(TileID.LunarCraftingStation);
            brecipe.Register();

            Recipe bbrecipe = Recipe.Create(ItemID.StarWrath);
            bbrecipe.AddIngredient(ItemID.Starfury);

            bbrecipe.AddIngredient<Items.FissionDrive>();
            bbrecipe.AddTile(TileID.LunarCraftingStation);
            bbrecipe.Register();

            Recipe bebrecipe = Recipe.Create(ItemID.RainbowCrystalStaff);
            bebrecipe.AddIngredient(ItemID.RainbowGun);

            bebrecipe.AddIngredient<Items.FissionDrive>();
            bebrecipe.AddTile(TileID.LunarCraftingStation);
            bebrecipe.Register();

            Recipe sbebrecipe = Recipe.Create(ItemID.LastPrism);
            sbebrecipe.AddIngredient<Items.UraniumGlass>(33);
            sbebrecipe.AddIngredient<Items.PlutoniumGlass>(33);
            sbebrecipe.AddIngredient<Items.AstatineGlass>(33);

            sbebrecipe.AddIngredient<Items.FissionDrive>(2);
            sbebrecipe.AddTile(TileID.LunarCraftingStation);
            sbebrecipe.Register();

            Recipe recipenis = Recipe.Create(ItemID.LesionStation);
            recipenis.AddIngredient(ItemID.FleshCloningVaat);
           
            recipenis.AddTile(TileID.MythrilAnvil);
            recipenis.Register();

            Recipe recipenist = Recipe.Create(ItemID.FleshCloningVaat);
            recipenist.AddIngredient(ItemID.LesionStation);

            recipenist.AddTile(TileID.MythrilAnvil);
            recipenist.Register();

            Recipe penis = Recipe.Create(ItemID.Sandgun);
            penis.AddIngredient<Items.PocketSand>();
            penis.AddIngredient<Items.Glock>();
            penis.AddTile(TileID.Anvils);
            penis.Register();

            Recipe penile = Recipe.Create(ItemID.BloodRainBow);
            penile.AddIngredient<Items.KingslayerWarBow>();
            penile.AddIngredient(ItemID.DemoniteBar, 8);
            penile.AddTile(TileID.Anvils);
            penile.Register();
            Recipe penile2 = Recipe.Create(ItemID.BloodRainBow);
            penile2.AddIngredient<Items.KingslayerWarBow>();
            penile2.AddIngredient(ItemID.CrimtaneBar, 8);
            penile2.AddTile(TileID.Anvils);
            penile2.Register();

            Recipe penises = Recipe.Create(ItemID.Keybrand);
            penises.AddIngredient(ItemID.Cutlass);
           
            penises.AddIngredient(ItemID.GoldenKey);
            penises.AddIngredient(ItemID.HallowedBar, 9);
            penises.AddTile(TileID.MythrilAnvil);
            penises.Register();

            Recipe aaa = Recipe.Create(ItemID.LunarHook);
            
            aaa.AddIngredient<Items.FragmentFlatEarth>(20);
            aaa.AddTile(TileID.LunarCraftingStation);
            aaa.Register();

            Recipe aaanal = Recipe.Create(ItemID.ShadowKey);
            aaanal.AddIngredient(ItemID.GoldenKey);
            aaanal.AddIngredient(ItemID.ShadowChest);
            aaanal.AddTile(TileID.AlchemyTable);
            aaanal.Register();

            Recipe aata = Recipe.Create(ItemID.LeadOre, 2);

            aata.AddIngredient<Items.UraniumOre>();
            aata.AddTile(TileID.LesionStation);
            aata.Register();

            Recipe aata1 = Recipe.Create(ItemID.LeadOre, 5);

            aata1.AddIngredient<Items.PlutoniumOre>();
            aata1.AddTile(TileID.LesionStation);
            aata1.Register();

            Recipe aata31 = Recipe.Create(ItemID.LeadOre, 15);

            aata31.AddIngredient<Items.AstatineOre>();
            aata31.AddTile(TileID.LesionStation);
            aata31.Register();

            Recipe aaaa = Recipe.Create(ItemID.CelestialSigil);

            aaaa.AddIngredient<Items.FragmentFlatEarth>(45);
            aaaa.AddTile(TileID.LunarCraftingStation);
            aaaa.Register();

           

            Recipe ass9 = Recipe.Create(ItemID.MiniNukeI, 999);
            ass9.AddIngredient(ItemID.RocketIII, 999);
            ass9.AddIngredient<Items.PlutoniumBar>();
            ass9.AddIngredient<Items.UraniumBar>();
            ass9.AddIngredient<Items.AstatineBar>();
            ass9.AddTile(TileID.MythrilAnvil);
            ass9.Register();

            Recipe ass99 = Recipe.Create(ItemID.MiniNukeII, 999);
            ass99.AddIngredient(ItemID.RocketIV, 999);
            ass99.AddIngredient<Items.PlutoniumBar>();
            ass99.AddIngredient<Items.AstatineBar>();
            ass99.AddIngredient<Items.UraniumBar>();
            ass99.AddTile(TileID.MythrilAnvil);
            ass99.Register();

            Recipe wass = Recipe.Create(ItemID.ShinyRedBalloon);
            wass.AddIngredient(ItemID.Cloud,5);
            wass.AddIngredient<Items.PlasticScrap>(15);
            wass.AddTile(TileID.TinkerersWorkbench);
            wass.Register();

            Recipe wass1 = Recipe.Create(ItemID.LaserMachinegun);
            wass1.AddIngredient(ItemID.MartianConduitPlating, 50);
            wass1.AddIngredient<Items.CyberneticGunParts>();
            wass1.AddTile(TileID.MythrilAnvil);
            wass1.Register();
            Recipe wass11 = Recipe.Create(ItemID.Xenopopper);
            wass11.AddIngredient(ItemID.MartianConduitPlating, 50);
            wass11.AddIngredient<Items.CyberneticGunParts>();
            wass11.AddTile(TileID.MythrilAnvil);
            wass11.Register();
            Recipe wass111 = Recipe.Create(ItemID.ElectrosphereLauncher);
            wass111.AddIngredient(ItemID.MartianConduitPlating, 50);
            wass111.AddIngredient<Items.CyberneticGunParts>();
            wass111.AddTile(TileID.MythrilAnvil);
            wass111.Register();
            Recipe wass1111 = Recipe.Create(ItemID.ChargedBlasterCannon);
            wass1111.AddIngredient(ItemID.MartianConduitPlating, 50);
            wass1111.AddIngredient<Items.CyberneticGunParts>();
            wass1111.AddTile(TileID.MythrilAnvil);
            wass1111.Register();
            Recipe waess = Recipe.Create(ItemID.RodofDiscord);
            waess.AddIngredient<Items.PlutoniumBar>(11);
            waess.AddIngredient<Items.UraniumBar>(22);
            waess.AddIngredient<Items.PurifiedSalt>(333);
            waess.AddTile(TileID.MythrilAnvil);
            waess.Register();

            Recipe wawess = Recipe.Create(ItemID.HolyArrow, 77);
            wawess.AddIngredient(ItemID.WoodenArrow,77);
            wawess.AddIngredient<Items.PurifiedSalt>();
            wawess.AddTile(TileID.MythrilAnvil);
            wawess.Register();
            Recipe wackwess = Recipe.Create(ItemID.ShroomiteBar, 2);
            wackwess.AddIngredient(ItemID.ChlorophyteBar);
            wackwess.AddIngredient<Items.LycopiteBar>();
            wackwess.AddIngredient(ItemID.GlowingMushroom, 10);
            wackwess.AddTile(TileID.Autohammer);
            wackwess.Register();
            Recipe qwawess = Recipe.Create(ItemID.ShadowFlameHexDoll);
           
            qwawess.AddIngredient<Items.Shadowflame>(50);
            qwawess.AddTile(TileID.MythrilAnvil);
            qwawess.Register();
            Recipe qvwawess = Recipe.Create(ItemID.ShadowFlameKnife);

            qvwawess.AddIngredient<Items.Shadowflame>(50);
            qvwawess.AddTile(TileID.MythrilAnvil);
            qvwawess.Register();
            Recipe qv3wawess = Recipe.Create(ItemID.ShadowFlameBow);

            qv3wawess.AddIngredient<Items.Shadowflame>(50);
            qv3wawess.AddTile(TileID.MythrilAnvil);
            qv3wawess.Register();
            Recipe qv3wawesss = Recipe.Create(ItemID.ShadowflameHadesDye);

            qv3wawesss.AddIngredient<Items.Shadowflame>(15);
            qv3wawesss.AddTile(TileID.DyeVat);
            qv3wawesss.Register();


            Recipe qv333wawesss = Recipe.Create(ItemID.SlimeCrown);
            qv333wawesss.AddIngredient(ItemID.Gel, 15);
            
            qv333wawesss.AddIngredient<Items.KingslayerCrown>();
            qv333wawesss.AddTile(TileID.DemonAltar);
            qv333wawesss.Register();

            Recipe qv33wawesss = Recipe.Create(ItemID.QueenSlimeCrystal);
            qv33wawesss.AddIngredient(ItemID.PinkGel, 10);
            qv33wawesss.AddIngredient(ItemID.CrystalShard, 5);
            qv33wawesss.AddIngredient<Items.KingslayerCrown>();
            qv33wawesss.AddTile(TileID.Solidifier);
            qv33wawesss.Register();
            Recipe bitche = Recipe.Create(ItemID.HeatRay);
            bitche.AddIngredient<Items.SolarRayRifle>();
            bitche.AddIngredient(ItemID.ChlorophyteBar, 10);
            bitche.AddIngredient(ItemID.BeetleHusk, 5);
            bitche.AddIngredient(ItemID.LihzahrdPowerCell);
            bitche.AddTile(TileID.MythrilAnvil);
            bitche.Register();

            Recipe bitcheee = Recipe.Create(ItemID.BrokenHeroSword);
            bitcheee.AddIngredient<Items.BrokenHeroGun>();
           
            bitcheee.AddTile(TileID.MythrilAnvil);
            bitcheee.Register();

            Recipe wadwess = Recipe.Create(ItemID.SDMG);
            wadwess.AddIngredient(ItemID.Megashark);
            wadwess.AddIngredient(ItemID.LunarBar, 8);
            wadwess.AddIngredient<Items.CyberneticGunParts>();

            wadwess.AddTile(TileID.LunarCraftingStation);
            wadwess.Register();
            Recipe wawdwess = Recipe.Create(ItemID.VenusMagnum);
            wawdwess.AddIngredient(ItemID.PhoenixBlaster);
            wawdwess.AddIngredient(ItemID.ChlorophyteBar, 10);
            wawdwess.AddIngredient<Items.CyberneticGunParts>();

            wawdwess.AddTile(TileID.MythrilAnvil);
            wawdwess.Register();
            Recipe wcass = Recipe.Create(ItemID.FishingBobber);
           
            wcass.AddIngredient<Items.PlasticScrap>(15);
            wcass.AddTile(TileID.TinkerersWorkbench);
            wcass.Register();

            Recipe wcaess = Recipe.Create(ItemID.FloatingTube);

            wcaess.AddIngredient<Items.PlasticScrap>(10);
            wcaess.AddTile(TileID.WorkBenches);
            wcaess.Register();


           


            Recipe bitch = Recipe.Create(ItemID.Worm);
            bitch.AddIngredient(ItemID.DirtBlock, 30);           
            bitch.Register();

            Recipe bitchass = Recipe.Create(ItemID.WaffleIron);
            bitchass.AddIngredient(ItemID.IronBar, 30);
            bitchass.AddIngredient(ItemID.SoulofFright, 10);
            bitchass.AddIngredient(ItemID.SoulofSight, 10);
            bitchass.AddIngredient(ItemID.SoulofMight, 10);
            bitchass.AddTile(TileID.MythrilAnvil);
            bitchass.Register();
            Recipe bitchass1 = Recipe.Create(ItemID.WaffleIron);
            bitchass1.AddIngredient(ItemID.LeadBar, 30);
            bitchass1.AddIngredient(ItemID.SoulofFright, 10);
            bitchass1.AddIngredient(ItemID.SoulofSight, 10);
            bitchass1.AddIngredient(ItemID.SoulofMight, 10);
            bitchass1.AddTile(TileID.MythrilAnvil);
            bitchass1.Register();

            Recipe fag = Recipe.Create(ItemID.Worm);
            fag.AddIngredient(ItemID.MudBlock, 15);
            fag.Register();

            Recipe fuck = Recipe.Create(ItemID.HotlineFishingHook);
            fuck.AddIngredient(ItemID.Fleshcatcher);
            fuck.AddIngredient(ItemID.HellstoneBar,10);           
            fuck.AddTile(TileID.Anvils);
            fuck.Register();

            Recipe shit = Recipe.Create(ItemID.HotlineFishingHook);
            shit.AddIngredient(ItemID.FisherofSouls);
            shit.AddIngredient(ItemID.HellstoneBar, 10);
            shit.AddTile(TileID.Anvils);
            shit.Register();

            Recipe gayyy = Recipe.Create(ItemID.IceSickle);
            gayyy.AddIngredient(ItemID.FrostCore);
            gayyy.AddIngredient(ItemID.CobaltBar, 10);
            gayyy.AddTile(TileID.Anvils);
            gayyy.Register();
            Recipe gayyy4 = Recipe.Create(ItemID.IceSickle);
            gayyy4.AddIngredient(ItemID.FrostCore);
            gayyy4.AddIngredient(ItemID.PalladiumBar, 10);
            gayyy4.AddTile(TileID.Anvils);
            gayyy4.Register();

            Recipe gay = Recipe.Create(ItemID.Frostbrand);
            gay.AddIngredient(ItemID.FrostCore);
            gay.AddIngredient(ItemID.CobaltBar, 10);
            gay.AddTile(TileID.Anvils);
            gay.Register();

            

            Recipe gay2 = Recipe.Create(ItemID.Frostbrand);
            gay2.AddIngredient(ItemID.FrostCore);
            gay2.AddIngredient(ItemID.PalladiumBar, 10);
            gay2.AddTile(TileID.Anvils);
            gay2.Register();

            Recipe gay3 = Recipe.Create(ItemID.FrostStaff);
            gay3.AddIngredient(ItemID.FrostCore);
            gay3.AddIngredient(ItemID.PalladiumBar, 10);
            gay3.AddTile(TileID.Anvils);
            gay3.Register();

            Recipe gay4 = Recipe.Create(ItemID.FrostStaff);
            gay4.AddIngredient(ItemID.FrostCore);
            gay4.AddIngredient(ItemID.CobaltBar, 10);
            gay4.AddTile(TileID.Anvils);
            gay4.Register();

            Recipe gay5 = Recipe.Create(ItemID.IceBow);
            gay5.AddIngredient(ItemID.FrostCore);
            gay5.AddIngredient(ItemID.CobaltBar, 10);
            gay5.AddTile(TileID.Anvils);
            gay5.Register();

            Recipe recipee = Recipe.Create(ItemID.SanguineStaff);
            recipee.AddIngredient(ItemID.DemoniteBar, 10);
            recipee.AddIngredient(ItemID.CrimtaneBar, 10);
            recipee.AddIngredient(ItemID.SoulofNight, 5);
            recipee.AddTile(TileID.Anvils);
            recipee.Register();
            if (ModLoader.TryGetMod("Spooky", out Mod SpookMerica) && SpookMerica.TryFind("ArteryPiece", out ModItem ArteryPiece))


            {
                recipee.AddIngredient(ArteryPiece.Type, 10);


            }
            Recipe recipeee = Recipe.Create(ItemID.SharpTears);
            recipeee.AddIngredient(ItemID.DemoniteBar, 10);
            recipeee.AddIngredient(ItemID.CrimtaneBar, 10);
            recipeee.AddIngredient(ItemID.SoulofNight, 5);
            recipeee.AddTile(TileID.Anvils);
            recipeee.Register();
            if (ModLoader.TryGetMod("Spooky", out Mod SpookMerica2) && SpookMerica2.TryFind("ArteryPiece", out ModItem ArteryPiece2))


            {
                recipeee.AddIngredient(ArteryPiece2.Type, 10);


            }

            Recipe recipeeee = Recipe.Create(ItemID.DripplerFlail);
            recipeeee.AddIngredient(ItemID.DemoniteBar, 10);
            recipeeee.AddIngredient(ItemID.CrimtaneBar, 10);
            recipeeee.AddIngredient(ItemID.SoulofNight, 5);

            recipeeee.AddTile(TileID.Anvils);
            recipeeee.Register();
            if (ModLoader.TryGetMod("Spooky", out Mod SpookMerica3) && SpookMerica3.TryFind("ArteryPiece", out ModItem ArteryPiece1))


            {
                recipeeee.AddIngredient(ArteryPiece1.Type, 10);


            }
            Recipe recipeeeee = Recipe.Create(ItemID.BloodHamaxe);
            recipeeeee.AddIngredient(ItemID.DemoniteBar, 10);
            recipeeeee.AddIngredient(ItemID.CrimtaneBar, 10);
            recipeeeee.AddIngredient(ItemID.SoulofNight, 5);

            recipeeeee.AddTile(TileID.Anvils);
            recipeeeee.Register();
            if (ModLoader.TryGetMod("Spooky", out Mod SpookMerica33) && SpookMerica33.TryFind("ArteryPiece", out ModItem ArteryPiece11))


            {
                Recipe recipeepee = Recipe.Create(ItemID.BloodHamaxe);


                recipeepee.AddIngredient(ArteryPiece11.Type, 10);


            }

            Recipe gay6 = Recipe.Create(ItemID.IceBow);
            gay6.AddIngredient(ItemID.FrostCore);
            gay6.AddIngredient(ItemID.PalladiumBar, 10);
            gay6.AddTile(TileID.Anvils);
            gay6.Register();

            Recipe gay69 = Recipe.Create(ItemID.ZapinatorOrange);
            gay69.AddIngredient<Items.CyberneticGunParts>();
            gay69.AddIngredient(ItemID.ZapinatorGray);
            gay69.AddTile(TileID.MythrilAnvil);
            gay69.Register();

            Recipe gay69420 = Recipe.Create(ItemID.ZapinatorGray);
            gay69420.AddIngredient<Items.ZapperGun>();
            gay69420.AddIngredient(ItemID.CrimtaneBar, 8);
            gay69420.AddIngredient(ItemID.IllegalGunParts);
            gay69420.AddTile(TileID.Anvils);
            gay69420.Register();

            Recipe gay69421 = Recipe.Create(ItemID.ZapinatorGray);
            gay69421.AddIngredient<Items.ZapperGun>();
            gay69421.AddIngredient(ItemID.DemoniteBar, 8);
            gay69421.AddIngredient(ItemID.IllegalGunParts);
            gay69421.AddTile(TileID.Anvils);
            gay69421.Register();
            Recipe cc = Recipe.Create(ItemID.CandyCaneSword);
            cc.AddIngredient(ItemID.CandyCaneBlock,15);
            cc.AddIngredient(ItemID.GreenCandyCaneBlock, 10);
            cc.AddTile(TileID.Anvils);
            cc.Register();

           
                Recipe crrc = Recipe.Create(ItemID.RedRyder);
            crrc.AddIngredient(ItemID.Musket);
            crrc.AddIngredient(ItemID.GreenCandyCaneBlock, 15);
            crrc.AddTile(TileID.Anvils);
            crrc.Register();
            Recipe crrrc = Recipe.Create(ItemID.RedRyder);
            crrrc.AddIngredient(ItemID.TheUndertaker);
            crrrc.AddIngredient(ItemID.CandyCaneBlock, 15);
            crrrc.AddTile(TileID.Anvils);
            crrrc.Register();

            Recipe ckc = Recipe.Create(ItemID.WhoopieCushion);
            ckc.AddIngredient(ItemID.PoopBlock, 1);
            ckc.AddIngredient<Items.PlasticScrap>(15);
            ckc.AddTile(TileID.TinkerersWorkbench);
            ckc.Register();

            Recipe ccp = Recipe.Create(ItemID.CnadyCanePickaxe);
            ccp.AddIngredient(ItemID.CandyCaneBlock, 15);
            ccp.AddIngredient(ItemID.GreenCandyCaneBlock, 10);
            ccp.AddTile(TileID.Anvils);
            ccp.Register();

            Recipe ccpee = Recipe.Create(ItemID.DirtiestBlock);
            ccpee.AddIngredient(ItemID.DirtBlock, 2147483646 );
            
            
            ccpee.Register();

            Recipe gayee5 = Recipe.Create(ItemID.AntlionClaw);
            gayee5.AddIngredient(ItemID.AntlionMandible, 5);
            gayee5.AddIngredient(ItemID.FossilOre, 8);
            gayee5.AddTile(TileID.Anvils);
            gayee5.Register();
        }




    }
}

