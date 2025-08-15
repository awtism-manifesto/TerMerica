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
using gunrightsmod.Content.DamageClasses;


namespace gunrightsmod.Content.Items
{
    public class SpaceTrasher : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.975f;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
            Item.value = 105000;


            // Use Properties
            // Use Properties
            Item.useTime = 11; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 44; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
           

            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item9;


            // Weapon Properties
            Item.DamageType = DamageClass.Magic; // Sets the damage type to ranged.
            Item.damage = 38; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 12.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.mana = 19;




            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ModContent.ProjectileType<SpaceTrash>();

            Item.shootSpeed = 21.5f; // The speed of the projectile (measured in pixels per frame.)

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<SpaceTrash>();

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            damage = (int)(damage * Main.rand.NextFloat(0.775f, 1.35f));
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
          
           
                position = player.Center - new Vector2(Main.rand.NextFloat(451) * player.direction, 600f);
                position.Y -= 100;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-70, 71) * 0.02f;
            if (Main.rand.NextBool(3))
            {
                type = ModContent.ProjectileType<SpaceTrash2>();
            }
            if (Main.rand.NextBool(3))
            {
                type = ModContent.ProjectileType<SpaceTrash3>();
            }
           
                Projectile.NewProjectile(source, position, heading, type, (int)(damage), knockback, player.whoAmI, 0f, ceilingLimit);
           


            return false;
        }




        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Drops burning space trash on your opponents");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Damage is more random than most weapons, with a positive bias")
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
            recipe.AddIngredient(ItemID.MeteoriteBar, 15);
            recipe.AddIngredient<Items.UraniumBar>(5);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddIngredient(ItemID.Wire, 65);
          
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("StrangeAlienTech", out ModItem StrangeAlienTech))


            {
                recipe.AddIngredient(StrangeAlienTech.Type);


            }




        }


        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -5f);
        }
    }
}