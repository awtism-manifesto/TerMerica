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
    public class SacrificialPistol : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.95f;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.value = 160000;


            // Use Properties
            Item.useTime = 5; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 5; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
          

            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item13;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 5; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 0.25f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.ArmorPenetration = 10;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.


            Item.shootSpeed = 19.5f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Dart;
            Item.shoot = ProjectileID.PoisonDart;


        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.75f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileID.BloodArrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.
            player.AddBuff(BuffID.Bleeding, 5);
            damage = (int)(damage * Main.rand.NextFloat(0.8f, 0.875f));
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(0.01f));

                

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Causes bleeding while in use");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Ignores 10 enemy defense")
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


            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(ItemID.TissueSample, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            if (ModLoader.TryGetMod("Spooky", out Mod SpookMerica) && SpookMerica.TryFind("LivingFleshItem", out ModItem LivingFleshItem))


            {

                recipe.AddIngredient(LivingFleshItem.Type, 45);

            }




        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -1f);
        }
    }
}