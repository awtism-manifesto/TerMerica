using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
   
    public class FissionRod : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }
        public override void SetDefaults()
        {
            Item.width = 33;
            Item.height = 33;
            Item.scale = 0.5f;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item72;
            Item.mana = 30;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 990;
            Item.knockBack = 20;
            Item.noMelee = true;
            Item.ArmorPenetration = 30;
            Item.value = 372000;
            Item.rare = ItemRarityID.Red;
           

            Item.shoot = ModContent.ProjectileType<AstaFission>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 8.25f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }


        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<AstaFission>();


            position = Main.MouseWorld;



        }
       

       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Causes a large, recursive explosion on the mouse position");
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
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 15f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<Items.BombScepter>();
            recipe.AddIngredient<FissionDrive>();
           
          
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

    }
}
