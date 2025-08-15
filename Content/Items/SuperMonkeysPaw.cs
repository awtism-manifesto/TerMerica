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
    public class SuperMonkeysPaw : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.2f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.value = 75000;


            // Use Properties
            Item.useTime = 7; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 7; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Swing; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
           
            Item.noUseGraphic = true;
            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item1;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 15; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 3f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
           


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.


            Item.shootSpeed = 15.95f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Dart;
            Item.shoot = ProjectileID.PoisonDart;


        }

       

       
       

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Throws darts at high speed, high velocity, and with perfect accuracy");
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
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("LightAnguish", out ModItem LightAnguish)
                 && ThorMerica.TryFind("Embowelment", out ModItem Embowelment)
                 && (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("PurifiedGel", out ModItem PurifiedGel)))
                 


            {


                 recipe = CreateRecipe();
                recipe.AddIngredient<Items.TheMonkeysPaw>();
                recipe.AddIngredient(LightAnguish);
                recipe.AddIngredient(Embowelment);
                recipe.AddIngredient(PurifiedGel.Type, 10);

                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }
            if (ModLoader.TryGetMod("ThoriumMod", out Mod Thor2Merica) && Thor2Merica.TryFind("LightAnguish", out ModItem Light2Anguish)

                
                  && ThorMerica.TryFind("Embowelment", out ModItem Embowelment2))


            {


                recipe = CreateRecipe();
                recipe.AddIngredient<Items.TheMonkeysPaw>();
                recipe.AddIngredient(Light2Anguish);
                recipe.AddIngredient(Embowelment2);
               

                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }
            if (ModLoader.TryGetMod("CalamityMod", out Mod Cal2Merica) && Cal2Merica.TryFind<ModItem>("PurifiedGel", out ModItem Purified2Gel))
            {

                 recipe = CreateRecipe();
                recipe.AddIngredient<Items.TheMonkeysPaw>();
                recipe.AddIngredient<Items.Liquidation>();
                recipe.AddIngredient<Items.SacrificialPistol>();
                recipe.AddIngredient<Items.DiseaseBlaster>();
               
                recipe.AddIngredient(ItemID.Blowgun);
                recipe.AddIngredient(Purified2Gel.Type, 10);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();



            }
            else
            {
               recipe = CreateRecipe();
                recipe.AddIngredient<Items.TheMonkeysPaw>();
                recipe.AddIngredient<Items.Liquidation>();
                recipe.AddIngredient<Items.SacrificialPistol>();
                recipe.AddIngredient<Items.DiseaseBlaster>();
               
                recipe.AddIngredient(ItemID.Blowgun);

                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
                // recipe.AddIngredient(PurifiedGel.Type, 10);

            }


        }
        

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-28f, -3f);
        }
    }
}