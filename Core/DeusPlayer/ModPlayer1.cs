using Terraria.ModLoader;
using Terraria;
using log4net.Appender;
using Terraria.ID;

using Deus.TestingMayContainOtherPeopleCode;

namespace Deus.Core.DeusPlayer
{
    public class ModPlayer1 : ModPlayer
    {
        public bool Ui1 = false;


        public override void PostUpdate()
        {
            if (Ui1 == true)
            {
                Player target = Main.LocalPlayer;

            }




            base.PostUpdate();
        }

    }
}
