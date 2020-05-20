using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SiegeStorm.Managers;

namespace SiegeStorm.Screens
{
    class MainMenu : GameScreen
    {
        GameObjects.MainMenu.Background bg;
        GameObjects.MainMenu.ButtonStart start;
        GameObjects.MainMenu.ButtonSettings settings;
        GameObjects.MainMenu.ButtonExit exit;

        internal override void LoadContent()
        {
            bg = new GameObjects.MainMenu.Background();
            AddObject(bg);
            start = new GameObjects.MainMenu.ButtonStart();
            AddObject(start);
            settings = new GameObjects.MainMenu.ButtonSettings();
            AddObject(settings);
            exit = new GameObjects.MainMenu.ButtonExit();
            AddObject(exit);
        }

        public override void ScreenOpen()
        {
            SiegeStorm.SoundManager.PlaySong("MainMenu");
        }
    }
}
