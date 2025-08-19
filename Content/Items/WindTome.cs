using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class WindTome : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.9f;
            Item.rare = ItemRarityID.Pink; // The color that the item's name will be in-game.
            Item.value = 140000;


            // Use Properties
            Item.useTime = 6; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 30; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.mana = 28;
            Item.reuseDelay = 15;

            // The sound that this item plays when used.
            Item.UseSound = SoundID.Item32;


            // Weapon Properties
            Item.DamageType = DamageClass.Magic; // Sets the damage type to ranged.
            Item.damage = 33; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            Item.ArmorPenetration = 15;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 8.75f; // The speed of the projectile (measured in pixels per frame.)
        }
       
        private int shotCounter = 0;
       
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Vector2 newVelocity = velocity.RotatedBy(MathHelper.ToRadians(0f));
            Vector2 new1Velocity = velocity.RotatedBy(MathHelper.ToRadians(1.5f));
            Vector2 new2Velocity = velocity.RotatedBy(MathHelper.ToRadians(-1.5f));
            Vector2 new3Velocity = velocity.RotatedBy(MathHelper.ToRadians(3f));
            Vector2 new4Velocity = velocity.RotatedBy(MathHelper.ToRadians(-3f));
            Vector2 new5Velocity = velocity.RotatedBy(MathHelper.ToRadians(4.5f));
            Vector2 new6Velocity = velocity.RotatedBy(MathHelper.ToRadians(-4.5f));
            Vector2 new7Velocity = velocity.RotatedBy(MathHelper.ToRadians(6f));
            Vector2 new8Velocity = velocity.RotatedBy(MathHelper.ToRadians(-6f));




            if (shotCounter <= 0)
            {
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                shotCounter = 2;
            }
            else if (shotCounter == 2)
            {
                Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                shotCounter = 5;
            }
            else if (shotCounter == 5)

            {
                damage = (int)(damage * Main.rand.NextFloat(0.95f, 0.95f));
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                shotCounter = 7;
            }
            else if (shotCounter == 7)
            {
                damage = (int)(damage * Main.rand.NextFloat(0.75f, 0.75f));
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new4Velocity, type, damage, knockback, player.whoAmI);
                shotCounter = 9;
            }
            else if (shotCounter == 9)
            {
                damage = (int)(damage * Main.rand.NextFloat(0.6f, 0.6f));
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new3Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new4Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new5Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new6Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new7Velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, new8Velocity, type, damage, knockback, player.whoAmI);
                shotCounter = 0;
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Fires a storm of deadly clouds that ramps up in intensity");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
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
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
           
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();





        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, -1f);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.WindTomeProjectile>();
        }
    }

}
