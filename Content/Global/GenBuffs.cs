using gunrightsmod.Content.DamageClasses;
using log4net.Core;
using Microsoft.Xna.Framework;
using gunrightsmod.Content.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;

namespace gunrightsmod.Content.GlobalItems
{
    // if you have to read through these unhinged ahh public classes and youre not Autism Manifesto, i apologize.
    public class ShroomBuff : GlobalItem
    {
       
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ShroomiteDiggingClaw;
        }

        public override void SetDefaults(Item item)
        {
            item.damage = 65;
            item.useTime = 3;
            item.pick = 205;
            item.useAnimation = 6;
            item.knockBack = 1.75f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased damage, swing speed, and pick speed") { OverrideColor = Color.MediumVioletRed });



        }

    }
    public class CandyCane696969 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CandyCaneSword;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Stats buffed all around") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.scale = 1.15f;
            item.useTime = 14;
            item.damage = 21;
            item.useAnimation = 14;
        }


    }
   
    public class FuckAntlions : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.AntlionClaw;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Decreased damage and size, but massively increased swing speed") { OverrideColor = Color.MediumVioletRed});



        }
        public override void SetDefaults(Item item)
        {
            item.scale = 0.95f;
            item.useTime = 7;
            item.damage = 11;
            item.useAnimation = 7;
            item.knockBack = 0.75f;
        }


    }
    public class MetalAmogus : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.MetalDetector;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now able to be used as a melee weapon") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.scale = 1.025f;
            item.DamageType = DamageClass.Melee;
            item.useTime = 15;
            item.damage = 15;
            item.useAnimation = 15;
            item.knockBack = 1.75f;
            item.useStyle = ItemUseStyleID.Swing;
        }


    }
    public class CockworkAssGun : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ClockworkAssaultRifle;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Damage and Velocity significantly increased") { OverrideColor = Color.MediumVioletRed });

            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Time between shots decreased, time between bursts increased") { OverrideColor = Color.MediumVioletRed });

        }
        public override void SetDefaults(Item item)
        {
            item.damage = 33;
            item.shootSpeed = 15.66f;
            item.useTime = 3;
            item.knockBack = 3.33f;
            item.useAnimation = 9;
            item.reuseDelay = 24;
        }


    }
    public class PenisMagnum : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.VenusMagnum;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Fires slower, but deals significantly more damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            
            item.damage = 125;
            item.useTime = 13;
          
            item.useAnimation = 13;
        }


    }
    public class ShittyShitgun : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TacticalShotgun;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Doubled fire rate, but incurs a damage penalty when using Chlorophyte Bullets") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.useTime = 18;
            item.damage = 27;
            item.useAnimation = 18;
           
        }

        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.ChlorophyteBullet)
            {
                damage = (int)(damage * 0.75f);
            }

        }
    }

    public class RipRalphiesEye : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.RedRyder;
        }

        public override void SetDefaults(Item item)
        {
           
            item.damage = 17;
            
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Slightly decreased damage, but shoots out an additional bloodshot with your bullet") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           
            Projectile.NewProjectileDirect(source, player.Center, velocity * 21.25f, ProjectileID.BloodArrow, damage, knockback, player.whoAmI);
           
            return true;
        }

    }
    public class BigGock : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BreakerBlade;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Massively increased damage and size, but slightly slower use speed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.scale = 1.5f;
            item.useTime = 40;
            item.damage = 115;
            item.useAnimation = 40;
        }


    }
    public class BloodyHell : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TendonBow;
        }

        public override void SetDefaults(Item item)
        {
           
            item.damage = 23;
            item.useTime = 24;
            item.useAnimation = 24;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Converts all arrows into high velocity blood shots") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectileDirect(source, player.Center, velocity * 29.95f, ProjectileID.BloodArrow, damage, knockback, player.whoAmI);

            return false;
        }

    }
    public class DemonTime : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.DemonBow;
        }

        public override void SetDefaults(Item item)
        {
           
            item.damage = 16;
            item.useTime = 23;
            item.useAnimation = 23;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Converts all arrows into Unholy Arrows") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectileDirect(source, player.Center, velocity * 3.1f, ProjectileID.UnholyArrow, damage, knockback, player.whoAmI);

            return false;
        }

    }
    public class CactusDildo : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CactusSword;
        }

        public override void SetDefaults(Item item)
        {
         
            item.damage = 10;
           
            item.shoot = ModContent.ProjectileType<CactusSpawn>();
            item.shootSpeed = 3f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Flings cactus spines with every swing") { OverrideColor = Color.MediumVioletRed });



        }
        
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectileDirect(source, player.Center, velocity * 4f, ModContent.ProjectileType<CactusSpawn>(), damage, knockback, player.whoAmI);

            return false;
        }

    }
    public class DarkCock : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.DarkLance;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased range, speed and damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           
            item.damage = 41;
            item.useTime = 17;
            item.useAnimation = 17;

            item.shootSpeed = 8.75f;
        }
        

    }
    public class AssGlaive : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.MonkStaffT2;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Significantly increased range") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.damage = 63;
            
            item.useTime = 25;
            item.useAnimation = 25;

            item.shootSpeed = 87.5f;
        }


    }
    public class FrostEEEEEE : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Frostbrand;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now shoots icy bolts every swing at a much higher velocity") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.damage = 49;

            item.useTime = 19;
            item.useAnimation = 19;

            item.shootSpeed = 19.5f;
        }


    }
    public class BEEEEEEZ : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BeeKeeper;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased size and damage, reduced swing speed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.damage = 43;
            item.scale = 1.75f;
            item.useTime = 25;
            item.useAnimation = 25;

           
        }


    }
    public class OnyxCock : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.OnyxBlaster;
        }
       
        public override void SetDefaults(Item item)
        {

            item.damage = 25;
            item.useTime = 45;
            item.useAnimation = 45;

            item.shootSpeed = 9.15f;
        }


    }
    public class Coballs : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CobaltSword;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.DamageType = DamageClass.Melee;
            item.useTime = 25;
            item.shoot = ModContent.ProjectileType<CobaltBolt>();
            item.shootSpeed = 5f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots a bolt of Cobalt energy") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f,  ModContent.ProjectileType<CobaltBolt>(), (int)(damage * 0.6f), knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<CobaltBolt>(), (int)(damage * 0.999f), knockback, player.whoAmI);
            }
            return false;
        }

    }
    public class Mlady : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PalladiumSword;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.DamageType = DamageClass.Melee;
            item.useTime = 28;
            item.shoot = ModContent.ProjectileType<PalladiumBolt>();
            item.shootSpeed = 7.25f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots a bolt of Palladium energy") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<PalladiumBolt>(), (int)(damage * 0.5f), knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<PalladiumBolt>(), (int)(damage * 0.999f), knockback, player.whoAmI);
            }
            return false;
        }

    }
    public class Milady : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.MythrilSword;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.DamageType = DamageClass.Melee;
            item.useTime = 26;
            item.shoot = ModContent.ProjectileType<MythrilBolt>();
            item.shootSpeed = 9.5f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots a bolt of Mythril energy") { OverrideColor = Color.MediumVioletRed });



        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<MythrilBolt>(), (int)(damage * 0.5f), knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<MythrilBolt>(), (int)(damage * 0.999f), knockback, player.whoAmI);
            }
            return false;
        }
    }
    public class PinkPussy : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.OrichalcumSword;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.DamageType = DamageClass.Melee;
            item.useTime = 28;
            item.shoot = ModContent.ProjectileType<OrichalcumBolt>();
            item.shootSpeed = 12.25f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots a bolt of Orichalcum energy") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<OrichalcumBolt>(), (int)(damage * 0.66f), knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<OrichalcumBolt>(), (int)(damage * 1.001f), knockback, player.whoAmI);
            }
            return false;
        }

    }
    public class Adamantitties : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.AdamantiteSword;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.DamageType = DamageClass.Melee;
            item.useTime = 27;
            item.shoot = ModContent.ProjectileType<AdamantiteBolt>();
            item.shootSpeed = 4f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots a bolt of Adamantite energy") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<AdamantiteBolt>(), (int)(damage * 0.9f), knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<AdamantiteBolt>(), (int)(damage * 1.02f), knockback, player.whoAmI);
            }
            return false;
        }

    }
    public class Tittyanium : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TitaniumSword;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.DamageType = DamageClass.Melee;
            item.useTime = 26;
            item.shoot = ModContent.ProjectileType<TitaniumBolt>();
            item.shootSpeed = 4.5f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots a bolt of Titanium energy") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica))
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<TitaniumBolt>(), (int)(damage * 0.92f), knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectileDirect(source, player.Center, velocity * 5f, ModContent.ProjectileType<TitaniumBolt>(), (int)(damage * 1.025f), knockback, player.whoAmI);
            }
            return false;
        }

    }
    public class Chudfucker6969 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BoneSword;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.useTime = 17;
            item.useAnimation = 17;

            item.shoot = ProjectileID.BoneGloveProj;
            item.shootSpeed = 4f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Flings bones with every swing") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectileDirect(source, player.Center, velocity * 4.5f, ProjectileID.BoneGloveProj, (int)(damage * 0.666f), knockback, player.whoAmI);

            return false;
        }

    }
    public class DrugsNir : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Gungnir;
        }

        public override void SetDefaults(Item item)
        {
            item.damage = 77;
            item.useTime = 17;
            item.useAnimation = 17;

            item.shoot = ModContent.ProjectileType<PiercingLight>();
            item.shootSpeed = 11.25f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots a piercing light beam, has higher stats") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectileDirect(source, player.Center, velocity * 4.5f, ModContent.ProjectileType<PiercingLight>(), (int)(damage * 0.777f), knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, player.Center, velocity * 1f, ProjectileID.Gungnir, (int)(damage * 1.01f), knockback, player.whoAmI);
            return false;
        }

    }
    public class HorsemansBladeBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TheHorsemansBlade;
        }

        public override void SetDefaults(Item item)
        {
            
            item.useTime = 19;
            item.useAnimation = 19;

           
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Significantly increased swing speed") { OverrideColor = Color.MediumVioletRed });



        }
        

    }
    public class HeatRayBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.HeatRay;
        }

        public override void SetDefaults(Item item)
        {

            item.useTime =7;
            item.useAnimation = 7;


        }
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Main.dayTime)
            {
                damage = (int)(damage * Main.rand.NextFloat(1.15f, 1.16f));


            }

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased fire rate, also deals increased damage during daytime") { OverrideColor = Color.MediumVioletRed });



        }


    }
    public class FlyingKnifeBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.FlyingKnife;
        }

        public override void SetDefaults(Item item)
        {

            item.damage = 119 / 2;


        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Damage increased by 35%") { OverrideColor = Color.MediumVioletRed });



        }


    }

    public class BigBoner : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<TheBoner>();
        }

       
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "Shoots out an additional bone with your rocket") { OverrideColor = Color.White });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectileDirect(source, player.Center, velocity * 17.5f, ProjectileID.BoneGloveProj, damage, knockback, player.whoAmI);

            return true;
        }

    }
    public class ImImpulsiveLol : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<ImpulseBow>();
        }


       
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectileDirect(source, player.Center, velocity * 17.5f, ModContent.ProjectileType<AstatineBullet>(), (int)(damage * 0.75f), knockback, player.whoAmI);

            return true;
        }

    }
    public class Anal12 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ModContent.ItemType<AA12>();
        }


        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.ChlorophyteBullet)
            {
                damage = (int)(damage * 0.5f);
            }

        }

    }

    public class Blowie : GlobalItem
    {
       
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Blowgun;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Shoots out a flurry of darts or seeds") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.StatsModifiedBy.Add(Mod);

            item.useTime = 8;
            item.useAnimation = 32;
            item.reuseDelay = 40;
        }


    }
    public class Icey : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.IceBlade;
        }
       
        public override void SetDefaults(Item item)
        {

            

            item.useTime = 38;
           
        }


    }
    public class EEEEEEEE : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.FairyQueenRangedItem;//eventide
        }
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

            damage = (int)(damage * 0.65f);
            if (type == ProjectileID.FairyQueenRangedItemShot)
            {
                damage = (int)(damage * 1.83f);
            }

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Converts wooden arrows into a CONSTANT barrage of twilight lances") { OverrideColor = Color.MediumVioletRed });

            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Deals less damage with other arrow types") { OverrideColor = Color.MediumVioletRed });

        }
      

        public override void SetDefaults(Item item)
        {


            item.rare = ItemRarityID.Cyan;
            item.useTime = 3;
            item.useAnimation = 15;
            item.shootSpeed = 15.25f;
           
            item.damage = 33;
        }


    }
    public class Enchantedy : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.EnchantedSword;
        }

        public override void SetDefaults(Item item)
        {



            item.useTime = 40;

        }


    }
    public class MeowHaiiiUwU : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.SpiritFlame;
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<MagicSummonDamage>();
            
            item.useTime = 17;
            item.useAnimation = 17;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals magic AND summon damage, increased fire rate") { OverrideColor = Color.MediumVioletRed });



        }


    }
    public class JackingOffRN : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.JackOLanternLauncher;
        }

        public override void SetDefaults(Item item)
        {

            item.shootSpeed = 15.95f;
            item.useTime = 18;
            item.useAnimation = 18;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Massively increased velocity and fire rate") { OverrideColor = Color.MediumVioletRed });

           

        }


    }
    public class FrostyCock : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.WandofFrosting;
        }

        public override void SetDefaults(Item item)
        {

            item.damage = 18;
            item.useTime = 21;
            item.useAnimation = 21;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased speed and damage") { OverrideColor = Color.MediumVioletRed });



        }

    }
    public class WoodUwU : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PearlwoodSword;
        }

        public override void SetDefaults(Item item)
        {
            
            item.damage = 45;
            item.useTime = 10;
            item.useAnimation = 10;
            item.scale = 2f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: 1.5x damage, 2x size, and 3x speed ") { OverrideColor = Color.MediumVioletRed });



        }

    }
    public class Laserz420 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.LaserRifle;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Hits much harder, but fires slower") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.damage = 51;
            item.useTime = 16;
            item.useAnimation = 16;

        }


    }
    public class Peanix : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PhoenixBlaster;
        }

        public override void SetDefaults(Item item)
        {

            item.damage = 31;
            item.useTime = 13;
            item.useAnimation = 13;

        }


    }
    public class Banana : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Bananarang;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
            item.DamageType = ModContent.GetInstance<StupidDamage>();
            item.damage = 61;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Stupid damage") { OverrideColor = Color.MediumVioletRed });



        }

    }
    public class GolemStupid : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.GolemFist;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
            item.DamageType = ModContent.GetInstance<MeleeStupidDamage>();
            item.damage = 135;
            item.shootSpeed = 32.5f;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Melee AND Stupid damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));
            Projectile.NewProjectileDirect(source, player.Center, velocity * 0.8f, ProjectileID.GolemFist, damage, knockback, player.whoAmI);

            return true;
        }




    }
    public class RulerStupid : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Ruler;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Melee AND Stupid damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MeleeStupidDamage>();
            item.damage = 30;
        }


    }
    public class PewStupid : GlobalItem
    {
        // Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PewMaticHorn;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Ranged AND Stupid damage, stats adjusted") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           
            item.DamageType = ModContent.GetInstance<RangedStupidDamage>();
            item.useTime = 12;
            item.useAnimation = 12;
            item.shootSpeed = 16.5f;
          
        }


    }
    public class SandStupid : GlobalItem
    {
      
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Sandgun;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Ranged AND Stupid damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<RangedStupidDamage>();
            

        }


    }
    public class YouShouldDriveDrunk : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.AleThrowingGlove;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats massively buffed, no longer requires ammo, and now deals Stupid damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<StupidDamage>();
            item.rare = ItemRarityID.Green;
            item.damage = 54;
            item.useTime = 28;
            item.shootSpeed = 15.75f;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.Swing;
            item.useAmmo = AmmoID.None;

        }


    }
    public class HamBattt : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.HamBat;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats buffed, now deals Melee AND Stupid damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<MeleeStupidDamage>();
           
            item.damage = 69;
            item.useTime = 16;
          
            item.useAnimation = 16;
            item.scale = 1.66f;

        }


    }
    public class KeyBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Keybrand;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Obtainable earlier, but with reworked stats") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           
            item.rare = ItemRarityID.LightPurple;
            item.damage = 65;
            item.scale = 2f;
            item.useTime = 12;
            item.useAnimation = 12;

        }


    }
    public class Pirahna : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PiranhaGun;
        }

        public override void SetDefaults(Item item)
        {
           
            item.DamageType = ModContent.GetInstance<RangedSummonDamage>();
           
            item.ArmorPenetration = 10;

        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Ranged AND summon damage + ignores 10 enemy defense") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class Scourge : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ScourgeoftheCorruptor;
        }

        public override void SetDefaults(Item item)
        {
          
            item.DamageType = ModContent.GetInstance<MeleeRangedDamage>();

          

        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals melee AND ranged damage") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class Vamp : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.VampireKnives;
        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MeleeMagicDamage>();
            item.damage = 33;
            item.mana = 7;
            item.useTime = 14;
            item.useAnimation = 14;
            item.shootSpeed = 27.75f;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals melee AND magic damage, stats adjusted") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class NettleAss : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.NettleBurst;
        }

        public override void SetDefaults(Item item)
        {

          
            item.damage = 70;
            item.ArmorPenetration = 20;
            item.shootSpeed = 36f;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Damage and armor penetration doubled") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class IGobbleAss : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.SkyFracture;
        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MeleeMagicDamage>();
           
            item.mana = 14;
            item.reuseDelay = 16;
            item.noMelee = false;

        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals magic AND melee damage, stats adjusted") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class IGobbleAssUwU : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.UnholyTrident;
        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MeleeMagicDamage>();
            item.damage = 96;
            item.mana = 16;
            item.shootSpeed = 21.5f;
            item.useTime = 14;
            item.useAnimation = 14;

        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals magic AND melee damage, stats adjusted") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class Terraprimsma : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.EmpressBlade;//Terraprisma
        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MeleeSummonDamage>();
            item.noMelee = false;
            item.scale = 1.33f;
            item.mana = 3;
            item.useTime = 14;
            item.useAnimation = 14;


        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals summon AND melee damage") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class Frosty : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.StaffoftheFrostHydra;
        }

        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<MagicSummonDamage>();

            item.damage = 198;


        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals summon AND magic damage, massively increased damage") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class IAmSOFuckingGay : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.RainbowGun;
        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MagicSummonDamage>();

            item.damage = 69;

        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals magic AND summon damage, increased damage") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class DesertTiger : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.StormTigerStaff;
        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MeleeSummonDamage>();



        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals summon AND melee damage") { OverrideColor = Color.MediumVioletRed });



        }
    }
    public class CutBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Cutlass;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased size and speed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {


            item.StatsModifiedBy.Add(Mod);
            item.scale = 1.25f;
            item.useTime = 11;
            item.useAnimation = 11;

        }


    }
    public class KandyKorn: GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CandyCornRifle;
        }

        public override void SetDefaults(Item item)
        {
            
            item.damage = 81;
            item.useTime = 12;
            item.useAnimation = 12;
            item.shootSpeed = 23.95f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Can use candy corn OR bullets as ammo, deals boosted damage with candy corn") { OverrideColor = Color.MediumVioletRed });



        }
        public override void ModifyShootStats(Item item,Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
           if (type == ProjectileID.CandyCorn)
            {
                damage = (int)(damage * 1.667f);
            }

        }

    }
    public class Flameeeer : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Flamethrower;
        }

        public override void SetDefaults(Item item)
        {

          

            item.damage = 38;
           
            item.shootSpeed = 15.1f;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Drastically increased range") { OverrideColor = Color.MediumVioletRed });



        }

    }
    public class ElfFlameeeer : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ElfMelter;
        }

        public override void SetDefaults(Item item)
        {

            

            item.damage = 58;

            item.shootSpeed = 18.05f;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Drastically increased range") { OverrideColor = Color.MediumVioletRed });



        }

    }
    public class KandyKorn2 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CandyCorn;
        }

        public override void SetDefaults(Item item)
        {

            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.

            item.damage = 24;
            item.ammo = AmmoID.Bullet;
            item.rare = ItemRarityID.Yellow;
            item.shootSpeed = 15.95f;

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Can be used as bullets, Deals extra damage when fired out of the Candy Corn Rifle ") { OverrideColor = Color.MediumVioletRed });

           

        }

    }
    public class Steak2 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Stake;
        }

        public override void SetDefaults(Item item)
        {

            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
            
            item.ammo = AmmoID.Arrow;
            item.rare = ItemRarityID.Yellow;


        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
           
            
                tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Can be used as ammo in all bows as well as the Stake Launcher") { OverrideColor = Color.MediumVioletRed });
               
              
            
        }

    }
    public class Nailz : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Nail;
        }

        public override void SetDefaults(Item item)
        {

           
            item.damage = 6;
            item.ammo = AmmoID.Dart;
            item.rare = ItemRarityID.Orange;


        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "Sticks into enemies and explodes after a short time") { OverrideColor = Color.White });

            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Can be used as ammo in all dartguns as well as the Nail Gun") { OverrideColor = Color.MediumVioletRed });

           

        }

    }
    public class Pinkeeeee : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PinkGel;
        }

        public override void SetDefaults(Item item)
        {

           
            item.damage = 4;
            item.DamageType = DamageClass.Ranged;
            item.ammo = AmmoID.Gel;
            item.rare = ItemRarityID.Blue;
            item.shoot = ModContent.ProjectileType<GelShot>();
            item.shootSpeed = 1.33f;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
           
            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Can be used as ammo in flamethrowers") { OverrideColor = Color.MediumVioletRed });


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "Shoots bouncy gel shots instead of fire") { OverrideColor = Color.White });

        }

    }
    public class Bubbly : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BubbleGun;
        }

        public override void SetDefaults(Item item)
        {


            item.shootSpeed = 26.5f;
         



        }


    }
    public class Gemz1 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.SapphireStaff;
        }

        public override void SetDefaults(Item item)
        {


            item.useTime = 29;
            item.useAnimation = 29;



        }
       

    }
    public class Gemz2 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.EmeraldStaff;
        }

        public override void SetDefaults(Item item)
        {


            item.useTime = 27;
            item.useAnimation = 27;



        }


    }
    
    public class Gemz3 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.RubyStaff;
        }

        public override void SetDefaults(Item item)
        {


            item.useTime = 23;
            item.useAnimation = 23;



        }


    }
    public class Gemz4 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.DiamondStaff;
        }

        public override void SetDefaults(Item item)
        {


            item.useTime = 21;
            item.useAnimation = 21;
            


        }


    }
    public class Steak : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.StakeLauncher;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
            item.damage = 120;
            item.useTime = 16;
            item.useAnimation = 16;
            item.shootSpeed = 15.95f;
            item.useAmmo = AmmoID.Arrow;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Can use stakes or arrows as ammo") { OverrideColor = Color.MediumVioletRed });



        }


    }
    public class Nailzzz : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.NailGun;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
            item.damage = 123;
           
            item.shootSpeed = 15.99f;
            item.useAmmo = AmmoID.Dart;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Can use nails or darts as ammo") { OverrideColor = Color.MediumVioletRed });



        }


    }
    public class Bonerhahafunnyimlosingmymind : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BoneArrow;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased damage and velocity") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           
            item.damage = 10;

            item.shootSpeed = 6.33f;
           
        }
        


    }
    public class Harpussy : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Harpoon;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
            item.damage = 32;
            item.useTime = 40;
            item.useAnimation = 40;
            item.shootSpeed = 11.25f;
            item.useAmmo = AmmoID.Dart;
            item.UseSound = SoundID.Item99;
        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           
            
            
                Projectile.NewProjectileDirect(source, player.Center, velocity * 3f, ModContent.ProjectileType<HarpoonProj>(), (int)(damage * 1.05f), knockback, player.whoAmI);
            
            return false;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Converts darts into powerful harpoons that pierce multiple enemies") { OverrideColor = Color.MediumVioletRed });



        }


    }
    public class WaffleTime : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.WaffleIron;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Melee AND Stupid damage, stats increased") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           
            item.DamageType = ModContent.GetInstance<MeleeStupidDamage>();
            item.rare = ItemRarityID.LightPurple;
            item.damage = 95;
            item.useTime = 17;
            item.useAnimation = 17;
            item.scale = 1.35f;
            item.shootSpeed = 25.75f;
           
        }
       


    }

    public class Moone : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BlueMoon;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
            item.ArmorPenetration = 25;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now ignores 25 enemy defense") { OverrideColor = Color.MediumVioletRed });



        }


    }


    public class NightsEdgeBuff : GlobalItem
    {
        
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.NightsEdge;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats significantly buffed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            

            item.damage = 55;
            item.scale = 1.1f;
            item.ArmorPenetration = 15;
            item.useTime = 18;
            item.useAnimation = 18;
        }


    }
    public class ExcaliburBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Excalibur;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats significantly buffed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           

            item.damage = 100;
            item.scale = 1.1f;
           
            item.useTime = 17;
            item.useAnimation = 17;
        }


    }
    public class TrueExcaliburBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TrueExcalibur;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats significantly buffed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            

            item.damage = 108;
            item.scale = 1.15f;

            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class YouAreAwful : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.EmpressButterfly;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now able to be used as bait, if you're a terrible enough person.") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           
            item.bait = 115;
           
        }


    }
    public class TrueNightsBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TrueNightsEdge;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats significantly buffed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
           

            item.damage = 97;
            item.scale = 1.25f;

            item.useTime = 26;
            item.useAnimation = 26;
        }


    }
    public class TerraBuff : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TerraBlade;
        }

        public override void SetDefaults(Item item)
        {
           

            item.damage = 111;
            item.scale = 1.11f;

            
        }


    }
    public class Feesh : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ObsidianSwordfish;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats massively buffed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.StatsModifiedBy.Add(Mod);
            item.useTime = 15;
           
            item.useAnimation = 15;
            item.damage = 135;
            item.ArmorPenetration = 25;
            item.shootSpeed = 9.5f;
        }


    }
    public class MagicFagic : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.MagicMirror;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class Cock : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.MagicConch;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class DemonCock : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.DemonConch;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class MagicFagic1 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CellPhone;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class MagicFagic2 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.IceMirror;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class Shelly : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Shellphone;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class Shelly1 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ShellphoneSpawn;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class Shelly2 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ShellphoneHell;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class Shelly3 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ShellphoneOcean;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Faster use animation") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {



            item.useTime = 15;
            item.useAnimation = 15;
        }


    }
    public class FalconPUNCH : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.FalconBlade;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Much faster swing speed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {


           
            item.useTime = 9;
            item.useAnimation = 9;
        }


    }
    public class StripperPole : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.NorthPole;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Damage significantly buffed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {


            item.damage = 125;
            item.useTime = 24;
            item.useAnimation = 24;
            item.shootSpeed = 8.67f;
            
        }


    }
    public class ChainCunt : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ChainGun;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Decrased damage, but massively increased fire rate") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

           
            item.damage = 22;
            item.useTime = 2;
            item.useAnimation = 4;
            item.reuseDelay = 1;


        }


    }
    public class Stiingeer : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Stynger;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Decrased damage, but massively increased fire rate") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {


            item.damage = 39;
            item.useTime = 14;
            item.useAnimation = 14;
           


        }


    }
    public class Cummies : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Umbrella ;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now guaranteed to crit") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            

            item.crit = 96;
        }


    }
    public class CummiesYummiesUWU : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.TragicUmbrella;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Guaranteed to crit, massively increased damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);

            item.damage = 48;
            item.crit = 96;
        }


    }
    public class Icee : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.IceBow;
        }

        public override void SetDefaults(Item item)
        {


            item.damage = 51;

        }


    }
    public class ShadowTheEdgehog: GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ShadowFlameBow;
        }

        public override void SetDefaults(Item item)
        {


            item.damage = 69;

        }


    }
    public class Pee : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Revolver;
        }

        public override void SetDefaults(Item item)
        {


            item.damage = 25;

        }


    }
    public class Peenitzes : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Starfury;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now does melee AND magic damage, stats adjusted") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<MeleeMagicDamage>();
            item.mana = 5;
            item.useTime = 23;
            item.useAnimation = 23;

        }


    }
    public class UwUorOwOorSomethingidk : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.StarWrath;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now does melee AND magic damage, stats adjusted") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<MeleeMagicDamage>();
            item.mana = 8;
            item.damage = 185;
            item.useTime = 14;
            item.useAnimation = 14;
            item.shootSpeed = 13.75f;

        }


    }
    public class BloodyFuckingHellMate : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.BloodRainBow;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now does ranged AND magic damage, stats adjusted") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {
            item.DamageType = ModContent.GetInstance<RangedMagicDamage>();
            item.mana = 8;
            item.damage = 23;
            item.useTime = 17;
            item.useAnimation = 34;
            item.shootSpeed = 18f;
            item.consumeAmmoOnLastShotOnly = true;
        }


    }
    public class MeowMeowUwU : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PiercingStarlight;
        }

        public override void SetDefaults(Item item)
        {


            item.shootSpeed = 30.25f;

        }


    }
    public class Darty : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.DartRifle;
        }

        public override void SetDefaults(Item item)
        {


            item.damage = 57;
            item.useTime = 35;
            item.useAnimation = 35;
        }


    }
    public class Peenitz : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PossessedHatchet;
        }
        
        public override void SetDefaults(Item item)
        {


            item.damage = 111;
            item.useTime = 11;
            item.useAnimation = 11;
        }


    }
    public class Darty2 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.DartPistol;
        }

        public override void SetDefaults(Item item)
        {


            item.damage = 31;
            item.useTime = 17;
            item.useAnimation = 17;
        }


    }
    public class Darty3 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.IchorDart;
        }

        public override void SetDefaults(Item item)
        {


            item.damage = 5;
            
        }


    }
    public class MegasharkBuff69 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Megashark;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Increased damage and velocity") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {


            item.damage = 33;
            item.knockBack = 3f;
            item.shootSpeed = 12.25f;

        }


    }
    public class CalamityOverhaulSucksFuckingAss : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Muramasa;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: All stats significantly buffed") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {


            item.damage = 29;
            item.useTime = 14;
            item.useAnimation = 14;
            item.scale = 1.15f;
            item.ArmorPenetration = 5;
        }


    }
    public class NimbusBuff69 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.NimbusRod;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals magic AND summon damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MagicSummonDamage>();


        }


    }
    public class ClingerBuff69 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.ClingerStaff;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals magic AND summon damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MagicSummonDamage>();


        }


    }
    public class ZenithIsntStrongEnoughLmao : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Zenith;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Omni Damage, a combination of ALL damage classes") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<OmniDamage>();


        }


    }
    public class PulseMage : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.PulseBow;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals Ranged AND Magic damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<RangedMagicDamage>();
            item.mana = 5;
            item.damage = 85;

        }


    }
    public class CrimsonBuff69 : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.CrimsonRod;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica: Now deals magic AND summon damage") { OverrideColor = Color.MediumVioletRed });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MagicSummonDamage>();


        }


    }
    public class MagUrStupidLol : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind<ModItem>("Shortgun", out ModItem Shortgun))
            {
                return item.type == Shortgun.Type;
            }
            else
            {  
                return false;
            }
            
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Magnolia's Mod) - Now deals Now deals Ranged AND Stupid damage") { OverrideColor = Color.LightSkyBlue });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<RangedStupidDamage>();
            
            item.shootSpeed = 10.95f;
            item.useTime = 20;
            item.useAnimation = 20;
          
        }
        
    }
   
  
    
    public class KrisDeltaruneReal : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind<ModItem>("CopperQuadsword", out ModItem CopperQuadsword))
            {
                return item.type == CopperQuadsword.Type;
            }
            else
            {
                return false;
            }

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Magnolia's Mod) - Now deals Now deals Melee AND Stupid damage") { OverrideColor = Color.LightSkyBlue });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<MeleeStupidDamage>();

           

        }

    }
   
    public class MagUrStupiderLol : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind<ModItem>("BlueMaticHorn", out ModItem BlueMaticHorn))
            {
                return item.type == BlueMaticHorn.Type;
            }
            else
            {
                return false;
            }

        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {


            tooltips.Add(new TooltipLine(Mod, "Tooltip#1", "TerMerica Cross-Mod (Magnolia's Mod) - Now deals Ranged AND Stupid damage, ignores 25 enemy armor") { OverrideColor = Color.LightSkyBlue });



        }
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<RangedStupidDamage>();
            item.damage = 138;
            item.shootSpeed = 22.95f;
            item.useTime = 13;
            item.useAnimation = 13;
            item.ArmorPenetration = 25;
            
        }

    }
  
}