using Terraria.Audio;
using Terraria.ModLoader;

namespace Deus.Core.Systems
{

    public class DeusSounds : ModSystem
    {
        
        

        public static readonly SoundStyle CasualGunBang;

        public static readonly SoundStyle PistolGunBang;

        public static readonly SoundStyle PewterTink;


        //Had to change it to a static not a private static.
        static DeusSounds()
        {
            PistolGunBang = new SoundStyle("Deus/Assets/Sounds/PistolGunBang", (SoundType)0);
            CasualGunBang = new SoundStyle("Deus/Assets/Sounds/CasualGunBang", (SoundType)0);
            PewterTink = new SoundStyle("Deus/Assets/Sounds/PewterTink", (SoundType)0);
        }
    }
}