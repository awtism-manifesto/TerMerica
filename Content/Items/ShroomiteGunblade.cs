using gunrightsmod.Content.DamageClasses;
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
    public class ShroomiteGunblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1f;
            Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
            Item.value = 255000;


            // Use Properties
            Item.useTime = 5; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 10; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.reuseDelay = 12;
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
           

           


            // Weapon Properties
            Item.DamageType = ModContent.GetInstance<MeleeRangedDamage>();
            Item.damage = 120; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 6f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 13.12f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }


        public override bool AltFunctionUse(Player player)
        {


            return true;


        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = ItemUseStyleID.Swing;
                Item.useTime = 12;
                Item.useAnimation = 12;
                Item.reuseDelay = 0;
                Item.autoReuse= true;
                Item.useAmmo = AmmoID.None;
            }
            else
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useTime = 5;
                Item.useAnimation = 10;
                Item.reuseDelay = 12;
                Item.useAmmo = AmmoID.Bullet;
            }

            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
               
                float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
                Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), ModContent.ProjectileType<GunbladeSwing>(), (int)(damage*1.15f), knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
                NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

                SoundEngine.PlaySound(SoundID.Item71, player.position);

                return false;
            }
            else
            {
               
                SoundEngine.PlaySound(SoundID.Item40, player.position);


                damage = (int)(damage * Main.rand.NextFloat(0.99f, 0.995f));

                if (Main.rand.NextBool(3))
                {

                    type = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<GunbladeSpore>(), damage, knockback, player.whoAmI);
                    return false;
                }
                else
                {
                    return true; // Return false because we don't want tModLoader to shoot projectile}
                }
            }
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Left click to fire a rapid two round burst");
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "Has a chance to convert bullets into homing shroomite spores")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "Right click to swing a blade that releases shroomite spore clouds everywhere")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);



          
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-0.5f, -0.5f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
           
            recipe.AddIngredient(ItemID.ChlorophyteSaber);
            recipe.AddIngredient<Items.BulletBlade>();
            recipe.AddIngredient(ItemID.ShroomiteBar, 12);
           
           
            
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();





        }

    }
}