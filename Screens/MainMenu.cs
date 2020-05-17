using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SiegeStorm.Screens
{
    class MainMenu : GameScreen
    {
        GameObjects.MainMenu.ButtonExit exit;

        internal override void LoadContent()
        {
            exit = new GameObjects.MainMenu.ButtonExit();
            AddObject(exit);
        }
    }
}
