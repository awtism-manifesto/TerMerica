using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class RadRang : ModItem
    {
        

        public override void SetDefaults()
        {
            Item.width = 24; // The width of the item's hitbox.
            Item.height = 24; // The height of the item's hitbox.

            Item.useStyle = ItemUseStyleID.Shoot; // The way the item is used (e.g. swinging, throwing, etc.)
            Item.useTime = 18; // All vanilla yoyos have a useTime of 25.
            Item.useAnimation = 18; // All vanilla yoyos have a useAnimation of 25.
            Item.noMelee = true; // This makes it so the item doesn't do damage to enemies (the projectile does that).
            Item.noUseGraphic = true; // Makes the item invisible while using it (the projectile is the visible part).
            Item.UseSound = SoundID.Item1; // The sound that will play when the item is used.

            Item.damage = 32; // The amount of damage the item does to an enemy or player.
            Item.DamageType = DamageClass.MeleeNoSpeed; // The type of damage the weapon does. MeleeNoSpeed means the item will not scale with attack speed.
            Item.knockBack = 3.5f; // The amount of knockback the item inflicts.
            Item.ArmorPenetration = 10;
           
            Item.rare = ItemRarityID.Green; // The item's rarity. This changes the color of the item's name.
            Item.value = Item.buyPrice(gold: 1); // The amount of money that the item is can be bought for.

            Item.shoot = ModContent.ProjectileType<RadBoomerang>(); // Which projectile this item will shoot. We set this to our corresponding projectile.
            Item.shootSpeed = 12.25f; // The velocity of the shot projectile.			
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Releases a weakly homing uranium particle on hit");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "ignores 10 enemy armor")
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

        // Here is an example of blacklisting certain modifiers. Remove this section for standard vanilla behavior.
        // In this example, we are blacklisting the ones that reduce damage of a melee weapon.
        // Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes).
        private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy };

        public override bool AllowPrefix(int pre)
        {
            // return false to make the game reroll the prefix.

            // DON'T DO THIS BY ITSELF:
            // return false;
            // This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true.

            if (Array.IndexOf(unwantedPrefixes, pre) > -1)
            {
                // IndexOf returns a positive index of the element you search for. If not found, it's less than 0.
                // Here we check if the selected prefix is positive (it was found).
                // If so, we found a prefix that we don't want. Reroll.
                return false;
            }

            // Don't reroll
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();



            recipe.AddIngredient<Items.UraniumBar>(15);


            recipe.AddTile(TileID.Anvils);

            recipe.Register();

        }
    }
}