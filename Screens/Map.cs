using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Screens
{
    class Map : GameScreen
    {
        GameObjects.Map.Level1Node level1;

        internal override void LoadContent()
        {
            level1 = new GameObjects.Map.Level1Node();
            AddObject(level1);
        }
    }
}
