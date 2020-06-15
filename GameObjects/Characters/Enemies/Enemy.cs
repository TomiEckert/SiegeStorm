using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiegeStorm.Abstracts;

namespace SiegeStorm.GameObjects.Characters.Enemies
{
    public class Enemy : Character
    {
        private int currentLane;
        private Vector2 position;
        private Animation walk;
   
        public Enemy() : base("Enemy Lvl 1")
        {          
            //TODO set position
            var x = SiegeStorm.ScreenWidth - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height ;

            position = new Vector2(x, y);
            walk = SiegeStorm.AnimationManager.GetAnimation("enemyDefault");
            // SetPosition(new Vector2(x, y));
        }
   
        public void SetVerticalPosition(int position)
        {
            SetPosition(new Vector2(Position.X, position));
        }
        public void SetHorizontalPosition(int position)
        {
            SetPosition(new Vector2(position, Position.Y));
        }

        public void SetLane(int lane)
        {
            currentLane = lane;
        }

        public int GetLane()
        {
            return currentLane;
        }
        private bool turn;
        public override void Update(GameTime gameTime)
        {
       
            if (Position.X > (SiegeStorm.ScreenWidth - Texture.Width))
            {
                turn = true;        
            }
            else if(Position.X <= 0)
            {
                turn = false;
            }
            if(turn)
            {
               SetPosition(new Vector2(Position.X - 5, Position.Y));
            }
            else
            {
                SetPosition(new Vector2(Position.X + 5, Position.Y));
            }


        }
        public override void Draw(GameTime gameTime)
        {
            walk.Draw(gameTime, Position);
        }
        //TODO movement
        //TODO attack
    }
}