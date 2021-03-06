﻿using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.SettingsMenu
{
    internal class ButtonFPS : GameButton
    {
        public ButtonFPS()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "DisabledButton"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 7 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            if (SiegeStorm.FpsIsOn == false)

            {
                SiegeStorm.FpsIsOn = true;
                SetTexture(SiegeStorm.TextureManager.GetTexture(this, "EnabledButton"));
            }
            else
            {
                SiegeStorm.FpsIsOn = false;
                SetTexture(SiegeStorm.TextureManager.GetTexture(this, "DisabledButton"));
            }
        }
    }
}