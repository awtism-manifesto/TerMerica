using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class JevilishScythe : ModItem
    {


        public override void SetDefaults()
        {
            Item.width = 24; // The width of the item's hitbox.
            Item.height = 24; // The height of the item's hitbox.

            Item.useStyle = ItemUseStyleID.Shoot; // The way the item is used (e.g. swinging, throwing, etc.)
            Item.useTime = 32; // All vanilla yoyos have a useTime of 25.
            Item.useAnimation = 32; // All vanilla yoyos have a useAnimation of 25.
            Item.noMelee = true; // This makes it so the item doesn't do damage to enemies (the projectile does that).
            Item.noUseGraphic = true; // Makes the item invisible while using it (the projectile is the visible part).
            Item.UseSound = SoundID.Item71; // The sound that will play when the item is used.
            Item.mana = 5;
            Item.damage = 30; // The amount of damage the item does to an enemy or player.
            Item.DamageType = ModContent.GetInstance<OmniDamage>(); // The type of damage the weapon does. MeleeNoSpeed means the item will not scale with attack speed.
            Item.knockBack = 4.25f; // The amount of knockback the item inflicts.
           

            Item.rare = ItemRarityID.LightRed; // The item's rarity. This changes the color of the item's name.
            Item.value = Item.buyPrice(gold: 1); // The amount of money that the item is can be bought for.

            Item.shoot = ModContent.ProjectileType<JevilScythe>(); // Which projectile this item will shoot. We set this to our corresponding projectile.
            Item.shootSpeed = 17.33f; // The velocity of the shot projectile.			
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "5 summon tag damage");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Splits into smaller, homing clones of itself upon contact with an enemy")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
           
            line = new TooltipLine(Mod, "Face", "'I CAN DO ANYTHING'")
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
            recipe.AddIngredient(ItemID.DemoniteBar, 6);
            recipe.AddIngredient(ItemID.CrimtaneBar, 6);
            recipe.AddIngredient(ItemID.HellstoneBar, 6);
            recipe.AddIngredient<LycopiteBar>(6);
            recipe.AddIngredient(ItemID.ShadowKey);
            recipe.AddIngredient(ItemID.GoldenKey);
            recipe.AddIngredient<SkeletonKey>();

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("PurifiedGel", out ModItem PurifiedGel))
            {
                recipe.AddIngredient(PurifiedGel.Type, 10);

            }


        }
    }
}