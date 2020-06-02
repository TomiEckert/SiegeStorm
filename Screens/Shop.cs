using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SiegeStorm.Screens
{
    class Inventory : GameScreen
    {
        GameObjects.SettingsMenu.ButtonReturn returnButton;
        GameObjects.SettingsMenu.ButtonFullscreen fullscreenButton;
        GameObjects.SettingsMenu.ButtonFPS fpsButton;
    
        internal override void LoadContent()
        {
            returnButton = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(returnButton);
            fullscreenButton = new GameObjects.SettingsMenu.ButtonFullscreen();
            AddObject(fullscreenButton);
            fpsButton = new GameObjects.SettingsMenu.ButtonFPS();
            AddObject(fpsButton);
        }
    }
}
