using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;




namespace gunrightsmod.Content.Items
{
    /// <summary>
    ///     Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
    ///     See Source code for Star Wrath projectile to see how it passes through tiles.
    ///     For a detailed sword guide see <see cref="ExampleSword" />
    /// </summary>
    public class VileGreatstaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 27;
            Item.useTime = 9;
            Item.damage =  66;
            Item.knockBack = 6.5f;
            Item.width = 40;
            Item.height = 40;
            Item.mana = 15;
            Item.shootSpeed = 13.95f;
            Item.scale = 1.05f;
         
           
           
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.buyPrice(gold: 20); // Sell price is 5 times less than the buy price.
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<VileFlame>();
            Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
          
            Item.autoReuse = true;
        }
       
        public override bool AltFunctionUse(Player player)
        {

            
                return true;
           
           
        }
        private int altClickCooldown = 0;
        public override void UpdateInventory(Player player)
        {
            if (altClickCooldown > 0)
                altClickCooldown--;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {



                // Check if cooldown is still active
                if (altClickCooldown > 0)
                    return false;

                // Set cooldown (e.g., 60 ticks = 1 second)
                altClickCooldown = 25;



                SoundEngine.PlaySound(SoundID.Item82, player.position);
                SoundEngine.PlaySound(SoundID.Item132, player.position);

                Projectile.NewProjectile(source, position = Main.MouseWorld, velocity * 1.66f, ModContent.ProjectileType<VileSpawn>(), (int)(damage * 1f), (int)(knockback * 1f), player.whoAmI);
                return false;
            }




            else
            {
                SoundEngine.PlaySound(SoundID.Item100, player.position);
                return true;
            }
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Left click to fire jets of cursed flame");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Right click to cause vile thorns to strike at the mouse position")
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
            recipe.AddIngredient<EbonwoodWand>();
            recipe.AddIngredient(ItemID.Vilethorn);
            recipe.AddIngredient(ItemID.CursedFlames);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            





        }


    }
}
