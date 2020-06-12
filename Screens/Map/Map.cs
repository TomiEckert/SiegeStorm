using SiegeStorm.GameObjects.Map;
using SiegeStorm.GameScreens.Levels;
using System.Collections.Generic;

namespace SiegeStorm.Screens
{
    internal class Map : GameScreen
    {
        private List<Level> levels;
        private GameObjects.SettingsMenu.ButtonReturn buttonReturn;

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
                if (posX >= 9)
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