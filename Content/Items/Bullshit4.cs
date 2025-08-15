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
    public class Bullshit4 : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30; 
            Item.useAnimation = 15;
            Item.autoReuse = true;
            Item.scale = 1.25f;
            Item.DamageType = ModContent.GetInstance<OmniDamage>();
            Item.damage = 215;
            Item.knockBack = 15.5f;
            Item.mana = 5;
            Item.ArmorPenetration = 50;
            Item.value = Item.buyPrice(gold: 550);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item8;

            Item.shoot = ModContent.ProjectileType<MoonProjFunny>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 15.95f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }

       
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Shoots moons that cause a chain reaction of bullshit upon hitting an enemy");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "-Dedicated Item-")
            {
                OverrideColor = new Color(252, 141, 204)
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
            recipe.AddIngredient<Items.Bullshit3>();
            recipe.AddIngredient(ItemID.GoldWaterStrider);
            recipe.AddIngredient(ItemID.CrabBanner);
            recipe.AddIngredient<Items.TheMoon>();
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("GoldLobster", out ModItem GoldLobster)
                && ThorMerica.TryFind("TheOmegaCore", out ModItem TheOmegaCore))

            {
                recipe.AddIngredient(GoldLobster.Type);
                recipe.AddIngredient(TheOmegaCore.Type);

            }




        }

    }
}
