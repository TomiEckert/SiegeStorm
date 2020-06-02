using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SiegeStorm.Screens
{
    class InventoryAndShop : GameScreen
    {
        GameObjects.SettingsMenu.ButtonReturn returnButton;
        GameObjects.InventoryAndShop.ButtonBuy buyButton;
        GameObjects.InventoryAndShop.ButtonSell sellButton;
    
        internal override void LoadContent()
        {
            returnButton = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(returnButton);
        }
    }
}
