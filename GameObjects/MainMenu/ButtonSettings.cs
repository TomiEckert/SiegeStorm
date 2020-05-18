using Microsoft.Xna.Framework;
using System;

namespace SiegeStorm.GameObjects.MainMenu
{
    class ButtonSettings : GameButton
    {
        public ButtonSettings()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture()); //Replace Texture
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 7 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            throw new NotImplementedException();
        }
    }
}
