﻿using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.MainMenu
{
    internal class ButtonStartReal : GameButton
    {
        public ButtonStartReal()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "playButton"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 9 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            SiegeStorm.ScreenManager.ChangeScreenTo("Map");
        }
    }
}