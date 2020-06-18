using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiegeStorm.Abstracts;

namespace SiegeStorm.GameObjects.Characters.Enemies
{
    public class Enemy : Character
    {
        private int currentLane;
        private Vector2 position;
        private Animation walkLeft;
        private Animation walkRight;

        public Enemy() : base("Enemy Lvl 1")
        {          
            //TODO set position
            var x = SiegeStorm.ScreenWidth - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height ;

            position = new Vector2(x, y);
            walkLeft = SiegeStorm.AnimationManager.GetAnimation("enemyDefaultLeft");
            walkRight = SiegeStorm.AnimationManager.GetAnimation("enemyDefaultRight");
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

        public void SetPositionXY(int positionX, int positionY)
        {
            SetPosition(new Vector2(positionX, positionY));
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

            if (Position.X == (SiegeStorm.ScreenWidth - 180))
            {
                turn = true;
            }
            else if (Position.X == 0)
            {
                turn = false;
            }
            if (turn)
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
            if (Position.X == (SiegeStorm.ScreenWidth - 180))
            {
                turn = true;
            }
            else if (Position.X == 0)
            {
                turn = false;
            }
            if(turn)
            {
                walkLeft.Draw(gameTime, Position);
            }
            else
            {
                walkRight.Draw(gameTime, Position);
            }
            
        }
        //TODO movement
        //TODO attack
    }
}