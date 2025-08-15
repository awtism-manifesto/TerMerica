using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
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
    public class ChainThunderblade : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.damage = 19;
            Item.knockBack = 4.5f;
            Item.width = 40;
            Item.height = 40;
            Item.scale = 1f;
            Item.shootSpeed = 20f;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 10); // Sell price is 5 times less than the buy price.
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ThunderSwing>();
            Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
            Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("StormlionMandible", out ModItem StormlionMandible))
            {
                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.DemoniteBar, 6);
                recipe.AddIngredient<Items.RockSalt>(20);
                recipe.AddIngredient(StormlionMandible.Type, 3);
                recipe.AddIngredient(ItemID.FossilOre, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica) && SOTSMerica.TryFind("DissolvingEarth", out ModItem DissolvingEarth))


                {
                    recipe.AddIngredient(DissolvingEarth.Type);


                }

                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.CrimtaneBar, 6);
                recipe.AddIngredient<Items.RockSalt>(20);
                recipe.AddIngredient(StormlionMandible.Type, 3);
                recipe.AddIngredient(ItemID.FossilOre, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica2) && SOTSMerica2.TryFind("DissolvingEarth", out ModItem DissolvingEarth2))


                {
                    recipe.AddIngredient(DissolvingEarth2.Type);


                }

            }
            else
            {
                recipe = CreateRecipe();
                
                recipe.AddIngredient(ItemID.DemoniteBar, 7);
                recipe.AddIngredient(ItemID.FossilOre, 12);
                recipe.AddIngredient<Items.RockSalt>(25);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica2) && SOTSMerica2.TryFind("DissolvingEarth", out ModItem DissolvingEarth2))


                {
                    recipe.AddIngredient(DissolvingEarth2.Type);


                }

                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.CrimtaneBar, 7);
              
                recipe.AddIngredient(ItemID.FossilOre, 12);
                recipe.AddIngredient<Items.RockSalt>(25);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica3) && SOTSMerica3.TryFind("DissolvingEarth", out ModItem DissolvingEarth3))


                {
                    recipe.AddIngredient(DissolvingEarth3.Type);


                }
            }

        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Creates a homing, piercing thunderbolt upon hitting an enemy");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
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
        

    }
}
