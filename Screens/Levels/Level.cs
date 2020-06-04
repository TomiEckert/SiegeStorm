using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameScreens.Levels
{
    public class Level : GameScreen
    {
        int levelTop;
        Lane[] lanes;
        int enemiesPerWave;
        const int INITIAL_DELAY = 5000;
        int delay = 0;
        
        public Level(Lane[] lanes, int enemiesPerWave)
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
            levelTop = SiegeStorm.ScreenHeight / 6;
            for (int i = 0; i < 5; i++)
            {
                lanes[i].SetPosition(levelTop * (2 + i) - levelTop / 2);
            }
        }

        public override void Update(GameTime gameTime)
        {
            var player = SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault();
            player.SetVerticalPosition(lanes[player.GetLane()].GetPosition());
            if(delay < INITIAL_DELAY)
            {
                delay += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                return;
            }
            base.Update(gameTime);
        }

        public override void ScreenOpen()
        {
            AddObject(SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault());
            SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().SetLane(0);
        }

        public override void ScreenClose()
        {
            RemoveObject(SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault());
        }
    }
}
