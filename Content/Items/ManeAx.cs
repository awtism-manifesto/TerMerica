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
    public class ManeAx : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 10;
            Item.damage = 45;
            Item.knockBack = 9.25f;
            Item.width = 40;
            Item.height = 40;
            Item.shootSpeed = 7.25f;
            Item.scale = 1.5f;
            Item.axe = 23;
           
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 10); // Sell price is 5 times less than the buy price.
            Item.DamageType = ModContent.GetInstance<OmniDamage>();
            Item.shoot = ModContent.ProjectileType<ManeSwing>();
            Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
            Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
            Item.autoReuse = true;
            Item.mana = 0;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.mana = 10;
            }
            else
            {
                Item.mana = 0;

            }

            return base.CanUseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {

            
                return true;
           
           
        }
        private int maneaxcooldown = 0;
        public override void UpdateInventory(Player player)
        {
            if (maneaxcooldown > 0)
                maneaxcooldown--;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                // Check if cooldown is still active
                if (maneaxcooldown > 0)
                    return false;

                if (ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoMerica))//fixing weird fargos bug
                { maneaxcooldown = 45; }
                else
                { maneaxcooldown = 75; }



                player.AddBuff(ModContent.BuffType<RudeBusterCooldown>(), 75);
                SoundEngine.PlaySound(SoundID.Item82, player.position);
                SoundEngine.PlaySound(SoundID.Item132, player.position);

                Projectile.NewProjectile(source, position, velocity * 2.25f, ModContent.ProjectileType<RudeBuster>(), (int)(damage * 2.25f), (int)(knockback*2.25f), player.whoAmI);
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
            var line = new TooltipLine(Mod, "Face", "Right click to fire a devastating Rude Buster");
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
            recipe.AddIngredient(ItemID.CopperAxe);
            recipe.AddIngredient<KingslayerBar>(10);
            recipe.AddIngredient(ItemID.ShadowScale, 8);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperAxe);
            recipe.AddIngredient<KingslayerBar>(10);
            recipe.AddIngredient(ItemID.TissueSample, 8);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();





        }


    }
}
