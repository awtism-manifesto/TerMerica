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
    public class LycopiteHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 33;
            Item.DamageType =  DamageClass.Melee;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 11;
            Item.useAnimation = 20;
            Item.scale = 1.2f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7.75f;
            
            Item.value = Item.buyPrice(gold: 3); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost = 1;
            
            Item.hammer = (int)(79.999f);
            Item.axe = (int)(19.4f);
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 3; i++) // Creates a splash of dust around the position the projectile dies.
            {
                Dust dust = Dust.NewDustDirect(target.position, target.width, target.height, (ModContent.DustType<LycopiteDust>()));
                dust.noGravity = true;
                dust.velocity *= 3.5f;
                dust.scale *= 0.75f;

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