using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    /// <summary>
    ///     Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
    ///     See Source code for Star Wrath projectile to see how it passes through tiles.
    ///     For a detailed sword guide see <see cref="ExampleSword" />
    /// </summary>
    public class PortableTower : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }
        public override void SetDefaults()
        {
            Item.width = 33;
            Item.height = 33;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 1;
            Item.useAnimation = 5;
            Item.autoReuse = true;
            Item.reuseDelay = 3;
            Item.scale = 1.25f;

            Item.DamageType = ModContent.GetInstance<StupidDamage>();
            Item.damage = 95;
            Item.knockBack = 0;
            Item.noMelee = true;

            Item.value = 420000;
            Item.rare = ItemRarityID.Red;
           

            Item.shoot = ModContent.ProjectileType<A5G>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 14.5f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 3; // The number of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(6f));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.01f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }


        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Irradiates the area in front of you with harmful 5G that you cannot see or hear");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Bill Gates aint gonna like this one")
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
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6f, -15f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<Items.AstatineBar>(15);
            recipe.AddIngredient<Items.FragmentFlatEarth>(8);
            recipe.AddIngredient<Items.Iphone>();
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

    }
}
