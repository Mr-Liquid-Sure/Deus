using Terraria.ModLoader;
using Terraria;
using log4net.Appender;
using Terraria.ID;

using Deus.TestingMayContainOtherPeopleCode;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.UI;

namespace Deus.Core.UI.CrossUi
{
    internal class CrossUI1 : UIState
    {
        private UIElement area;
        private UIImage frame;
        private Color Gradient1;
        private Color Gradient2;

        public static int widthOffset = -10;
        public static int heightOffset = -8;
        public static int XOffset = 10;
        public static int YOffset = 4;

        public override void OnInitialize()
        {

            area = new UIElement();
            area.Width.Set(102, 0f);
            area.Height.Set(20, 0f);
            area.HAlign = 0.5f;
            SetRectangle(area, left: 250f, top: 100f, width: 22f, height: 22f);

            frame = new UIImage(ModContent.Request<Texture2D>("Deus/Core/UI/CrossUi/CrossUiCross"));
            frame.Width.Set(102, 0f);
            frame.Height.Set(20, 0f);
            frame.HAlign = frame.VAlign = 0.5f;
            frame.SetPadding(0f);

            Gradient1 = new Color(132, 0, 0);
            Gradient2 = new Color(15, 15, 15);

            area.Append(frame);
            Append(area);
        }

        private void SetRectangle(UIElement uiElement, float left, float top, float width, float height)
        {
            uiElement.Left.Set(left, 0f);
            uiElement.Top.Set(top, 0f);
            uiElement.Width.Set(width, 0f);
            uiElement.Height.Set(height, 0f);
        }
    }
    [Autoload(Side = ModSide.Client)]
    internal class CrossUISystem : ModSystem
    {
        public UserInterface InterUI;
        internal CrossUI1 CrossBarUI;
        public override void Load()
        {
            InterUI = new UserInterface();
            CrossBarUI = new CrossUI1();
            InterUI.SetState(CrossBarUI);
        }
        public void HideMyUI()
        {
            InterUI?.SetState(null);
        }
        public void ShowMyUI()
        {
            InterUI?.SetState(CrossBarUI);
        }
        public override void UpdateUI(GameTime gameTime)
        {
            InterUI?.Update(gameTime);

        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "Deus: CrossUi",
                    delegate
                    {
                        InterUI.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }
    }
}
