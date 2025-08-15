using gunrightsmod.Content.DamageClasses;
using gunrightsmod.Content.Projectiles;
using gunrightsmod.Content.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
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
    public class LoreAccurateBlackshard : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.damage = 1600;
            Item.knockBack = 1f;
            Item.width = 6;
            Item.height = 6;
            Item.scale = 1f;
            Item.ArmorPenetration = 600;
            Item.shootSpeed = 6.66f;
            Item.UseSound = SoundID.Item39;
            Item.rare = ModContent.RarityType<Seizure>();
            Item.value = 666666666; // Sell price is 5 times less than the buy price.
            Item.DamageType = ModContent.GetInstance<OmniDamage>();
            Item.shoot = ModContent.ProjectileType<BlackshardProj>();
            Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
            Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
            Item.autoReuse = true;

            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) || (ModLoader.TryGetMod("CalamityMod", out Mod CalMerica)))

            {
                Item.damage = 2160;
                Item.useTime = 10;
                Item.useAnimation = 10;
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
       
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {

                if (player.altFunctionUse == 2)
                {
                    Projectile.NewProjectile(source, position, velocity * 2.15f, ModContent.ProjectileType<BlackshardThrown>(), (int)(damage * 0.7f), knockback, player.whoAmI);
                    return false;
                }

            }




            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

            return base.Shoot(player, source, position, velocity, type, damage, knockback);



        }




        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "");
            tooltips.Add(line);

            if (ModLoader.TryGetMod("Terbritish", out Mod TerBritish))
            {
                line = new TooltipLine(Mod, "Face", "TerMerica Cross-Mod (TerBritish)- Right click to throw the shard")
                {
                    OverrideColor = new Color(Main.rand.Next(165), Main.rand.Next(45), Main.rand.Next(45))
                };
                tooltips.Add(line);

            }

            line = new TooltipLine(Mod, "Face", "'Because River wouldn't stop asking'")
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
       

    }
}
