using Microsoft.Xna.Framework;
using SiegeStorm.Abstracts;

namespace SiegeStorm.GameObjects.Characters.Enemies
{
    public class Enemy : Character
    {
        private int currentLane;
        public Enemy() : base("Enemy Lvl 1")
        {
            //TODO set texture
            SetTexture(SiegeStorm.TextureManager.GetTexture(this));
            //TODO set position
            var x = SiegeStorm.ScreenWidth - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            Vector2 position = new Vector2(x, y);
            // SetPosition(new Vector2(x, y));
        }
   
        public void SetVerticalPosition(int position)
        {
            SetPosition(new Vector2(Position.X, position));
        }

        public void SetLane(int lane)
        {
            currentLane = lane;
        }

        public int GetLane()
        {
            return currentLane;
        }
        public override void Update(GameTime gameTime)
        {
            if (Position.X < (SiegeStorm.ScreenWidth - Texture.Width))
            {
                SetPosition(new Vector2(Position.X + 5, Position.Y));
            }

        }
        //TODO movement
        //TODO attack
    }
}