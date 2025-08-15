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

namespace gunrightsmod.Content.Items
{
    public class IForgor : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.25f;
            Item.rare = ItemRarityID.Red; // The color that the item's name will be in-game.
            Item.value = 410000;


            // Use Properties
            Item.useTime = 11; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 22; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.reuseDelay = 46;
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.consumeAmmoOnLastShotOnly = true;


         


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 244; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 6f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
          
           

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 15.95f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Rocket; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.BushPlane>();
            SoundEngine.PlaySound(SoundID.Item163, player.position);
        }
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Converts rockets into pairs of exploding planes");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'Dude, this one is just plane awful'")
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
            
            recipe.AddIngredient(ItemID.SpectreBar, 9);
            recipe.AddIngredient(ItemID.FragmentVortex, 11);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-31f, -5f);
        }


    }
}