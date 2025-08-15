using Terraria;
using Terraria.ModLoader;

namespace gunrightsmod.Content.DamageClasses
{
    public class RangedMagicDamage : DamageClass
    {
        // This is an example damage class designed to demonstrate all the current functionality of the feature and explain how to create one of your own, should you need one.
        // For information about how to apply stat bonuses to specific damage classes, please instead refer to ExampleMod/Content/Items/Accessories/ExampleStatBonusAccessory.
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            // This method lets you make your damage class benefit from other classes' stat bonuses by default, as well as universal stat bonuses.
            // To briefly summarize the two nonstandard damage class names used by DamageClass:
            // Default is, you guessed it, the default damage class. It doesn't scale off of any class-specific stat bonuses or universal stat bonuses.
            // There are a number of items and projectiles that use this, such as thrown waters and the Bone Glove's bones.
            // Generic, on the other hand, scales off of all universal stat bonuses and nothing else; it's the base damage class upon which all others that aren't Default are built.
            if (damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;
            if (damageClass == DamageClass.Ranged)
                return StatInheritanceData.Full;
            if (damageClass == DamageClass.Summon)
                return StatInheritanceData.None;
            if (damageClass == DamageClass.Magic)
                return StatInheritanceData.Full;
            if (damageClass == DamageClass.Melee)
                return StatInheritanceData.None;
            if (damageClass == DamageClass.Throwing)
                return StatInheritanceData.None;
            if (damageClass == ModContent.GetInstance<StupidDamage>())
                return StatInheritanceData.None;


            return new StatInheritanceData(
                damageInheritance: 0f,
                critChanceInheritance: 0f,
                attackSpeedInheritance: 0f,
                armorPenInheritance: 0f,
                knockbackInheritance: 0f
            );
        }
        public override bool GetPrefixInheritance(DamageClass damageClass)
        {
           
            if (damageClass == DamageClass.Generic)
                return true;
            if (damageClass == DamageClass.Ranged)
                return true;
            if (damageClass == DamageClass.Magic)
                return true;

            return false;
        }
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            // This method allows you to make your damage class benefit from and be able to activate other classes' effects (e.g. Spectre bolts, Magma Stone) based on what returns true.
            // Note that unlike our stat inheritance methods up above, you do not need to account for universal bonuses in this method.
            // For this example, we'll make our class able to activate melee- and magic-specifically effects.
            if (damageClass == DamageClass.Ranged)
                return true;
            if (damageClass == DamageClass.Magic)
                return true;

            return false;
        }

        public override void SetDefaultStats(Player player)
        {
            // This method lets you set default statistical modifiers for your example damage class.
            // Here, we'll make our example damage class have more critical strike chance and armor penetration than normal.
            
           
            // These sorts of modifiers also exist for damage (GetDamage), knockback (GetKnockback), and attack speed (GetAttackSpeed).
            // You'll see these used all around in reference to vanilla classes and our example class here. Familiarize yourself with them.
        }





    }
}
