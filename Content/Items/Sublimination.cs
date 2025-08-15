using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using gunrightsmod.Content.Projectiles;


namespace gunrightsmod.Content.Items
{
    public class Sublimination : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.1f;
            Item.rare = ItemRarityID.Red; // The color that the item's name will be in-game.
            Item.value = 310000;


            // Use Properties
            // Use Properties
            Item.useTime = 7; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 21; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            
            Item.consumeAmmoOnFirstShotOnly = true;
            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item45;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 85; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 0.1f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.ArmorPenetration = 50;

            


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ModContent.ProjectileType<SublimRay>();
            Item.useAmmo = AmmoID.Gel;
            Item.shootSpeed = 15f; // The speed of the projectile (measured in pixels per frame.)

        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.8f;
        }
        private int tickCounter = 0;
        private int nextSpawnTick = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.
           
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedBy(MathHelper.ToRadians(3.8f));
                Vector2 new1Velocity = velocity.RotatedBy(MathHelper.ToRadians(1.9f));
                Vector2 new2Velocity = velocity.RotatedBy(MathHelper.ToRadians(0f));
                Vector2 new3Velocity = velocity.RotatedBy(MathHelper.ToRadians(-1.9f));
                Vector2 new4Velocity = velocity.RotatedBy(MathHelper.ToRadians(-3.8f));
               


                if (nextSpawnTick == 0)
                {
                    nextSpawnTick = 2;
                }
                tickCounter++;

                if (tickCounter >= nextSpawnTick && tickCounter < 3)
                {
                    if (Main.rand.NextBool(2))
                    {

                        type = ModContent.ProjectileType<SublimRay2>();
                        Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                    }
                    else
                    {
                        type = ModContent.ProjectileType<SublimRay>();
                        Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                    }
                    if (Main.rand.NextBool(2))
                    {

                        type = ModContent.ProjectileType<SublimRay>();
                        Projectile.NewProjectileDirect(source, position, new4Velocity, type, damage, knockback, player.whoAmI);
                    }
                    else
                    {
                        type = ModContent.ProjectileType<SublimRay2>();
                        Projectile.NewProjectileDirect(source, position, new4Velocity, type, damage, knockback, player.whoAmI);
                    }

                    type = ModContent.ProjectileType<SublimRay2>();
                    Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                    type = ModContent.ProjectileType<SublimRay>();
                    Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                    type = ModContent.ProjectileType<SublimRay2>();
                    Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                   


                    tickCounter = 5;
                    nextSpawnTick = 5;
                }
                else if (tickCounter >= 5)
                {

                    type = ModContent.ProjectileType<SublimRay>();
                    Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                    type = ModContent.ProjectileType<SublimRay2>();
                    Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                    type = ModContent.ProjectileType<SublimRay>();
                    Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                    tickCounter = 0;
                    nextSpawnTick = 2;

                }
                else
                {
                    type = ModContent.ProjectileType<SublimRay2>();
                    Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                    type = ModContent.ProjectileType<SublimRay>();
                    Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                    type = ModContent.ProjectileType<SublimRay2>();
                    Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);

                }

            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<SublimRay>();
            if (type == ModContent.ProjectileType<SublimRay>())
            {
                damage = (int)(damage * 0.495f);
            }
            if (type == ModContent.ProjectileType<SublimRay2>())
            {
                damage = (int)(damage * 0.5f);
            }
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Emits deadly rays that rapidly irradiate everything in front of you");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'It straight up smokes enemies. as in, it turns them into smoke.'")
            {
                OverrideColor = new Color(255, 255, 255)
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


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<Items.ClimateChanger>();
            recipe.AddIngredient(ItemID.FragmentVortex, 8);
            recipe.AddIngredient<Items.AstatineBar>(18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
            if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica) && SOTSMerica.TryFind("PhaseBar", out ModItem PhaseBar))


            {
                recipe.AddIngredient(PhaseBar.Type, 12);


            }




        }
        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-14f, 0f);
        }
    }
}