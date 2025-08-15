using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace gunrightsmod.Content.Items
{
    public class GunOfRoses : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.75f;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
            Item.value = Item.buyPrice(gold:30);


            // Use Properties
            // Use Properties
            Item.useTime = 11; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 11; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item28;


            // Weapon Properties
            Item.DamageType = DamageClass.Magic; // Sets the damage type to ranged.
            Item.damage = 21; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 2.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            

            Item.mana = 7;


            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.
            Item.shoot = ModContent.ProjectileType<Projectiles.RosePetal>();

            Item.shootSpeed = 10.25f; // The speed of the projectile (measured in pixels per frame.)

        }
        private int tickCounter = 0;
        private int nextSpawnTick = 0;
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.RosePetal>();

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.
           
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(2f));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.176f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            // Only run on the server
            if (nextSpawnTick == 0)
            {
                nextSpawnTick = Main.rand.Next(3, 4);
            }

            tickCounter++;

            if (tickCounter >= nextSpawnTick)
            {
                type = ModContent.ProjectileType<Projectiles.RosePetalBig>();

                Projectile.NewProjectileDirect(source, position, velocity, type, (int)(damage*1.5f), knockback, player.whoAmI);

                tickCounter = 0;
                nextSpawnTick = Main.rand.Next(3, 4);

                
            }



            return false; // Return false because we don't want tModLoader to shoot projectile
        }


        public override void AddRecipes()
        {
            Recipe 
            recipe = CreateRecipe();
            recipe.AddIngredient<Items.Heartache>();
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient<Items.LycopiteBar>(7);
            recipe.AddIngredient(ItemID.JungleRose);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("Petal", out ModItem Petal))


            {
                recipe.AddIngredient(Petal.Type, 4);


            }


        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Quickly shoots poisonous rose petals");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Occasionally shoots a larger, homing rose petal")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
            line = new TooltipLine(Mod, "Face", "'You know where you are? you're in the jungle baby! YOU'RE GONNA DIE!'")
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


        
        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-7f, 1f);
        }
    }
}