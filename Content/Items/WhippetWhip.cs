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
    public class WhippetWhip : ModItem
    {
      

        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<WhippetProj>(), 20, 2, 3.75f);
            Item.rare = ItemRarityID.Green;
            Item.damage = 21;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.knockBack = 3;
            Item.width = 14;
            Item.height = 14;
            Item.value = Item.buyPrice(silver: 600);
            Item.DamageType = ModContent.GetInstance<SummonStupidDamage>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Swings really, really fast");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'My name lil t man'")
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


        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}