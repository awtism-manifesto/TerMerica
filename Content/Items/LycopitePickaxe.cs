using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Dusts;
using gunrightsmod.Content.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    public class LycopitePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 27;
            Item.DamageType = DamageClass.Melee;
            Item.width = 35;
            Item.height = 35;
            Item.useTime = 10;
            Item.useAnimation = 16;
            

            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
               
            Item.value = 40000; // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost = 1;
            Item.pick = 85; // How strong the pickaxe is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Can mine Hellstone");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 2; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(target.position, target.width, target.height, (ModContent.DustType<LycopiteDust>()));
                dust.noGravity = true;
                dust.velocity *= 2.5f;
                dust.scale *= 0.66f;

            }
        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();



            recipe.AddIngredient<Items.LycopiteBar>(17);
            
            
            recipe.AddTile(TileID.Anvils);

            recipe.Register();
            
        }
    }
}