using Microsoft.Xna.Framework;
using SiegeStorm.GameScreens.Levels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiegeStorm.Managers
{
    /// <summary>
    /// Handles the game screens, including: switching screens, and updating and drawing current screen.
    /// </summary>
    public class ScreenManager
    {
        private GameScreen currentScreen;
        private Dictionary<string, GameScreen> gameScreens;

        public ScreenManager()
        {
            gameScreens = new Dictionary<string, GameScreen>();
        }

        /// <summary>
        /// Updates the current screen.
        /// </summary>
        /// <param name="gameTime">Snapshot of game time</param>
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        /// <summary>
        /// Draws the current screen's textures.
        /// </summary>
        /// <param name="gameTime">Snapshot of game time</param>
        public void Draw(GameTime gameTime)
        {
            currentScreen.Draw(gameTime);
        }

        public void LoadContent()
        {
            gameScreens.Add("MainMenu", new Screens.MainMenu());
            gameScreens.Add("SettingsMenu", new Screens.SettingsMenu());
            gameScreens.Add("Map", new Screens.Map());
            gameScreens.Add("Death", new Screens.Death());
            gameScreens.Add("InventoryAndShop", new Screens.InventoryAndShop());
            gameScreens.Add("HowToPlay", new Screens.HowToPlay());
            // TODO manually add gameScreens and set current to MainMenu

            foreach (var gameScreen in gameScreens)
            {
                gameScreen.Value.LoadContent();
            }
            ChangeScreenTo("MainMenu");
        }

        public string[] GetScreenNames()
        {
            return gameScreens.Keys.ToArray();
        }

        public void ChangeScreenTo(string screen)
        {
            if (gameScreens.ContainsKey(screen))
            {
                if (currentScreen != null)
                    currentScreen.OnSC();
                currentScreen = gameScreens[screen];
                currentScreen.OnSO();
            }
            GC.Collect();
        }

        public void ChangeScreenTo(Level level)
        {
            if (!gameScreens.ContainsValue(level))
            {
                if (currentScreen != null)
                    currentScreen.OnSC();
                gameScreens.Add(SiegeStorm.LevelManager.GetLevelName(level), level);
            }
            currentScreen = level;
            currentScreen.OnSO();
            GC.Collect();
        }

        /// <summary>
        /// DO NOT USE FOR GAME
        /// ONLY FOR DEBUGGING
        /// </summary>
        /// <returns></returns>
        public string GetCurrentScreenName()
        {
            if (currentScreen != null)
                return gameScreens.FirstOrDefault(x => x.Value == currentScreen).Key;
            return null;
        }

        public GameScreen GetCurrentScreen()
        {
            return currentScreen;
        }
    }
}