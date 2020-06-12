using SiegeStorm.Abstracts;
using SiegeStorm.GameObjects.Characters.Players;
using System.Collections.Generic;
using System.Linq;

namespace SiegeStorm.Screens
{
    internal class InventoryAndShop : GameScreen
    {
        private GameObjects.SettingsMenu.ButtonReturn returnButton;
        private GameObjects.InventoryAndShop.ButtonBuy buttonBuy;
        private GameObjects.InventoryAndShop.ButtonSell buttonSell;
        private Inventory inventory;
        private List<Item> ShopList = new List<Item>();

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
            inventory = SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().GetInventory();
        }

        public override void ScreenClose()
        {
            //TODO : Multiplayer
            SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().SetInventory(inventory);
        }

        private void InitializeShop()
        {
            // TODO generate shop from items!
            //ShopList.Add();
        }
    }
}