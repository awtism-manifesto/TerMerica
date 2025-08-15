using gunrightsmod.Content.DamageClasses;
using Microsoft.Xna.Framework;
using gunrightsmod.Content.Items;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using gunrightsmod.Content.Projectiles;

namespace gunrightsmod.Content.GlobalItems
{
    // This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
    // adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand.
    // See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
    public class SaltCalBuff : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<SaltPendant>();
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Calamity): Now gives more defense ") { OverrideColor = Color.PaleVioletRed });
            }


        }

        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                item.defense = 5;
            }
        }

       
    }
    public class PureSaltCalBuff : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<SpiritProtectionCharm>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Calamity): Now gives more defense ") { OverrideColor = Color.PaleVioletRed });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                item.defense = 8;
            }
        }


    }
    public class PlanetoidThorium : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<PlanetoidPunisher>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.damage = 25;
                item.useTime = 36;
                item.useAnimation = 36;
            }
        }


    }
    public class ThoriumModOiledUp : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<BottledOil>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Thorium): Now deals Throwing damage") { OverrideColor = Color.LightSeaGreen });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.DamageType = DamageClass.Throwing;
            }
        }


    }
    public class ThoriumMonke : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<TheMonkeysPaw>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Thorium): Now deals Throwing damage and no longer requires ammo") { OverrideColor = Color.LightSeaGreen });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.DamageType = DamageClass.Throwing;
                item.damage = 15;
                item.useAmmo = AmmoID.None;
                item.shoot = ModContent.ProjectileType<CeramDart>();
            }
        }


    }
    public class ThoriumMonkeSuper : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<SuperMonkeysPaw>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Thorium): Now deals Throwing damage and no longer requires ammo") { OverrideColor = Color.LightSeaGreen });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.DamageType = DamageClass.Throwing;
                item.damage = 22;
                item.useAmmo = AmmoID.None;
                item.shoot = ModContent.ProjectileType<CeramDart>();
            }
        }


    }
    public class ThoriumMonkeSuperLaser : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<LaserMonkeysPaw>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Thorium): Now deals Throwing damage and no longer requires ammo") { OverrideColor = Color.LightSeaGreen });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.DamageType = DamageClass.Throwing;
                item.damage = 41;
                item.useAmmo = AmmoID.None;
                item.shoot = ModContent.ProjectileType<LaserBlast>();
            }
        }


    }
    public class ThoriumMonkeSuperLaserPlasma : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<PlasmaMonkeysPaw>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Thorium): Now deals Throwing damage and no longer requires ammo") { OverrideColor = Color.LightSeaGreen });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.DamageType = DamageClass.Throwing;
                item.damage = 77;
                item.useAmmo = AmmoID.None;
                item.shoot = ModContent.ProjectileType<PlasmaBlast>();
            }
        }


    }
    public class PeopleThorium : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<ThePeoplesPitchfork>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Thorium): Now deals Throwing damage") { OverrideColor = Color.LightSeaGreen });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.DamageType = DamageClass.Throwing;
            }
        }


    }
    public class ThoriumsBullshit : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<Bullshit4>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
           


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica))
            {
                item.rare = ItemRarityID.Expert;
                item.damage = 255;
                item.useTime = 15;
                item.useAnimation = 15;
            }
        }


    }
    public class ParaSepta : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<Septicemia>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("Paracosm", out Mod ParaMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Paracosm): Supercharged by the remains of an eldritch being") { OverrideColor = Color.MediumVioletRed });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("Paracosm", out Mod ParaMerica))
            {
                item.rare = ItemRarityID.Red;
                item.damage = 42;
                item.useTime = 7;
                item.useAnimation = 7;
            }
        }


    }
    public class FabsolKillingTheClimate : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<ClimateChanger>();
        }

        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                item.damage = 59;
                item.shootSpeed = 19.95f;
            }
        }


    }
    public class FabsolKillingTheClimat2e : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<SolarRayRifle>();
        }

        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                item.damage = 39/2;
               
            }
        }


    }
    public class CeramCalBuff : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<CarbonDioxideCeram>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Calamity): Now gives more defense ") { OverrideColor = Color.PaleVioletRed });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                item.defense = 4;
            }
        }


    }
    public class RadCalBuff : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<IrradiatedFisticuffs>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Calamity): Now gives more defense ") { OverrideColor = Color.PaleVioletRed });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                item.defense = 17;
            }
        }


    }
    public class CeramHorseCalBuff : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<CeramicHorseshoeBalloon>();
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {

                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Calamity): Now gives more defense ") { OverrideColor = Color.PaleVioletRed });
            }


        }
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                item.defense = 5;
            }
        }


    }
    
    
   
   
   
}