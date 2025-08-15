using Microsoft.Build.Evaluation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Items
{
    // This example is similar to the Wooden Arrow item
    public class UltrabrightArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 36;

            Item.damage = 17; // Keep in mind that the arrow's final damage is combined with the bow weapon damage.
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Pink;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 2.5f;
            Item.value = Item.sellPrice(copper: 95);
            Item.shoot = ModContent.ProjectileType<Projectiles.UltraArrowProj>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 2.3f; // The speed of the projectile.
            Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(500);
            recipe.AddIngredient(ItemID.UltrabrightTorch, 10);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.HellfireArrow, 250);
            recipe.AddIngredient(ItemID.FrostburnArrow, 250);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}