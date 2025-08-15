using gunrightsmod.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace gunrightsmod.Content.GlobalItems
{
    
    public class FuckYouCalamity : GlobalItem
    {
        // respectfully :)
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.Minishark;
        }

        public override void SetDefaults(Item item)
        {
            
            
            item.damage = 6;
            item.useTime = 8; 
            item.useAnimation = 8;
        }

       
    }
    public class FuckYouCalamity2 : GlobalItem
    {
        // respectfully :)
        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            return item.type == ItemID.StarCannon;
        }

        public override void SetDefaults(Item item)
        {


            item.damage = 55;
            item.useTime = 12;
            item.useAnimation = 12;
        }


    }
}