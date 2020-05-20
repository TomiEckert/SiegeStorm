using Microsoft.Xna.Framework;
using System;

namespace SiegeStorm.GameObjects.MainMenu
{
    class ButtonStart : GameButton
    {
        public ButtonStart()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture("playButton")); //Replace Texture
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 5 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            throw new NotImplementedException();
        }
    }
}
