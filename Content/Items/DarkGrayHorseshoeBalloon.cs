using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    [AutoloadEquip(EquipType.Balloon)]
    public class DarkGrayHorseshoeBalloon : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory(29, 26);
            Item.SetShopValues(ItemRarityColor.LightRed4, Item.buyPrice(silver: 50));
        }

        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.GetJumpState<SimpleExtraJump>().Enable();
            player.jumpBoost = true;
            player.jumpSpeedBoost = 0.55f;
            player.noFallDmg = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient<Items.CarbonDioxideBalloon>();

            recipe.AddIngredient(ItemID.LuckyHorseshoe);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Allows the player to double jump, jump higher, and prevents fall damage");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Because screw having a stable climate am i right?")
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

    public class Carbon2ExtraJump : ExtraJump
    {
        public override Position GetDefaultPosition() => new After(BlizzardInABottle);



        public override float GetDurationMultiplier(Player player)
        {
            // Use this hook to set the duration of the extra jump
            // The XML summary for this hook mentions the values used by the vanilla extra jumps
            return 1.66f;
        }

        public override void UpdateHorizontalSpeeds(Player player)
        {
            // Use this hook to modify "player.runAcceleration" and "player.maxRunSpeed"
            // The XML summary for this hook mentions the values used by the vanilla extra jumps
            player.runAcceleration *= 2.5f;
            player.maxRunSpeed *= 1.8f;
        }

        public override void OnStarted(Player player, ref bool playSound)
        {
            // Use this hook to trigger effects that should appear at the start of the extra jump
            // This example mimics the logic for spawning the puff of smoke from the Cloud in a Bottle
            int offsetY = player.height;
            if (player.gravDir == -1f)
                offsetY = 0;

            offsetY -= 16;

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(player.position + new Vector2(-34f, offsetY), 102, 32, DustID.Cloud, -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, Color.Gray, 1.5f);
                dust.velocity = dust.velocity * 0.5f - player.velocity * new Vector2(0.1f, 0.3f);
            }


        }

        private static void SpawnCloudPoof(Player player, Vector2 position)
        {
            Gore gore = Gore.NewGoreDirect(player.GetSource_FromThis(), position, -player.velocity, Main.rand.Next(11, 14));
            gore.velocity.X = gore.velocity.X * 0.1f - player.velocity.X * 0.1f;
            gore.velocity.Y = gore.velocity.Y * 0.1f - player.velocity.Y * 0.05f;
        }

        public override void ShowVisuals(Player player)
        {
            // Use this hook to trigger effects that should appear throughout the duration of the extra jump
            // This example mimics the logic for spawning the dust from the Blizzard in a Bottle
            int offsetY = player.height - 6;
            if (player.gravDir == -1f)
                offsetY = 6;

            Vector2 spawnPos = new Vector2(player.position.X, player.position.Y + offsetY);

            for (int i = 0; i < 2; i++)
            {
                SpawnBlizzardDust(player, spawnPos, 0.1f, i == 0 ? -0.07f : -0.13f);
            }

            for (int i = 0; i < 3; i++)
            {
                SpawnBlizzardDust(player, spawnPos, 0.6f, 0.8f);
            }

            for (int i = 0; i < 3; i++)
            {
                SpawnBlizzardDust(player, spawnPos, 0.6f, -0.8f);
            }
        }

        private static void SpawnBlizzardDust(Player player, Vector2 spawnPos, float dustVelocityMultiplier, float playerVelocityMultiplier)
        {
            Dust dust = Dust.NewDustDirect(spawnPos, player.width, 12, DustID.Snow, player.velocity.X * 0.3f, player.velocity.Y * 0.3f, newColor: Color.Black);
            dust.fadeIn = 1.5f;
            dust.velocity *= dustVelocityMultiplier;
            dust.velocity += player.velocity * playerVelocityMultiplier;
            dust.noGravity = true;
            dust.noLight = true;
        }
    }
}