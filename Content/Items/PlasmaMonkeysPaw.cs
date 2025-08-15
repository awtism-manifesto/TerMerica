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


namespace gunrightsmod.Content.Items
{
    public class PlasmaMonkeysPaw : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.2f;
            Item.rare = ItemRarityID.Red; // The color that the item's name will be in-game.
            Item.value = 400000;


            // Use Properties
            Item.useTime = 5; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 5; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Swing; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
           
            Item.noUseGraphic = true;
            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item39;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 61; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 4.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.ArmorPenetration = 15;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.


            Item.shootSpeed = 19f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<PlasmaBlast>();


        }



        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<PlasmaBlast>();

        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Converts darts into superheated plasma blasts through forbidden monkey magic");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "The blasts ignore 15 enemy defense")
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
            Recipe
                 recipe = CreateRecipe();

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("WhiteDwarfFragment", out ModItem WhiteDwarfFragment))


            {

                
           
                recipe = CreateRecipe();
                recipe.AddIngredient<Items.LaserMonkeysPaw>();

                recipe.AddIngredient<Items.AstatineBar>(18);
               
                recipe.AddIngredient(WhiteDwarfFragment.Type, 8);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();


                


            }
            else
            {
               

                    recipe = CreateRecipe();
                recipe.AddIngredient<Items.LaserMonkeysPaw>();

                recipe.AddIngredient<Items.AstatineBar>(18);
                recipe.AddIngredient(ItemID.FragmentVortex, 8);

                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();



            }

        }
        

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-28f, -3f);
        }
    }
}