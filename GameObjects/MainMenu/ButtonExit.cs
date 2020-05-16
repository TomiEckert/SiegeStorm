using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.MainMenu
{
    class ButtonExit : GameObject
    {
        public ButtonExit()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture("exitButton"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 9 - Texture.Height;
            SetPosition(new Vector2(x, y));

        }
    }
}
