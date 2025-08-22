using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Rarities;


namespace gunrightsmod.Content.Items
{
    public class TheSecondAmendment : ModItem
    {
        
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 30; // Hitbox width of the item.
            Item.height = 62; // Hitbox height of the item.
            Item.scale = 1f;
            Item.rare = ModContent.RarityType<HotPink>(); // The color that the item's name will be in-game.
            Item.value = 50000000;

            // Use Properties
            Item.useTime = 13; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 13; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            
            Item.UseSound = SoundID.Item62; // The sound that this item plays when used.

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 1776; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 20f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            
            
            Item.ArmorPenetration = 176;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 19.95f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }
        

        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           
            damage = (int)(damage * 0.25f);





            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new1Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new2Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new3Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new4Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new5Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new6Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new7Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new8Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new9Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new10Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new11Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new12Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new13Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new14Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new15Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new16Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new17Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new18Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new19Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new20Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new21Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new22Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new23Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new24Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new25Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new26Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new27Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new28Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new29Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new30Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new31Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new32Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new33Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new34Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new35Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new36Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new37Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new38Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new39Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new40Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new41Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new42Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new43Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new44Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new45Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new46Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new47Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new48Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new49Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new50Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new51Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new52Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new53Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new54Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new55Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new56Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new57Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new58Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new59Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new60Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new61Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new62Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new63Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new64Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new65Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));

            Vector2 new66Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new67Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new68Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Vector2 new69Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(5, 14)));
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DracoRound>();
               
               
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<PhotonSpawn>();
                Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<RadShot>();
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<ChargeLaser>();
                Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<RadShot>();
                Projectile.NewProjectileDirect(source, position, new4Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<PlutoShot>();
                Projectile.NewProjectileDirect(source, position, new5Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<PlutoShot>();
                Projectile.NewProjectileDirect(source, position, new6Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<PlutoShot>();
                Projectile.NewProjectileDirect(source, position, new7Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<MagnumShot>();
                Projectile.NewProjectileDirect(source, position, new8Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<AstatineBullet>();
                Projectile.NewProjectileDirect(source, position, new9Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<MerFlare>();
                Projectile.NewProjectileDirect(source, position, new10Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<BeetleRoundProjectile>();
                Projectile.NewProjectileDirect(source, position, new11Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<MagnumShot>();
                Projectile.NewProjectileDirect(source, position, new12Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<fiveproj>();
                Projectile.NewProjectileDirect(source, position, new13Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DragonSpawnShadow>();
                Projectile.NewProjectileDirect(source, position, new14Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<Money>();
                Projectile.NewProjectileDirect(source, position, new15Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<ZazaSmoke>();
                Projectile.NewProjectileDirect(source, position, new16Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<JfkBullet>();
                Projectile.NewProjectileDirect(source, position, new17Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DaeRound>();
               
                
                Projectile.NewProjectileDirect(source, position, new18Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<JfkBullet>();
               
                Projectile.NewProjectileDirect(source, position, new19Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<FakeRocket2>();
                Projectile.NewProjectileDirect(source, position, new20Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<FakeRocket2>();
                Projectile.NewProjectileDirect(source, position, new21Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<FakeRocket2>();
                Projectile.NewProjectileDirect(source, position, new22Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<SpermRange>();
                Projectile.NewProjectileDirect(source, position, new23Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<FakeRocket2>();
                Projectile.NewProjectileDirect(source, position, new24Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<FakeRocket2>();
                Projectile.NewProjectileDirect(source, position, new25Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<CiaSpawn>();
               
                Projectile.NewProjectileDirect(source, position, new26Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<MerFlare>();
                Projectile.NewProjectileDirect(source, position, new27Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<CiaSpawn>();
                Projectile.NewProjectileDirect(source, position, new28Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<PulseShot>();
                Projectile.NewProjectileDirect(source, position, new29Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<TerraRound>();
                Projectile.NewProjectileDirect(source, position, new30Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.IchorBullet;
                Projectile.NewProjectileDirect(source, position, new31Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.CursedBullet;
                Projectile.NewProjectileDirect(source, position, new32Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.BlackBolt;
                Projectile.NewProjectileDirect(source, position, new33Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.VenomBullet;
                Projectile.NewProjectileDirect(source, position, new34Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<CryoBullet>();
                Projectile.NewProjectileDirect(source, position, new35Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.NanoBullet;
                Projectile.NewProjectileDirect(source, position, new36Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.SilverBullet;
                Projectile.NewProjectileDirect(source, position, new37Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.ZapinatorLaser;
                Projectile.NewProjectileDirect(source, position, new38Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.ZapinatorLaser;
            Projectile.NewProjectileDirect(source, position, new39Velocity, type, damage, knockback, player.whoAmI);
            type = ModContent.ProjectileType<LycoSpawn>();
            Projectile.NewProjectileDirect(source, position, new40Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.SnowBallFriendly;
                Projectile.NewProjectileDirect(source, position, new41Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.CandyCorn;
                Projectile.NewProjectileDirect(source, position, new42Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.CrystalBullet;
                Projectile.NewProjectileDirect(source, position, new43Velocity, type, (int)(damage*1.66f), knockback, player.whoAmI);
                type = ModContent.ProjectileType<OilBallRanged>();
                Projectile.NewProjectileDirect(source, position, new44Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.PlatinumCoin;
                Projectile.NewProjectileDirect(source, position, new45Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.GoldCoin;
                Projectile.NewProjectileDirect(source, position, new46Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.SilverCoin;
                Projectile.NewProjectileDirect(source, position, new47Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.CopperCoin;
                Projectile.NewProjectileDirect(source, position, new48Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.SilverBullet;
                Projectile.NewProjectileDirect(source, position, new49Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.VortexBeaterRocket;
                Projectile.NewProjectileDirect(source, position, new50Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.MoonlordBullet;
                Projectile.NewProjectileDirect(source, position, new51Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.MoonlordBullet;
                Projectile.NewProjectileDirect(source, position, new52Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.MoonlordBullet;
                Projectile.NewProjectileDirect(source, position, new53Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.MoonlordBullet;
                Projectile.NewProjectileDirect(source, position, new54Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.MoonlordBullet;
                Projectile.NewProjectileDirect(source, position, new55Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.MoonlordBullet;
                Projectile.NewProjectileDirect(source, position, new56Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<CopperShort>();


            Projectile.NewProjectileDirect(source, position, new57Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.FairyQueenRangedItemShot;
                Projectile.NewProjectileDirect(source, position, new58Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.Shuriken;
                Projectile.NewProjectileDirect(source, position, new59Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.Bullet;
                Projectile.NewProjectileDirect(source, position, new60Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.GoldenBullet;
                Projectile.NewProjectileDirect(source, position, new61Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.Bullet;
                Projectile.NewProjectileDirect(source, position, new62Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.MeteorShot;
                Projectile.NewProjectileDirect(source, position, new63Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.BulletHighVelocity;
                Projectile.NewProjectileDirect(source, position, new64Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.ChlorophyteBullet;
                Projectile.NewProjectileDirect(source, position, new65Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.BloodArrow;
                Projectile.NewProjectileDirect(source, position, new66Velocity, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, position, new67Velocity, type, damage, knockback, player.whoAmI);
            type = ProjectileID.ChlorophyteBullet;
            Projectile.NewProjectileDirect(source, position, new68Velocity, type, damage, knockback, player.whoAmI);
            type = ModContent.ProjectileType<MerFlare>();
            Projectile.NewProjectileDirect(source, position, new69Velocity, type, damage, knockback, player.whoAmI);
            type = ModContent.ProjectileType<PhotonSpawn>();
            Projectile.NewProjectileDirect(source, position, new69Velocity, type, damage, knockback, player.whoAmI);
            if (Main.rand.NextBool(69))
            {
                
                type = ModContent.ProjectileType<RiverHead>();
                Projectile.NewProjectileDirect(source, position, new69Velocity, type, damage, knockback, player.whoAmI);
            }


            return true; // Return true because we do want tModLoader to shoot projectile
        }

       
       

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Spews out a truly absurd amount of munitions. ");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "We once fought for the false promise of freedom. Now we must fight for true freedom. 161.")
            {
                OverrideColor = new Color(255, 45, 95)
            };
            tooltips.Add(line);



            // Here we will hide all tooltips whose title end with ':RemoveMe'
            // One like that is added at the start of this method
            foreach (var l in tooltips)
            {
                if (l.Name.EndsWith(":RemoveMe"))
                {
                    l.Hide();
                }
            }

            // Another method of hiding can be done if you want to hide just one line.
            // tooltips.FirstOrDefault(x => x.Mod == "ExampleMod" && x.Name == "Verbose:RemoveMe")?.Hide();
        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<TrueJfkExperience>();
            recipe.AddIngredient(ItemID.SDMG);
            recipe.AddIngredient<GlockAndBalls>();
            recipe.AddIngredient<AA12>();
            recipe.AddIngredient(ItemID.VortexBeater);
            recipe.AddIngredient<DaedalusStormgun>();
            recipe.AddIngredient<PhotonShotgun>();
            recipe.AddIngredient(ItemID.Xenopopper);
            recipe.AddIngredient<TheMagnum>();
            recipe.AddIngredient<ATFsNightmare>();

            recipe.AddIngredient<TheNanoshot>();

            recipe.AddIngredient(ItemID.CandyCornRifle);
            recipe.AddIngredient(ItemID.VenusMagnum);
            recipe.AddIngredient<MidnightAfterburner>();
            recipe.AddIngredient<PlutoniumAutoPistol>();
            recipe.AddIngredient<ThePrimeTime>();
            recipe.AddIngredient<CryonicCarbine>();
            recipe.AddIngredient<Bundlebuss>();
            recipe.AddIngredient<VP70>();

            recipe.AddIngredient(ItemID.SnowballCannon);
            recipe.AddIngredient<TheDeposer>();
            recipe.AddIngredient<CopperShortmachinegun>();
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish) && TerBritish.TryFind<ModItem>("BrenGun", out ModItem BrenGun))
            {
                recipe.AddIngredient(BrenGun.Type);
            }
            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind<ModItem>("GenderDefender", out ModItem GenderDefender)
         && MagMerica.TryFind<ModItem>("MintalMachinePistol", out ModItem MintalMachinePistol))

            {
                recipe.AddIngredient(GenderDefender.Type);
                recipe.AddIngredient(MintalMachinePistol.Type);
            }
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("SomaPrime", out ModItem SomaPrime)
                && CalMerica.TryFind<ModItem>("HalibutCannon", out ModItem HalibutCannon))


            {

                recipe.AddIngredient(SomaPrime.Type);

                recipe.AddIngredient(HalibutCannon.Type);
            }
            if (ModLoader.TryGetMod("ContinentOfJourney", out Mod HomeMerica) && HomeMerica.TryFind<ModItem>("Blackout", out ModItem Blackout)
               && HomeMerica.TryFind<ModItem>("FortSniper", out ModItem FortSniper))


            {

                recipe.AddIngredient(Blackout.Type);

                recipe.AddIngredient(FortSniper.Type);
            }
            if (ModLoader.TryGetMod("Paracosm", out Mod ParaMerica) && ParaMerica.TryFind<ModItem>("Hyperion", out ModItem Hyperion))


            {
                recipe.AddIngredient(Hyperion.Type);


            }
            if (ModLoader.TryGetMod("Macrocosm", out Mod MacroMerica) && MacroMerica.TryFind<ModItem>("ArtemiteMagnum", out ModItem ArtemiteMagnum)
                 && MacroMerica.TryFind<ModItem>("TychoDesertEagle", out ModItem TychoDesertEagle))
            {

                recipe.AddIngredient(ArtemiteMagnum.Type);
                recipe.AddIngredient(TychoDesertEagle.Type);
            }
            if (ModLoader.TryGetMod("ZenithGunReturn", out Mod ZenithMerica) && ZenithMerica.TryFind<ModItem>("ZenithGun", out ModItem ZenithGun))


            {
                recipe.AddIngredient(ZenithGun.Type);


            }
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind<ModItem>("TerrariumPulseRifle", out ModItem TerrariumPulseRifle)
               && ThorMerica.TryFind<ModItem>("OmniCannon", out ModItem OmniCannon)
                && ThorMerica.TryFind<ModItem>("TrenchSpitter", out ModItem TrenchSpitter))

            {
                recipe.AddIngredient(TrenchSpitter.Type);
                recipe.AddIngredient(TerrariumPulseRifle.Type);

                recipe.AddIngredient(OmniCannon.Type);

            }
            if (ModLoader.TryGetMod("Yorui", out Mod YorMerica) && YorMerica.TryFind<ModItem>("HomingMerchantGun", out ModItem HomingMerchantGun)
               && YorMerica.TryFind<ModItem>("ZappyZapperson", out ModItem ZappyZapperson)
                && YorMerica.TryFind<ModItem>("CARL", out ModItem CARL))

            {
                recipe.AddIngredient(HomingMerchantGun.Type);
                recipe.AddIngredient(ZappyZapperson.Type);

                recipe.AddIngredient(CARL.Type);

            }
            if (ModLoader.TryGetMod("Redemption", out Mod RedMerica) && RedMerica.TryFind<ModItem>("DepletedCrossbow", out ModItem DepletedCrossbow)
              && RedMerica.TryFind<ModItem>("XeniumElectrolaser", out ModItem XeniumElectrolaser))

            {
                recipe.AddIngredient(DepletedCrossbow.Type);

                recipe.AddIngredient(XeniumElectrolaser.Type);
            }
            if (ModLoader.TryGetMod("StarsAbove", out Mod StarMerica) && StarMerica.TryFind<ModItem>("CosmicDestroyer", out ModItem CosmicDestroyer)
              && StarMerica.TryFind<ModItem>("InheritedCaseM4A1", out ModItem InheritedCaseM4A1))

            {
                recipe.AddIngredient(CosmicDestroyer.Type);
                recipe.AddIngredient(InheritedCaseM4A1.Type);
            }
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoMerica) && FargoMerica.TryFind<ModItem>("TheBiggestSting", out ModItem TheBiggestSting)
          && FargoMerica.TryFind<ModItem>("NavalRustrifle", out ModItem NavalRustrifle)
          && FargoMerica.TryFind<ModItem>("Lightslinger", out ModItem Lightslinger))

            {

                recipe.AddIngredient(NavalRustrifle.Type);
                recipe.AddIngredient(Lightslinger.Type);
                recipe.AddIngredient(TheBiggestSting.Type);
            }

        }
        
        

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-45f, -4f);
        }
    }
}