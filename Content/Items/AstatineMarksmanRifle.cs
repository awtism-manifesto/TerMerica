using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;

namespace gunrightsmod.Content.Items
{
    public class AstatineMarksmanRifle : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 0.666f;
            Item.rare = ItemRarityID.Red; // The color that the item's name will be in-game.
            Item.value = 330000;


            // Use Properties
            Item.useTime = 19; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 19; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = SoundID.Item68;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 144; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 6f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            Item.ArmorPenetration = 45;
            Item.shoot = ProjectileID.Bullet;
            Item.useAmmo = ModContent.ProjectileType<Projectiles.TrueBullet>(); // Restrict the type of ammo the weapon can use, so that the weapon cannot use other ammos

            // Gun Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.AstatineBullet>(); // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 13f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.AstatineBullet>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Shoots effectively hitscan rounds that violently explode on impact, dealing huge impact damage");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "Ignores 45 enemy armor")
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

            recipe.AddIngredient<AstatineBar>(20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica) && ThorMerica.TryFind("DMR", out ModItem DMR))


            {
                recipe.AddIngredient(DMR.Type);


            }
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-31f, -1f);
        }


    }
}