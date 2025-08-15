using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
   
    public class SandyScorpion : ModItem
    {

        
        public override void SetDefaults()
        {
            Item.width = 33;
            Item.height = 33;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 3;
            Item.useAnimation = 9;
            Item.reuseDelay = 7;
            Item.autoReuse = true;
           
            Item.mana = 7;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 22;
            Item.knockBack = 0.1f;
            Item.noMelee = true;
          
            Item.value = 17000;
            Item.rare = ItemRarityID.LightRed;
           

            Item.shoot = ModContent.ProjectileType<SandShot>(); // ID of the projectiles the sword will shoot
            Item.shootSpeed = 14.95f; // Speed of the projectiles the sword will shoot

            // If you want melee speed to only affect the swing speed of the weapon and not the shoot speed (not recommended)
            // Item.attackSpeedOnlyAffectsWeaponAnimation = true;

            // Normally shooting a projectile makes the player face the projectile, but if you don't want that (like the beam sword) use this line of code
            // Item.ChangePlayerDirectionOnShoot = false;
        }


        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<SandShot>();


         



        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The number of projectiles that this gun will shoot.
            SoundEngine.PlaySound(SoundID.Item151, player.position);

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(0.1f));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.01f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Rapidly shoots rough sand at your opponents");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
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
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 4f);
        }
        

    }
}
