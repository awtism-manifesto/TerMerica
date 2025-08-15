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


namespace gunrightsmod.Content.Items
{
    public class PlanetoidPunisher : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.6f;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
            Item.value = 44000;


            // Use Properties
            // Use Properties
            Item.useTime = 40; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 40; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item68;


            // Weapon Properties
            Item.DamageType = DamageClass.Magic; // Sets the damage type to ranged.
            Item.damage = 21; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 3.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
           
            
            Item.mana = 12;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ProjectileID.PurificationPowder;

            Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileID.TopazBolt;

        }



        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {

                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(9.9f));
                Vector2 new2Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(9.9f));
                Vector2 new3Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(9.9f));
                Vector2 new4Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(9.9f));
                Vector2 new5Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(9.9f));
                Vector2 new6Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(9.9f));
               

                // Create a projectile.

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.DiamondBolt;
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.RubyBolt;
                Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.SapphireBolt;
                Projectile.NewProjectileDirect(source, position, new4Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.EmeraldBolt;
                Projectile.NewProjectileDirect(source, position, new5Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.AmethystBolt;
                Projectile.NewProjectileDirect(source, position, new6Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.AmberBolt;
              


            }

            return true; // Return false because we don't want tModLoader to shoot projectile
        }
       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Shoots a large spread of gem bolts")
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

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind<ModItem>("MagickStaff", out ModItem MagickStaff))
            {
                recipe = CreateRecipe();
               
                recipe.AddIngredient(MagickStaff.Type);
                recipe.AddIngredient(ItemID.SpaceGun);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }
            else
            {
                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.SpaceGun);
                recipe.AddIngredient(ItemID.Amethyst);
                recipe.AddIngredient(ItemID.Topaz);
                recipe.AddIngredient(ItemID.Sapphire);
                recipe.AddIngredient(ItemID.Emerald);
                recipe.AddIngredient(ItemID.Ruby);
                recipe.AddIngredient(ItemID.Amber);
                recipe.AddIngredient(ItemID.Diamond);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();

            }



        }
        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, -6f);
        }
    }
}