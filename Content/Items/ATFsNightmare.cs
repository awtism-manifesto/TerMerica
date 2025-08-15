using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using gunrightsmod.Content.Projectiles;

namespace gunrightsmod.Content.Items
{
    public class ATFsNightmare : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1f;
            Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
            Item.value = 400000; // The value of the weapon in copper coins


            // Use Properties
            Item.useTime = 3; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 6; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.reuseDelay = 2;


          


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 60; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.crit = 15;
            Item.ArmorPenetration = 65;


            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 33.3f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }
        public override float UseSpeedMultiplier(Player player)
        {
            return 1f;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            
                type = ModContent.ProjectileType<TerraRound>();
           

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            SoundEngine.PlaySound(SoundID.Item68, player.position);
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.
            damage = (int)(damage * Main.rand.NextFloat(0.325f, 0.35f));
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(1.15f));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.4f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.85f;
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Converts bullets into Terra Rounds that make homing clones of themselves upon hitting an enemy");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Ignores a large portion of enemy defense")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "85% chance to not consume ammo")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "'The Right To Bear Arms.'")
            {
                OverrideColor = new Color(95, 90, 255)
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
            recipe.AddIngredient<BrokenHeroGun>();
            recipe.AddIngredient<TruthSeekersDMR>();
            recipe.AddIngredient<RednecksRevenge>();
            recipe.AddIngredient<MG42>();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 3f);
        }
    }
}