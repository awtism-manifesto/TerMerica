using gunrightsmod.Content.Global;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
   
    public class VerdantClaymore : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.knockBack = 3.75f;
            Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
            Item.useAnimation = 11;
            Item.useTime = 11;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item

            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 5, 0, 10);

            Item.shoot = ModContent.ProjectileType<VerdantProj>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 5f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                Item.damage = 25;
                Item.useAnimation = 13;
                Item.useTime = 13;
            }


            }
        public override bool AltFunctionUse(Player player)
        {

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
        // Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(9f));
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(9f));


          
            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                if (player.altFunctionUse == 2)
                {
                    int proj = Projectile.NewProjectile(source, position, velocity * 2.25f, ModContent.ProjectileType<VerdantProjThrown>(), (int)(damage * 0.67f), (int)(knockback * 0.99f), player.whoAmI);
                    Main.projectile[proj].GetGlobalProjectile<VerdantComboSetup>().fromtheVerdantClaymore = true;
                    player.AddBuff(BuffID.Poisoned, 24);

                    return false;
                }
                else
                {
                    int proj = Projectile.NewProjectile(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                    Main.projectile[proj].GetGlobalProjectile<VerdantCombo>().fromVerdantClaymore = true;
                    Main.projectile[proj].GetGlobalProjectile<VerdantComboSetup>().fromtheVerdantClaymore = false;
                    player.AddBuff(BuffID.Poisoned, 24);
                    return false; // Prevent vanilla projectile spawn

                }
            }
            else
            {
                 Projectile.NewProjectile(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                player.AddBuff(BuffID.Poisoned, 24);
                return false; // Prevent vanilla projectile spawn

            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Deals great damage, but poisons the user");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                line = new TooltipLine(Mod, "Face", "TerMerica Cross-Mod (TerBritish)- Right click to throw the claymore")
                {
                    OverrideColor = new Color(255, 35, 90)
                };
                tooltips.Add(line);

                line = new TooltipLine(Mod, "Face", "Set up a combo by throwing the claymore, complete it by stabbing")
                {
                    OverrideColor = new Color(255, 35, 90)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Face", "Completed combos deal increased damage and grant the player a powerful but short life regen buff")
                {
                    OverrideColor = new Color(255, 35, 90)
                };
                tooltips.Add(line);


            }
          



              

           
        }
       

    }
}
