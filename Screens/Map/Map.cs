using SiegeStorm.GameObjects.Map;
using SiegeStorm.GameScreens.Levels;
using System.Collections.Generic;

namespace SiegeStorm.Screens
{
    internal class Map : GameScreen
    {
        private List<Level> levels;
        private GameObjects.SettingsMenu.ButtonReturn buttonReturn;
        private GameObjects.Map.ButtonInvAndShop buttonInvAndShop;
        private GameObjects.Map.Background bg;


        public Map()
        {
            this.levels = SiegeStorm.LevelManager.GetLevels();
        }

        internal override void LoadContent()
        {
            bg = new GameObjects.Map.Background();
            AddObject(bg);
            buttonReturn = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(buttonReturn);
            buttonInvAndShop = new GameObjects.Map.ButtonInvAndShop();
            AddObject(buttonInvAndShop);

            int posX = SiegeStorm.ScreenWidth / 3;
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
        }
    }
}