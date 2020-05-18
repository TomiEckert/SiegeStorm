﻿using System;
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
        GameObjects.MainMenu.ButtonStart start;
        GameObjects.MainMenu.ButtonSettings settings;
        GameObjects.MainMenu.ButtonExit exit;

        internal override void LoadContent()
        {
            start = new GameObjects.MainMenu.ButtonStart();
            AddObject(start);
            settings = new GameObjects.MainMenu.ButtonSettings();
            AddObject(settings);
            exit = new GameObjects.MainMenu.ButtonExit();
            AddObject(exit);
        }
    }
}