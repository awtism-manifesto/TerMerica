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
    public class Bullshit1 : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;
            Item.scale = 1.1f;
            Item.DamageType = ModContent.GetInstance<OmniDamage>();
            Item.damage = 35;
            Item.knockBack = 4.5f;
            Item.mana = 5;
            Item.ArmorPenetration = 5;
            Item.value = Item.buyPrice(gold: 67);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item8;

            Item.shoot = ModContent.ProjectileType<PearlProj>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 9.25f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }

       
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Shoots homing pink pearls with 9 summon tag damage");
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
            recipe.AddIngredient(ItemID.MetalDetector);
            recipe.AddIngredient(ItemID.GoldLadyBug);
            recipe.AddIngredient(ItemID.NypmhBanner);
            recipe.AddIngredient(ItemID.PinkPearl);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
            if (ModLoader.TryGetMod("SpiritReforged", out Mod SpiritMerica) && SpiritMerica.TryFind("GoldGarItem", out ModItem GoldGarItem))


            {
                recipe.AddIngredient(GoldGarItem.Type);


            }




        }

    }
}
