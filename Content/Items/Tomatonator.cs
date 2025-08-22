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
using gunrightsmod.Content.Projectiles;
using gunrightsmod.Content.DamageClasses;


namespace gunrightsmod.Content.Items
{
    public class Tomatonator : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.9f;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
            Item.value = 105000;


            // Use Properties
            // Use Properties
            Item.useTime = 12; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 12; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
           

            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item61;


            // Weapon Properties
            Item.DamageType = ModContent.GetInstance<StupidDamage>(); // Sets the damage type to ranged.
            Item.damage = 26; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 3.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
           




            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ModContent.ProjectileType<Tomato>();

            Item.shootSpeed = 16.5f; // The speed of the projectile (measured in pixels per frame.)

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Tomato>();

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(2.25f));
            newVelocity *= 1f - Main.rand.NextFloat(0.2f);
            if (Main.rand.NextBool(6))
            {
                type = ModContent.ProjectileType<Baconator>();
                Projectile.NewProjectileDirect(source, position, newVelocity*1.25f, type, (int)(damage* 2f), knockback, player.whoAmI);
            }
            else
            {
                type = ModContent.ProjectileType<Tomato>();
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }


          


            return false;
        }




        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Quickly shoots tomatoes at your enemies");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Has a small chance to fire a Wendy's Baconator that deals double damage")
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
          
            recipe.AddIngredient<LycopiteBar>(13);
         
          
          
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica) && SOTSMerica.TryFind("DissolvingNature", out ModItem DissolvingNature))


            {
                recipe.AddIngredient(DissolvingNature.Type);


            }



        }


        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-28.5f, -2.5f);
        }
    }
}