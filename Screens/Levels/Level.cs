using Microsoft.Xna.Framework;
using System.Linq;

namespace SiegeStorm.GameScreens.Levels
{
    public class Level : GameScreen
    {
        private int levelTop;
        private Lane[] lanes;
        private int enemiesPerWave;
        private const int INITIAL_DELAY = 5000;
        private int delay = 0;

        public Level(Lane[] lanes, int enemiesPerWave)
        {
            Init(lanes, enemiesPerWave);
        }

        internal void Init(Lane[] lanes, int enemiesPerWave)
        {
            this.lanes = lanes;
            foreach (var lane in lanes)
            {
                AddObject(lane);
            }
            this.enemiesPerWave = enemiesPerWave;
        }
        internal override void LoadContent()
        {
            levelTop = SiegeStorm.ScreenHeight / 7;
            for (int i = 0; i < 5; i++)
            {
                lanes[i].SetPosition(levelTop * (2 + i) - levelTop / 2);
            }
        }
        bool count = true;
        public override void Update(GameTime gameTime)
        {
            var player = SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault();
            player.SetVerticalPosition(lanes[player.GetLane()].GetPosition());

            if (player.GetHealth() == 0)
            {
                LoadContent();
                
                player.SetHealth();
                SiegeStorm.ScreenManager.ChangeScreenTo("MainMenu");
            };
            

            for (int i = 0; i < 5; i++)
            {
                if(count == true)
                {
                    var enemy = SiegeStorm.EnemyManager.GetEnemies()[i];
                    enemy.SetPositionXY(SiegeStorm.ScreenWidth - 200, lanes[enemy.GetLane()].GetPosition());
                   
                }
                else
                {
                    var enemy = SiegeStorm.EnemyManager.GetEnemies()[i];
                    enemy.SetVerticalPosition(lanes[enemy.GetLane()].GetPosition());

                }
                
                
            }
            count = false;


            base.Update(gameTime);
        }

        public override void ScreenOpen()
        {
            AddObject(SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault());
            SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().SetLane(0);
            
            for (int i = 0; i < 5; i++)
            {
                AddObject(SiegeStorm.EnemyManager.GetEnemies()[i]);
                SiegeStorm.EnemyManager.GetEnemies()[i].SetLane(i);
            }
          
        }

        public override void ScreenClose()
        {
            RemoveObject(SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault());
        }

        public void Run()
        {
            SiegeStorm.ScreenManager.ChangeScreenTo(this);
        }
    }
}