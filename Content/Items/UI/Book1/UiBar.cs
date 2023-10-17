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

namespace Deus.Content.Items.UI.Book1
{
    class UiBar : UIState
    {

        public DragableUIPanel CoinCounterPanel;
       

    
        public override void OnInitialize()
        {
           // CoinCounterPanel = new DragableUIPanel();
           // CoinCounterPanel.SetPadding(0);
           // SetRectangle(CoinCounterPanel, left: 400f, top: 100f, width: 300f, height: 300f);
           // CoinCounterPanel.BackgroundColor = new Color(73, 94, 171);
            
           // Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
           // UIHoverImageButton closeButton = new UIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52"));
           // SetRectangle(closeButton, left: 270f, top: 10f, width: 22f, height: 22f);
           // closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
           // CoinCounterPanel.Append(closeButton);
           // Append(CoinCounterPanel);
            UIPanel panel = new UIPanel();
            panel.Width.Set(300, 0);
            panel.Height.Set(300, 0);
            panel.HAlign = panel.VAlign = 0.5f; // 1


            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            UIHoverImageButton closeButton = new UIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52"));
            //closeButton.Width.Set(22, 0);
            //closeButton.Height.Set(22, 0);
            //closeButton.HAlign = 1f;//changes the location of the ui
            //closeButton.Top.Set(25, 0);       
            SetRectangle(closeButton, left: 260f, top: 5f, width: 22f, height: 22f);
            closeButton.OnLeftClick += CloseButtonClicked;  // 3
            panel.Append(closeButton);



            UIText header = new UIText("My UI Header");
            header.HAlign = 0.5f;  // 1
            header.Top.Set(15, 0); // 2
            panel.Append(header);
            Append(panel);
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
            ModContent.GetInstance<UiSystem>().HideMyUI();
        }

    
    }

   
       
}
