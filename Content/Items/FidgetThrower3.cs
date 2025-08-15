using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{

    public class FidgetThrower3 : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 33;
            Item.height = 33;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.autoReuse = true;


            Item.DamageType = ModContent.GetInstance<RangedStupidDamage>();
            Item.damage = 133;
            Item.knockBack = 7.5f;

            Item.noMelee = true;
            Item.value = Item.buyPrice(gold: 27);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item99;
            Item.scale = 1.175f;

            Item.shoot = ModContent.ProjectileType<FidgetSpinner3>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 24.25f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }
       


        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Shoots piercing fidget spinners that inflict even more random debuffs");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Does not require ammo")
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
            return new Vector2(-2f, -3f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient<Items.FidgetThrower2>();
            recipe.AddIngredient<Items.CyberneticGunParts>();
           
            recipe.AddIngredient(ItemID.VialofVenom, 33);
            recipe.AddIngredient(ItemID.CursedFlame, 33);
            recipe.AddIngredient(ItemID.Ichor, 33);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
          
        }

    }
}
