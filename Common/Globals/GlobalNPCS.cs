using Terraria.ModLoader;
using Terraria;
using log4net.Appender;
using Terraria.ID;

using Deus.TestingMayContainOtherPeopleCode;

namespace Deus.Common.Globals
{
    public class GlobalNPCS : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant)
            {
                shop.Add<LovecraftPaper>();
            }
        }
    }
}
