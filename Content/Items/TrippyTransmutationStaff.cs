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
   
    public class TrippyTransmutationStaff : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }
        public override void SetDefaults()
        {
            Item.width = 33;
            Item.height = 33;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 29;
            Item.useAnimation = 29;
            Item.autoReuse = true;
           
            Item.mana = 13;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 39;
            Item.knockBack = 3.5f;
            Item.noMelee = true;
           
            Item.value = 72000;
            Item.rare = ItemRarityID.Orange;
           

            Item.shoot = ModContent.ProjectileType<LycoRay>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 10.05f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }


        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<LycoRay>();
           



           

        }
       

       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Shoots a beam of Lycopite energy that randomly splits into other projectiles upon hitting an enemy");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "The beam can split into homing lycopite spores or an explosive mushroom")
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
            return new Vector2(6f, -15f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient<Items.LycopiteBar>(13);
            recipe.AddIngredient(ItemID.GlowingMushroom, 10);
            recipe.AddIngredient(ItemID.Mushroom, 5);
          

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }
}
