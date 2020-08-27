using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.SettingsMenu
{
    internal class FpsCounterText : GameButton
    {
        public FpsCounterText()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "FpsCounterText"));
            var x = 550;
            var y = SiegeStorm.ScreenHeight / 10 * 7 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            //NOTHING
        }
    }
}