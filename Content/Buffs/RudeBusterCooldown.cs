using gunrightsmod.Content.DamageClasses;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace gunrightsmod.Content.Buffs
{
    public class RudeBusterCooldown : ModBuff
    {

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
           


        }

    }
}