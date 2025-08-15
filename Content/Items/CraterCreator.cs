using gunrightsmod.Content.DamageClasses;
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
    public class CraterCreator : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 99;
            Item.height = 99;
            Item.scale = 1.5f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.autoReuse = true;

            Item.DamageType = ModContent.GetInstance<MeleeStupidDamage>();
            Item.damage = 208;
            Item.knockBack = 12.5f;


            Item.value = Item.buyPrice(gold: 50);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item14;

            Item.shoot = ModContent.ProjectileType<Crater>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 13.2f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }
       


       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Creates a massive explosion with every swing");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Also try Magnolia's Mod!")
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

            recipe.AddIngredient<Items.FragmentFlatEarth>(8);
            recipe.AddIngredient(ItemID.MeteoriteBar,15);
            recipe.AddIngredient<Items.AstatineBar>(15);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("AstralBar", out ModItem AstralBar))
            {
                recipe.AddIngredient(AstralBar.Type, 5);

            }






        }

    }
}
