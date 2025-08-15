using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.Projectiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using gunrightsmod.Content.DamageClasses;

namespace gunrightsmod.Content.Items
{
    public class ChainReaction : ModItem
    {
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DildoWhipBuff.TagDamage);

        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<PlutoWhip>(), 33, 4, 3.75f);
            Item.rare = ItemRarityID.LightPurple;
            Item.damage = 104;
            Item.useTime = 42;
            Item.useAnimation = 42;
            Item.knockBack = 3;
            Item.ArmorPenetration = 15;
            Item.width = 14;
            Item.height = 14;
            Item.value = 170000;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "11 summon tag damage");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Summons a homing plutonium ray upon hitting an enemy")
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



            recipe.AddIngredient<Items.PlutoniumBar>(18);


            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();

        }

        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}