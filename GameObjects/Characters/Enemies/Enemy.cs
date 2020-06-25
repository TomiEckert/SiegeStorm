using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiegeStorm.Abstracts;
using SiegeStorm.GameObjects.HUD;


namespace SiegeStorm.GameObjects.Characters.Enemies
{
    public class Enemy : Character
    {
        private int currentLane;
        private Vector2 position;
        private Animation walkLeft;
        private Animation walkRight;
        private Animation die;
        private Healthbar healthbar;
        private int health;

        public Enemy() : base("Enemy Lvl 1")
        {          
            //TODO set position
            var x = SiegeStorm.ScreenWidth - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height ;

            position = new Vector2(x, y);
            walkLeft = SiegeStorm.AnimationManager.GetAnimation("enemyDefaultLeft");
            walkRight = SiegeStorm.AnimationManager.GetAnimation("enemyDefaultRight");

            die = SiegeStorm.AnimationManager.GetAnimation("enemyDie");
            // SetPosition(new Vector2(x, y));
            healthbar = new Healthbar();
        }

        public void SetVerticalPosition(int position)
        {
            SetPosition(new Vector2(Position.X, position));
        }
        public void SetHorizontalPosition(int position)
        {
            SetPosition(new Vector2(position, Position.Y));
        }
        public float getPositionX()
        {
            return Position.X;
        }
        public float getPositionY()
        {
            return Position.Y;
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

        private void SetHealth()
        {
            this.health = this.GetBaseHealth();
        }

        private int getHealth()
        {
            return this.health;
        }

        private bool turn;
        public bool dead = false;
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

            for (int i = 0; i < SiegeStorm.PlayerManager.GetPlayers().Length; i++)
            {
                if (SiegeStorm.PlayerManager.GetPlayers()[i].GetLane() == GetLane() &&
                    SiegeStorm.PlayerManager.GetPlayers()[i].getPositionX() > (Position.X - Texture.Width) && SiegeStorm.PlayerManager.GetPlayers()[i].attacked)
                {
                    dead = true;
                }
            }
            healthbar.SetHealth(health, this.GetBaseHealth(), Position);
        }
        public override void Draw(GameTime gameTime)
        {
            if (dead)
            {
                die.Draw(gameTime, Position);
            }
            else
            {
             if (Position.X == 0)
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
            healthbar.Draw(gameTime);
        }
        //TODO movement
        //TODO attack
    }
}