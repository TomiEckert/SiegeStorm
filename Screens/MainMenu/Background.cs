using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.MainMenu
{
    internal class Background : GameObject
    {
        public Background()
        {
<<<<<<< Updated upstream:Screens/MainMenu/Background.cs
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "bg"));
=======
            SetTexture(SiegeStorm.TextureManager.GetTexture("bg"));
>>>>>>> Stashed changes:GameObjects/MainMenu/Background.cs
            SetPosition(new Vector2(0, 0));
        }

        public override void Draw(GameTime gameTime)
        {
            SiegeStorm.SpriteBatch.Draw(Texture, new Rectangle(0, 0, SiegeStorm.ScreenWidth, SiegeStorm.ScreenHeight), Color.White);
        }
    }
}