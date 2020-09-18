using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.SettingsMenu
{
    internal class FullScreenText : GameButton
    {
        public FullScreenText()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "FullscreenText"));
            var x = 550;
            var y = SiegeStorm.ScreenHeight / 10 * 5 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            //NOTHING
        }
    }
}