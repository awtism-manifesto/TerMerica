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
    /// <summary>
    ///     Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
    ///     See Source code for Star Wrath projectile to see how it passes through tiles.
    ///     For a detailed sword guide see <see cref="ExampleSword" />
    /// </summary>
    public class JusticeAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 5;
            Item.damage = 115;
            Item.knockBack = 11.5f;
            Item.width = 40;
            Item.height = 40;
            Item.mana = 3;
            Item.shootSpeed = 9.25f;
            Item.scale = 1.775f;
            Item.axe = 45;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.buyPrice(gold: 50); // Sell price is 5 times less than the buy price.
            Item.DamageType = ModContent.GetInstance<OmniDamage>();
            Item.shoot = ModContent.ProjectileType<JusticeSwing>();
            Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
            Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
            Item.autoReuse = true;
        }
       
        public override bool AltFunctionUse(Player player)
        {

            
                return true;
           
           
        }
        private int justiceaxecooldown = 0;
        public override void UpdateInventory(Player player)
        {
            if (justiceaxecooldown > 0)
                justiceaxecooldown--;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {

               
              
                if (justiceaxecooldown > 0)
                    return false;

                if (ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoMerica))//fixing weird fargos bug
                { justiceaxecooldown = 45; }
                else
                { justiceaxecooldown = 60; }



                player.AddBuff(ModContent.BuffType<RudeBusterCooldown>(), 60);
                SoundEngine.PlaySound(SoundID.Item82, player.position);
                SoundEngine.PlaySound(SoundID.Item132, player.position);

                Projectile.NewProjectile(source, position, velocity * 2.85f, ModContent.ProjectileType<RuderBuster>(), (int)(damage * 4.15f), (int)(knockback*2.75f), player.whoAmI);
                return false;
            }

            // Normal left-click logic unchanged
            float adjustedItemScale = player.GetAdjustedItemScale(Item);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);

            return true;
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Right click to fire an extremely devastating Red Buster");
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
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<ManeAx>();
            recipe.AddIngredient(ItemID.PickaxeAxe);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            





        }


    }
}
