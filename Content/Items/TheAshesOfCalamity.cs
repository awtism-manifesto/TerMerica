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
    public class TheAshesOfCalamity : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.33f;
            Item.rare = ItemRarityID.Red; // The color that the item's name will be in-game.
            Item.value = 350000;


            // Use Properties
            // Use Properties
            Item.useTime =7; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 35; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            
            Item.consumeAmmoOnFirstShotOnly = true;
            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item45;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 111; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.ArmorPenetration = 20;

            


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Gel;
            Item.shootSpeed = 25f; // The speed of the projectile (measured in pixels per frame.)

        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.85f;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<DemonFlame>();

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2; // The number of projectiles that this gun will shoot.
            damage = (int)(damage * Main.rand.NextFloat(0.57f, 0.6f));
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5f));
                Vector2 new1Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5f));
                

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.44f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<DemonBall>();
                Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                type = ModContent.ProjectileType<Pentagram>();
              

            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }



       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Erupts a mortifying combination of demonic fire, demonic fireballs and homing pentagrams");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "WE SMOKING ON THAT FABSOL PACK #RIPBOZO #PACKWATCH")
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

            recipe.AddIngredient<Items.HephaestusCannon>();
            recipe.AddIngredient<Items.CardinalSin>();
            recipe.AddIngredient<Items.ZazaBreath>();
            recipe.AddIngredient<FissionDrive>();

            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("AshesofCalamity", out ModItem AshesofCalamity))
            {
                recipe.AddIngredient(AshesofCalamity.Type, 15);

            }






        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-24f, -2.5f);
        }
    }
}