using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using System.Collections.Generic;
using Deus.Core.DeusPlayer;

namespace Deus.Content.Items.BookUI.Book1
{

    [Autoload(Side = ModSide.Client)]
    public class UiSystem : ModSystem
    {
        public const string UIPath1 = "Mods.Deus.UI";
        public UserInterface MainUserInterface;
        internal UiBar MainUI;

        public void GoBack()
        {
            MainUserInterface.GoBack();
        }
        public void ShowMyUI()
        {
            MainUserInterface?.SetState(MainUI);
        }

        public void HideMyUI()
        {
            MainUserInterface?.SetState(null);
        }

        public override void Load()
        {
            MainUserInterface = new UserInterface();
            MainUI = new UiBar();

            MainUI.Activate();
        }

        public override void UpdateUI(GameTime gameTime)
        {

            if (MainUserInterface?.CurrentState != null)
                MainUserInterface?.Update(gameTime);
        }


        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Coins Per Minute",
                    delegate
                    {
                        if (MainUserInterface?.CurrentState != null)
                            MainUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }



    }

}