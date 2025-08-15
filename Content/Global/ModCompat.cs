using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using gunrightsmod.Content.DamageClasses;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;

namespace gunrightsmod.Content.Global
{
    internal class ModCompat : ModSystem
    {
        public override void PostAddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod CalMerica);
            ModLoader.TryGetMod("ThoriumMod", out Mod ThorMerica);
            ModLoader.TryGetMod("Redemption", out Mod RedMerica);
            ModLoader.TryGetMod("Paracosm", out Mod ParaMerica);
            ModLoader.TryGetMod("Spooky", out Mod SpookMerica);
            ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoMerica);
            ModLoader.TryGetMod("Fargowiltas", out Mod FargoMerica2);
            ModLoader.TryGetMod("StarsAbove", out Mod StarMerica);
            ModLoader.TryGetMod("SpiritMod", out Mod SpiritMerica);
            ModLoader.TryGetMod("SOTS", out Mod SOTSMerica);
            ModLoader.TryGetMod("MagnoliaMod", out Mod MagMerica);
            ModLoader.TryGetMod("RecipeBrowser", out Mod RecipeBrowser);
        }
        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("RecipeBrowser", out Mod mod) && !Main.dedServ)
            {
                mod.Call(new object[5]
                {
            "AddItemCategory",
            "Stupid",
            "Weapons",
            Mod.Assets.Request<Texture2D>("Content/Global/StupidIcon"), // 24x24 icon
			(Predicate<Item>)((Item item) =>
            {
                if (item.damage > 0)
                {
                    return item.CountsAsClass<StupidDamage>();
                   
                }
                return false;
            })
                });
            }
        }
    }
    internal class MulticlassRecipe : ModSystem
    {

        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("RecipeBrowser", out Mod mod) && !Main.dedServ)
            {
                mod.Call(new object[5]
                {
            "AddItemCategory",
            "Multiclass",
            "Weapons",
            Mod.Assets.Request<Texture2D>("Content/Global/MulticlassIcon"), // 24x24 icon
			(Predicate<Item>)((Item item) =>
            {
                if (item.damage > 0 & item.CountsAsClass<MeleeStupidDamage>() || item.CountsAsClass<RangedStupidDamage>() || item.CountsAsClass<AutismDamage>()
                || item.CountsAsClass<OmniDamage>()|| item.CountsAsClass<MeleeMagicDamage>()|| item.CountsAsClass<RangedMagicDamage>()|| item.CountsAsClass<RangedSummonDamage>() 
                || item.CountsAsClass<MagicSummonDamage>()|| item.CountsAsClass<SummonStupidDamage>()|| item.CountsAsClass<MeleeRangedDamage>()|| item.CountsAsClass<MeleeSummonDamage>()|| item.CountsAsClass(DamageClass.Generic))
                {
                    return true;

                }
                return false;
            })
                });
            }
        }


    }

    }
