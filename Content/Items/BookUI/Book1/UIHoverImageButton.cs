using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Humanizer;
using Terraria.GameContent.UI.Elements;
using ReLogic.Content;

namespace Deus.Content.Items.BookUI.Book1
{
    
    internal class UIHoverImageButton : UIImageButton
    {
        internal string hoverText;

        public UIHoverImageButton(Asset<Texture2D> texture, string hoverText) : base(texture)
        {
            this.hoverText = hoverText;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
         
            base.DrawSelf(spriteBatch);

            if (IsMouseHovering)
                Main.hoverItemName = hoverText;
        }
    }
}