
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Global
{
    /// <summary>
    /// Handles the effects and weapon visuals of the shadow Weapon Imbue.
    /// See also ExampleFlask and ExampleWeaponImbue.
    /// </summary>
    public class ShadowImbueGlobal : ModPlayer
    {
        public bool shadowWeaponImbue = false;

        public override void ResetEffects()
        {
            shadowWeaponImbue = false;
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (shadowWeaponImbue && item.DamageType.CountsAsClass<MeleeDamageClass>())
            {
                target.AddBuff(BuffID.ShadowFlame, 61 * Main.rand.Next(3, 7));
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (shadowWeaponImbue && (proj.DamageType.CountsAsClass<MeleeDamageClass>() || ProjectileID.Sets.IsAWhip[proj.type]) && !proj.noEnchantments)
            {
                target.AddBuff(BuffID.ShadowFlame, 61 * Main.rand.Next(3, 7));
            }
        }

        // MeleeEffects and EmitEnchantmentVisualsAt apply the visual effects of the weapon imbue to items and projectiles respectively.
        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (shadowWeaponImbue && item.DamageType.CountsAsClass<MeleeDamageClass>() && !item.noMelee && !item.noUseGraphic)
            {
                if (Main.rand.NextBool(5))
                {
                    Dust dust = Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
                    dust.velocity *= 0.5f;
                }
            }
        }

        public override void EmitEnchantmentVisualsAt(Projectile projectile, Vector2 boxPosition, int boxWidth, int boxHeight)
        {
            if (shadowWeaponImbue && (projectile.DamageType.CountsAsClass<MeleeDamageClass>() || ProjectileID.Sets.IsAWhip[projectile.type]) && !projectile.noEnchantments)
            {
                if (Main.rand.NextBool(5))
                {
                    Dust dust = Dust.NewDustDirect(boxPosition, boxWidth, boxHeight, DustID.Shadowflame);
                    dust.velocity *= 0.5f;
                }
            }
        }
    }
}