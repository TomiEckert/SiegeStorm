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
            int posX = SiegeStorm.ScreenWidth / 4;
            int posY = SiegeStorm.ScreenHeight / 4;
            foreach (var level in levels)
            {
                AddObject(new MapNode(level, posX, posY));
                posX += SiegeStorm.ScreenWidth / 4;
                if (posX > 3 * SiegeStorm.ScreenWidth / 4)
                {
                    posX = SiegeStorm.ScreenWidth / 4;
                    posY += SiegeStorm.ScreenHeight / 4;
                }
            }

            buttonReturn = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(buttonReturn);
        }
    }
}