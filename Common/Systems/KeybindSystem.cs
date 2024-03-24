using Terraria.ModLoader;

namespace Deus.Common.Systems
{
    public class KeybindSystem : ModSystem
    {
       // public static ModKeybind Keybind { get; private set; }

        

        public override void Load()
        {
            // Registers a new keybind
            
            //Keybind = KeybindLoader.RegisterKeybind(Mod, "", "T");
        }
        //ngl this is straight from example mod but idc

        // Please see ExampleMod.cs' Unload() method for a detailed explanation of the unloading process.
        public override void Unload()
        {
          //  Keybind = null;
            
        }
    }
}