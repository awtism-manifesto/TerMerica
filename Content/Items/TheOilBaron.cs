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
    /// <summary>
    ///     Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
    ///     See Source code for Star Wrath projectile to see how it passes through tiles.
    ///     For a detailed sword guide see <see cref="ExampleSword" />
    /// </summary>
    public class TheOilBaron : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 31;
            Item.useTime = 31;
            Item.damage = 87;
            Item.knockBack = 9.25f;
            Item.width = 40;
            Item.height = 40;
            Item.shootSpeed = 7.33f;
            Item.scale = 1.35f;
            Item.ArmorPenetration = 10;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(gold: 50); // Sell price is 5 times less than the buy price.
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<OilSwing>();
            Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
            Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
            Item.autoReuse = true;
        }
       
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.
            type = ModContent.ProjectileType<OilBall>();                                             // Create a projectile.
            Projectile.NewProjectileDirect(source, position, velocity*1.667f, type, (int)(damage*0.725f), knockback, player.whoAmI);
           
            return true;
        }



        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Flings a small oil ball that inflicts Oiled");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Melee hits on Oiled enemies cause fiery explosions that deal massive damage")
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
          
            recipe.AddIngredient<WaterflameSword>();

            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient<RefinedOil>(50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();






        }
       

    }
}
