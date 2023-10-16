using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using ReLogic.Content;
using System;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.UI.Elements;

namespace Deus.TestingMayContainOtherPeopleCode.UITest
{
    class TestUiBar : UIState
    {

        public ExampleDragableUIPanel CoinCounterPanel;
        public UIMoneyDisplay MoneyDisplay;

    
        public override void OnInitialize()
        {
            CoinCounterPanel = new ExampleDragableUIPanel();
            CoinCounterPanel.SetPadding(0);
            SetRectangle(CoinCounterPanel, left: 400f, top: 100f, width: 300f, height: 300f);
            CoinCounterPanel.BackgroundColor = new Color(73, 94, 171);
            
            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            ExampleUIHoverImageButton closeButton = new ExampleUIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52"));
            SetRectangle(closeButton, left: 270f, top: 10f, width: 22f, height: 22f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            CoinCounterPanel.Append(closeButton);
            Append(CoinCounterPanel);
            //UIPanel panel = new UIPanel();
            // panel.Width.Set(300, 0);
            // panel.Height.Set(300, 0);
            // panel.HAlign = panel.VAlign = 0.5f; // 1
            // Append(panel);

            // UIText text = new UIText("Hello world!");
            //  text.HAlign = 0.5f; // 1
            //  text.VAlign = 0.5f; // 1
            //  panel.Append(text);
        }

        private void SetRectangle(UIElement uiElement, float left, float top, float width, float height)
        {
            uiElement.Left.Set(left, 0f);
            uiElement.Top.Set(top, 0f);
            uiElement.Width.Set(width, 0f);
            uiElement.Height.Set(height, 0f);
        }

 

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
            ModContent.GetInstance<TestUiSystem>().HideMyUI();
        }

    
    }

    public class UIMoneyDisplay : UIElement
    {

    }
       
}
