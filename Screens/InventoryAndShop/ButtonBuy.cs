using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.InventoryAndShop
{
    internal class ButtonBuy : GameButton
    {
        public ButtonBuy()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "ButtonBuy"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
        }
    }
}