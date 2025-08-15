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


namespace gunrightsmod.Content.Items
{
    public class SolarRayRifle : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.775f;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
            Item.value = 105000;


            // Use Properties
            // Use Properties
            Item.useTime = 7; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 7; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = SoundID.DD2_LightningAuraZap;


            // Weapon Properties
            Item.DamageType = DamageClass.Magic; // Sets the damage type to ranged.
            Item.damage = 18; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 0.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
           

            Item.mana = 6;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ModContent.ProjectileType<Projectiles.SolarRay>();

            Item.shootSpeed = 17.75f; // The speed of the projectile (measured in pixels per frame.)

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.SolarRay>();
            if (Main.dayTime)
            {
                damage = (int)(damage * Main.rand.NextFloat(1.15f, 1.16f));


            }
        }



        

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Rapidly shoots deadly solar rays at the target");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Deals increased damage during daytime")
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

            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("AerialiteBar", out ModItem AerialiteBar))
            {
                recipe = CreateRecipe();
               
                recipe.AddIngredient(AerialiteBar.Type, 7);
                recipe.AddIngredient(ItemID.HellstoneBar, 7);
                recipe.AddIngredient<Items.KingslayerBar>(7);
                recipe.AddIngredient<Items.CrudeOil>(14);
                recipe.AddIngredient(ItemID.Lens, 4);
                recipe.AddIngredient(ItemID.IllegalGunParts);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }
            else
            {
                recipe = CreateRecipe();
                recipe.AddIngredient<Items.KingslayerBar>(12);
                recipe.AddIngredient(ItemID.HellstoneBar, 10);
               
                recipe.AddIngredient<Items.CrudeOil>(15);
                recipe.AddIngredient(ItemID.Lens, 4);
                recipe.AddIngredient(ItemID.IllegalGunParts);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();

              

            }

        }


        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-31.5f, 0f);
        }
    }
}