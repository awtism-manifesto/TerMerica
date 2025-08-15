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
    public class Septicemia : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.value = 48000;


            // Use Properties
            // Use Properties
            Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item167;


            // Weapon Properties
            Item.DamageType = DamageClass.Magic; // Sets the damage type to ranged.
            Item.damage = 23; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            

            Item.mana = 8;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ProjectileID.PurificationPowder;

            Item.shootSpeed = 19.9f; // The speed of the projectile (measured in pixels per frame.)

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileID.BloodArrow;

        }



        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           

           
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(8.35f));
                Vector2 new1Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8.35f));
                Vector2 new2Velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8.35f));
                // Decrease velocity randomly for nicer visuals.


                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.BloodArrow;
            Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.TinyEater;
            Projectile.NewProjectileDirect(source, position, new2Velocity, type, damage, knockback, player.whoAmI);
                type = ProjectileID.TinyEater;



            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Spews a horrifying combination of mini eaters and blood shots")
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
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
            if (ModLoader.TryGetMod("Spooky", out Mod SpookMerica) && SpookMerica.TryFind("ArteryPiece", out ModItem ArteryPiece))


            {
                recipe.AddIngredient(ArteryPiece.Type, 10);


            }
            if (ModLoader.TryGetMod("Paracosm", out Mod ParaMerica) && ParaMerica.TryFind<ModItem>("NightmareScale", out ModItem NightmareScale)
              && ParaMerica.TryFind<ModItem>("DivineFlesh", out ModItem DivineFlesh))

            {
                recipe.AddIngredient(NightmareScale.Type, 6);

                recipe.AddIngredient(DivineFlesh.Type, 6);
            }



        }
        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12f, -1f);
        }
    }
}