using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class TheMagnum : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 44; // Hitbox width of the item.
            Item.height = 18; // Hitbox height of the item.
            Item.scale = 0.9f;
            Item.rare = ItemRarityID.Cyan; // The color that the item's name will be in-game.
            Item.value = 240000;

            // Use Properties
            Item.useTime = 50; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 50; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.UseSound = SoundID.Item62; // The sound that this item plays when used.

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 343; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 9.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.ArmorPenetration = 50;

            // Gun Properties
            Item.shoot = ProjectileID.Bullet; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 13.5f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<Projectiles.MagnumShot>();
            }
            if (type == ModContent.ProjectileType<MagnumShot>())
            {
                damage = (int)(damage * 2.25f);
            }
        }

       
       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Converts musket balls into hitscan shots that deal incredible damage");
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

            if(ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("HitScanner", out ModItem HitScanner))
            {
                recipe = CreateRecipe();
                recipe.AddIngredient<Items.FreeBird>();
                recipe.AddIngredient(HitScanner.Type);
                recipe.AddIngredient<Items.CyberneticGunParts>();
               
              
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }
            else
            {
                recipe = CreateRecipe();
                recipe.AddIngredient<Items.FreeBird>();
                recipe.AddIngredient<Items.PulsePistols>();
                recipe.AddIngredient<Items.CyberneticGunParts>();
               
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

                

            }

        }

              
            




        
            
        

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15f, -3f);
        }
    }
}