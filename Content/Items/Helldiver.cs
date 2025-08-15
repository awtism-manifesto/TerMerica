using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace gunrightsmod.Content.Items
{
    public class Helldiver : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.5f;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
            Item.value = 44000;
            AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.RocketLauncher;



            // Use Properties
            // Use Properties
            Item.useTime = 35; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 35; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item88;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 45; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.





            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ProjectileID.RocketI;

            Item.shootSpeed = 16.8f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = ItemID.RocketI;


        }





      
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Uses rockets as ammo");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'The most effective way to spread democracy this side of the galaxy!'")
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

            if (ModLoader.TryGetMod("SpiritMod", out Mod SpiritMerica) && SpiritMerica.TryFind<ModItem>("LibertyItem", out ModItem LibertyItem))
            {
                recipe = CreateRecipe();
              
                recipe.AddIngredient(LibertyItem.Type);
                recipe.AddIngredient(ItemID.HellstoneBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }
            else
            {
                recipe.AddIngredient(ItemID.HellstoneBar, 16);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();


            }


        }
        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-14f, -7f);
        }
    }
}