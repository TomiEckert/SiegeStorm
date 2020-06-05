using SiegeStorm.GameScreens.Levels;
using SiegeStorm.GameObjects.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiegeStorm.Managers;

namespace SiegeStorm.Screens
{
    class Map : GameScreen
    {
        List<Level> levels; 
        GameObjects.SettingsMenu.ButtonReturn buttonReturn;

        public Map()
        {
            this.levels = SiegeStorm.LevelManager.GetLevels();
        }

        internal override void LoadContent()
        {   
            int posX = 1;
            int posY = 1;
            foreach (var level in levels)
            {
                AddObject(new MapNode(level, posX, posY));
                posX += 3;
                if(posX >= 9)
                {
                    posX = 1;
                    posY++;
                }
            }
            
            buttonReturn = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(buttonReturn);
        }
    }
}
