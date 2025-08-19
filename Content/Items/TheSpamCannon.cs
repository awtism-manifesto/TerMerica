using gunrightsmod.Content.Buffs;
using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    
    public class TheSpamCannon : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.damage = 82;
            Item.knockBack = 5.5f;
            Item.width = 40;
            Item.height = 40;
            

            if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica))
            {

                Item.shootSpeed = 19.5f;

            }
            else
            {
                Item.shootSpeed = 18.25f;

            }

            Item.mana = 2;
           
            
            Item.UseSound = SoundID.Item61;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(gold: 115);
            Item.DamageType = ModContent.GetInstance<OmniDamage>();
            Item.shoot = ModContent.ProjectileType<Pipis>();
            Item.noMelee = true; 
          
            Item.autoReuse = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.mana = 20;
            }
            else
            {
                Item.mana = 2;

            }

            return base.CanUseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {

            
                return true;
           
           
        }
        private int spamcannoncooldown = 0;
        public override void UpdateInventory(Player player)
        {

            if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica))


            {
                if (Main.rand.NextBool(9))
                {
                    Item.damage = Main.rand.Next(70, 115);
                }


            }
            else
            {
                if (Main.rand.NextBool(9))
                {
                    Item.damage = Main.rand.Next(60, 105);
                }

            }

            if (Main.rand.NextBool(13))
            {
                Item.knockBack = Main.rand.NextFloat(2, 12);
            }
            if (Main.rand.NextBool(10))
            {
                Item.crit = Main.rand.Next(-15, 20);
            }
            if (Main.rand.NextBool(11))
            {
                Item.ArmorPenetration = Main.rand.Next(1, 15);
            }
            
            if (Main.rand.NextBool(15))
            {
                Item.value = Main.rand.Next(-100, 3250000);
            }

            if (spamcannoncooldown > 0)
                spamcannoncooldown--;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {

               
              
                if (spamcannoncooldown > 0)
                    return false;

                if (ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoMerica))//fixing weird fargos bug
                { spamcannoncooldown = 100; }
                else
                { spamcannoncooldown = 150; }



                player.AddBuff(ModContent.BuffType<BigShotCooldown>(), 150);
                SoundEngine.PlaySound(SoundID.Item14, player.position);
                SoundEngine.PlaySound(SoundID.Item62, player.position);
                SoundEngine.PlaySound(SoundID.NPCDeath56, player.position);

                Projectile.NewProjectile(source, position, velocity * 1.5f, ModContent.ProjectileType<BigShot>(), (int)(damage * 10.5f), (int)(knockback*25f), player.whoAmI);
                return false;
            }
            // Rotate the velocity randomly by 30 degrees at max.
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(4.5f));

            // Decrease velocity randomly for nicer visuals.
            newVelocity *= 1f - Main.rand.NextFloat(0.2f);

            // Create a projectile.
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);


            return false;
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Quickly fires splitting, bouncing [pipis]");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Right click to fire a [BIG SHOT] that destroys any living thing in your path")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "'Now's your chance to be a [BIG SHOT]'")
            {
                OverrideColor = new Color(Main.rand.Next(255), Main.rand.Next(255), Main.rand.Next(255))
            };
            tooltips.Add(line);

           
            
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5f, 4f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SnowmanCannon);
            recipe.AddIngredient<SmallSausageSpammer>();
            recipe.AddIngredient<CyberneticGunParts>();
            recipe.AddIngredient<PlutoniumBar>(12);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            if (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica) && CalMerica.TryFind<ModItem>("CoreofCalamity", out ModItem CoreofCalamity))
            {
                recipe.AddIngredient(CoreofCalamity.Type, 9);

            }

            if (ModLoader.TryGetMod("SOTS", out Mod SOTSMerica) && SOTSMerica.TryFind("PhaseBar", out ModItem PhaseBar))


            {
                recipe.AddIngredient(PhaseBar.Type, 6);


            }



        }


    }
}
