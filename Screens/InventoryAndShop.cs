using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SiegeStorm.Abstracts;
using SiegeStorm.GameObjects.Characters.Players;

namespace SiegeStorm.Screens
{
    class InventoryAndShop : GameScreen
    {
        GameObjects.SettingsMenu.ButtonReturn returnButton;
        GameObjects.InventoryAndShop.ButtonBuy buttonBuy;
        GameObjects.InventoryAndShop.ButtonSell buttonSell;
        private Inventory inventory;

        internal override void LoadContent()
        {
            buttonSell = new GameObjects.InventoryAndShop.ButtonSell();
            AddObject(buttonSell);
            buttonBuy = new GameObjects.InventoryAndShop.ButtonBuy();
            AddObject(buttonBuy);
        }

        
        public override void ScreenOpen()
        {
            // TODO: Multiplayer
            inventory = SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().getInventory();
        }

        public override void ScreenClose()
        {
            //TODO : Multiplayer
            SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().setInventory(inventory);
        }
    }
}
