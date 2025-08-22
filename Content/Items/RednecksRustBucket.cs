using gunrightsmod.Content.Global;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
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
    public class RednecksRustBucket : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.8f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.value = 100000;


            // Use Properties
            Item.useTime = 21; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 21; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
           


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 37; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
           
            Item.ArmorPenetration = 10;

            // Gun Properties
            Item.shoot = ProjectileID.Bullet; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 10.15f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }


        public override bool AltFunctionUse(Player player)
        {


            return true;


        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            if (player.altFunctionUse == 2)
            {
                Item.noUseGraphic = true;
              
                int proj = Projectile.NewProjectile(source, position, velocity * 1.18f, ModContent.ProjectileType<RedneckShovel>(), (int)(damage * 0.95f), knockback, player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<RedneckCombo>().fromRedneckGun = false;
                SoundEngine.PlaySound(SoundID.Item1, player.position);

                return false;
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Item62, player.position);
                Item.noUseGraphic = false;
               
                int NumProjectiles = Main.rand.Next(3, 6); // The number of projectiles that this gun will shoot.
                damage = (int)(damage * Main.rand.NextFloat(0.43f, 0.445f));
                for (int i = 0; i < NumProjectiles; i++)
                {
                    // Rotate the velocity randomly by 30 degrees at max.
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(6f));

                    // Decrease velocity randomly for nicer visuals.
                    newVelocity *= 1f - Main.rand.NextFloat(0.335f);

                    // Create a projectile.
                    int proj = Projectile.NewProjectile(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                    Main.projectile[proj].GetGlobalProjectile<RedneckCombo>().fromRedneckGun = true;
                }
            }
            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        
        

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Shoots an indeterminate amount of bullets");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Right click to throw a shovel")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "Tag enemies with the shovel to power up your bullets")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "'They took er jerbs! They aint taking er guns next.'")
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
            return new Vector2(-29.25f, -2.66f);
        }
        public override void AddRecipes()
        {
            Recipe 
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.QuadBarrelShotgun);
            recipe.AddIngredient< ImprovisedMachineGun>();
            recipe.AddIngredient< ToothlessWyrm>();
            recipe.AddIngredient< Brainderbuss>();
            recipe.AddIngredient< UraniumShotgun>();
            
            
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("PurifiedGel", out ModItem PurifiedGel))
                {
                recipe.AddIngredient(PurifiedGel.Type, 10);

            }
            
        }
        }

    
}