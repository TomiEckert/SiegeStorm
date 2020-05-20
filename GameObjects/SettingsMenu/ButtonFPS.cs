using Microsoft.Xna.Framework;
using System;

namespace SiegeStorm.GameObjects.SettingsMenu
{
    class ButtonFPS : GameButton
    {
        public ButtonFPS()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture("fullscreenButton"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 7 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            if(SiegeStorm.FpsIsOn == false)

            {
                SiegeStorm.FpsIsOn = true;
            }
            else
            {
                SiegeStorm.FpsIsOn = false;
            }
        }
    }
}
