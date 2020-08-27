using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.MainMenu
{
    internal class Controls : GameButton
    {
        public Controls()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "controls"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 6 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
           //
        }
    }
}