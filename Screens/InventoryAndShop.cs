using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SiegeStorm.Abstracts;

namespace SiegeStorm.Screens
{
    class InventoryAndShop : GameScreen
    {
        GameObjects.SettingsMenu.ButtonReturn returnButton;
        GameObjects.InventoryAndShop.ButtonBuy buttonBuy;
        GameObjects.InventoryAndShop.ButtonSell buttonSell;

        internal override void LoadContent()
        {
            returnButton = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(returnButton);
        }
    }
}
