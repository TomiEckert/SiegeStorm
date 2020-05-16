using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SiegeStorm.Screens
{
    class MainMenu : GameScreen
    {
        GameObjects.MainMenu.ButtonExit exit;

        public override void Update(GameTime gameTime)
        {

        }

        internal override void LoadContent()
        {
            exit = new GameObjects.MainMenu.ButtonExit();
            AddObject(exit);
        }
    }
}
