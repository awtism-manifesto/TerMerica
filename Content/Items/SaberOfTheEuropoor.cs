using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
   
    public class SaberOfTheEuropoor : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.knockBack = 2f;
            Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
            Item.useAnimation = 13;
            Item.useTime = 13;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item

            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 10);

            Item.shoot = ModContent.ProjectileType<SaberProj>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 4.85f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
        }
        public override bool AltFunctionUse(Player player)
        {

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {

                if (type == ModContent.ProjectileType<SaberProj>())
                {
                    damage = (int)(damage * 1.45f);
                }
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {

                if (player.altFunctionUse == 2)
                {
                    Projectile.NewProjectile(source, position, velocity * 2.15f, ModContent.ProjectileType<SaberProjThrown>(), (int)(damage * 0.7f), knockback, player.whoAmI);
                    return false;
                }

            }




            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.
           
            
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(12f));



                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                line = new TooltipLine(Mod, "Face", "TerMerica Cross-Mod (TerBritish)- Right click to throw the saber")
                {
                    OverrideColor = new Color(255, 35, 90)
                };
                tooltips.Add(line);

            }

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
            recipe.AddIngredient(ItemID.SilverBar, 15);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverBar, 15);
            recipe.AddIngredient(ItemID.PlatinumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TungstenBar, 15);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TungstenBar, 15);
            recipe.AddIngredient(ItemID.PlatinumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }
}
