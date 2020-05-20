using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm
{
    abstract class MapNode : GameButton
    {
        protected GameLevel level;
        protected bool isLocked;

        public MapNode(string name)
        {
            level = SiegeStorm.LevelManager.GetLevel(name);
            isLocked = SiegeStorm.LevelManager.GetLocked(name);
        }
        
        public override void Pressed()
        {
            if (!isLocked)
            {
                level.Run();
            }
        }
    }
}
