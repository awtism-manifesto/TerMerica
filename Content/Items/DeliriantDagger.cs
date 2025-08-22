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

    public class DeliriantDagger : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 133;
            Item.knockBack = 0.5f;
            Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
            Item.useAnimation = 30;
            Item.useTime = 6;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item

            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.sellPrice(0, 20, 0, 10);

            Item.shoot = ModContent.ProjectileType<DaggerProj>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 5.95f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                Item.shootSpeed = 7.3f;
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
        //   int NumProjectiles = Main.rand.Next(7, 11); 

                

        //if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))

        // Projectile.NewProjectile(source, position, velocity * 3.1f, ModContent.ProjectileType<DaggerProjThrown>(), (int)(damage * 0.85f), knockback, player.whoAmI);
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            
           


            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                if (player.altFunctionUse == 2)
                {
                    int proj = Projectile.NewProjectile(source, position, velocity * 3.1f, ModContent.ProjectileType<DaggerProjThrown>(), (int)(damage * 0.85f), knockback, player.whoAmI);
                    Main.projectile[proj].GetGlobalProjectile<DeliriantComboSetup>().fromtheDeliriantDagger = true;
                   

                    return false;
                }
                else
                {
                    int NumProjectiles = Main.rand.Next(7, 10);
                    for (int i = 0; i < NumProjectiles; i++)
                    {



                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(360f));


                        Projectile.NewProjectile(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                      


                    }
                   

                    return true; // Prevent vanilla projectile spawn

                }
            }
            else
            {
                int NumProjectiles = Main.rand.Next(7, 10);
                for (int i = 0; i < NumProjectiles; i++)
                {



                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(360f));


                    Projectile.NewProjectile(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                  


                }

                return true; // Prevent vanilla projectile spawn

            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Multiple daggers rapidly stab all around the player");
            tooltips.Add(line);

           

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                line = new TooltipLine(Mod, "Face", "TerMerica Cross-Mod (TerBritish)- Right click to throw five daggers in quick succession")
                {
                    OverrideColor = new Color(255, 35, 90)
                };
                tooltips.Add(line);


                line = new TooltipLine(Mod, "Face", "Set up a combo by throwing the dagger, complete it by stabbing")
                {
                    OverrideColor = new Color(255, 35, 90)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Face", "Completed combos deal increased damage and sometimes cause an explosion of shadowflame sparks")
                {
                    OverrideColor = new Color(255, 35, 90)
                };
                tooltips.Add(line);



            }

            line = new TooltipLine(Mod, "Face", "'For when the hat man won't quit talking shit'")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);
           
            

            
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish) && TerBritish.TryFind<ModItem>("PlutoniumShank", out ModItem PlutoniumShank))
            {
                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.ShadowFlameKnife);
                recipe.AddIngredient(ItemID.PsychoKnife);

                recipe.AddIngredient(PlutoniumShank.Type);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

            }

            
            else
            {
                recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.ShadowFlameKnife);
                recipe.AddIngredient(ItemID.PsychoKnife);

                recipe.AddIngredient< PlutoniumBar>(12);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

            }

        }
        }
    }





