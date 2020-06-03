using Microsoft.Xna.Framework;
using System;

namespace SiegeStorm.GameObjects.SettingsMenu
{
    class ButtonReturn : GameButton
    {
        public ButtonReturn()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture("returnButton"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 9 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            SiegeStorm.ScreenManager.ChangeScreenTo("MainMenu");
        }
    }
}
