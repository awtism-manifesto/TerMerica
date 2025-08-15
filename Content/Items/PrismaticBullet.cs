using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class PrismaticBullet : ModItem
    {

        public override void SetStaticDefaults()
        {
            // Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)


            ItemID.Sets.ItemIconPulse[Item.type] = true; // The item pulses while in the player's inventory
            ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the item have no gravity

            Item.ResearchUnlockCount = 99; // Configure the amount of this item that's needed to research it in Journey mode.
        }

        public override void SetDefaults()
        {
            Item.damage = 19; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;
            
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = 10000;
            Item.rare = ItemRarityID.Cyan;
            Item.shoot = ProjectileID.FairyQueenRangedItemShot;
            Item.shootSpeed = 19f; // The speed of the projectile.
            Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            if (ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica) && MagMerica.TryFind<ModItem>("EmpressOfLightIcon", out ModItem EmpressOfLightIcon))
            {
                recipe = CreateRecipe(1998);

                recipe.AddIngredient(EmpressOfLightIcon.Type);


                recipe.Register();
            }
            else
            {

                recipe = CreateRecipe(1332);
                recipe.AddIngredient<Items.AstatineBar>(6);
                recipe.AddIngredient<Items.PlutoniumBar>(4);
                recipe.AddIngredient<Items.UraniumBar>(2);
                recipe.AddIngredient(ItemID.HallowBossDye);
                recipe.AddIngredient(ItemID.EmptyBullet, 1332);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

            }

        }
        

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Makes your guns shoot twilight lances instead of bullets")
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