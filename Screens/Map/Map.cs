using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Screens
{
    class Map : GameScreen
    {
        //TODO create more level nodes, levels, etc. and add them
        GameObjects.Map.Level1Node level1;
        GameObjects.SettingsMenu.ButtonReturn buttonReturn;

        internal override void LoadContent()
        {
            level1 = new GameObjects.Map.Level1Node();
            AddObject(level1);
            buttonReturn = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(buttonReturn);
        }
    }
}
