using Microsoft.Xna.Framework;
using System;

namespace SiegeStorm.GameObjects.InventoryAndShop
{
    class ButtonBuy : GameButton
    {
        public ButtonBuy()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture("playButton"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 5 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }
        public override void Pressed()
        {
            
        }
    }
}
