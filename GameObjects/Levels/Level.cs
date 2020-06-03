using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Levels
{
    class Level : GameLevel
    {
        int levelHeight;
        int levelTop;
        Lane[] lanes;
        
        public Level(bool isCompleted, bool isLocked): base(isCompleted, isLocked)
        {

        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        internal override void LoadContent()
        {
            levelHeight = SiegeStorm.ScreenHeight / 6 * 5;
            levelTop = SiegeStorm.ScreenHeight / 6;
            lanes = new Lane[5];
            for (int i = 0; i < 5; i++)
            {
                lanes[i] = new Lane(levelTop * (2 + i) - levelTop / 2);
            }
        }

        public override void Update(GameTime gameTime)
        {
            var player = SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault();
            player.setPositionY(lanes[player.getLane()].getPosition());

        }

        public override void ScreenOpen()
        {
            AddObject(SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault());
            SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().setLane(0);
        }

        public override void ScreenClose()
        {
            RemoveObject(SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault());
        }

        public string ToLine()
        {
            return "" + this.IsCompleted + ":" + this.IsLocked;
        }
    }
}
