using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SiegeStorm.Managers
{
    /// <summary>
    /// Handles the game screens, including: switching screens, and updating and drawing current screen.
    /// </summary>
    public class ScreenManager
    {
        GameScreen currentScreen;
        Dictionary<string, GameScreen> gameScreens;

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
            gameScreens.Add("Inventory", new Screens.Inventory());
            gameScreens.Add("Shop", new Screens.Shop());
            // TODO manually add gameScreens and set current to MainMenu

            foreach (var gameScreen in gameScreens) {
                gameScreen.Value.LoadContent();
            }
            ChangeScreenTo("MainMenu");
        }

        public void ChangeScreenTo(string screen)
        {
            if(gameScreens.ContainsKey(screen)) {
                if (currentScreen != null)
                    currentScreen.ScreenClose();
                currentScreen = gameScreens[screen];
                currentScreen.ScreenOpen();
            }
        }
    }
}
