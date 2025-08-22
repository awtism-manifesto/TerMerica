using gunrightsmod.Content.Buffs;
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
public class VP70 : ModItem
    { 
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.8f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.value = 90000;

            // Use Properties
            Item.useTime = 13; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 13; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
          
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
          

            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item38;
            

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 44; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 2f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.crit = 2;
            Item.ArmorPenetration = 1;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 5.95f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }
        public override bool AltFunctionUse(Player player)
        {


            return true;


        }
        private int altClickCooldown = 0;
        public override void UpdateInventory(Player player)
        {
            if (altClickCooldown > 0)
                altClickCooldown--;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
           
          
           
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(2.05f));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.39f);
            Vector2 new2Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3.95f));

            // Decrease velocity randomly for nicer visuals.
            new2Velocity *= 1f - Main.rand.NextFloat(0.29f);
            Vector2 new3Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3.95f));

            // Decrease velocity randomly for nicer visuals.
            new3Velocity *= 1f - Main.rand.NextFloat(0.35f);



            if (player.altFunctionUse == 2)
            {
                // Check if cooldown is still active
                if (altClickCooldown > 0)
                    return false;

                // Set cooldown (e.g., 60 ticks = 1 second)
                altClickCooldown = 23;
                if (altClickCooldown < 0)
                {
                    SoundEngine.PlaySound(SoundID.Item38, player.position);
                    SoundEngine.PlaySound(SoundID.Item40, player.position);
                }
                int proj = Projectile.NewProjectile(source, position, newVelocity * 1f, type, (int)(damage * 0.87f), (int)(knockback * 0.78f), player.whoAmI);
                int proj2 = Projectile.NewProjectile(source, position, new2Velocity * 1f, type, (int)(damage * 0.81f), (int)(knockback * 0.78f), player.whoAmI);
                int proj3 = Projectile.NewProjectile(source, position, new3Velocity * 1f, type, (int)(damage * 0.72f), (int)(knockback * 0.78f), player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<VPCombo>().fromVP70 = true;
                Main.projectile[proj2].GetGlobalProjectile<VPCombo2>().fromVP702 = true;
                Main.projectile[proj3].GetGlobalProjectile<VPCombo3>().fromVP703 = true;
                Main.projectile[proj].GetGlobalProjectile<VPComboSetup>().fromtheVP70 = false;
                Main.projectile[proj2].GetGlobalProjectile<VPComboSetup>().fromtheVP70 = false;
                Main.projectile[proj3].GetGlobalProjectile<VPComboSetup>().fromtheVP70 = false;

                return false;
            }

            else
            {
                int proj = Projectile.NewProjectile(source, position, velocity * 1f, type, damage, knockback, player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<VPComboSetup>().fromtheVP70 = true;
                Main.projectile[proj].GetGlobalProjectile<VPCombo>().fromVP70 = false;
                Main.projectile[proj].GetGlobalProjectile<VPCombo2>().fromVP702 = false;
                Main.projectile[proj].GetGlobalProjectile<VPCombo3>().fromVP703 = false;
                return false; // Prevent vanilla projectile spawn
            }
           
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Left click to quickly fire single shots");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Right click to fire a three round burst")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Tag enemies with single shots to deal increased damage with bursts")
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
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient<Glock>();
          
            recipe.AddIngredient< Polymer>(25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
           
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-50f, 0f);
        }
    }
}
