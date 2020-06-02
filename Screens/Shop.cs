using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SiegeStorm.Screens
{
    class Shop : GameScreen
    {
        GameObjects.SettingsMenu.ButtonReturn returnButton;
    
        internal override void LoadContent()
        {
            returnButton = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(returnButton);
        }
    }
}
