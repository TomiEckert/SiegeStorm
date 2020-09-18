using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.SettingsMenu
{
    internal class Background : GameObject
    {
        public Background()
        { 
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "bg"));
            SetPosition(new Vector2(0, 0));
        }

        public override void Draw(GameTime gameTime)
        {
            SiegeStorm.SpriteBatch.Draw(Texture, new Rectangle(0, 0, SiegeStorm.ScreenWidth, SiegeStorm.ScreenHeight), Color.White);
        }
    }
}