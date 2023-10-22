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
using rail;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Deus.Content.Items.UI.Book1
{
    class UiBar : UIState
    {

        public DragableUIPanel CoinCounterPanel;
        public UIText text = new UIText("Page 1");
        public UIPanel button = new UIPanel();
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

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/SearchCancel");
            UIHoverImageButton closeButton = new UIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52"));       
            SetRectangle(closeButton, left: 0f, top: 0f, width: 22f, height: 22f);
            closeButton.OnLeftClick += CloseButtonClicked;  // 3
            panel.Append(closeButton);

            
            UIImageButton NextPage1 = new UIImageButton(ModContent.Request<Texture2D>("Terraria/Images/UI/Bestiary/Button_Forward"));
            SetRectangle(NextPage1, left: 250f, top: 0f, width: 22f, height: 22f);
            NextPage1.OnLeftClick += NextPage1Clicked;  // 3
            panel.Append(NextPage1);

            UIPanel button = new UIPanel();
            SetRectangle(button, left: 60f, top: 50f, width: 150f, height: 50f);
            button.OnLeftClick += OnButtonClick;  
            panel.Append(button);

            UIText text = new UIText("Page 1");
            text.HAlign = text.VAlign = 0.5f; // 4
            button.Append(text);

            UIText header = new UIText("A Gods Guide");
            header.HAlign = 0.5f;  // 1
            header.Top.Set(15, 0); // 2
            panel.Append(header);
            Append(panel);
        }
        /*public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); // This ensures the Update call is propagated to the children.
            if (text.IsMouseHovering || button.IsMouseHovering)
            {
                Main.hoverItemName = "Click to see what happens";
            }
        }*/
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            
            if (button.IsMouseHovering || button.IsMouseHovering)
            {
                Main.hoverItemName = "Click to see what happens";
                button.BackgroundColor = new Color(73, 94, 171);
            }



        }
        private void SetRectangle(UIElement uiElement, float left, float top, float width, float height)
        {
            uiElement.Left.Set(left, 0f);
            uiElement.Top.Set(top, 0f);
            uiElement.Width.Set(width, 0f);
            uiElement.Height.Set(height, 0f);
        }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
            ModContent.GetInstance<UiSystem>().HideMyUI();
        }
        private void NextPage1Clicked(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
            ModContent.GetInstance<UiSystem>().HideMyUI();
        }
        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
            ModContent.GetInstance<UiSystem>().HideMyUI();
        }

    
    }

   
       
}
