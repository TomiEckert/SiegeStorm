using SiegeStorm.Abstracts;
using SiegeStorm.GameObjects.Characters.Players;
using System.Collections.Generic;
using System.Linq;

namespace SiegeStorm.Screens
{
    internal class InventoryAndShop : GameScreen
    {
        private GameObjects.InventoryAndShop.ButtonReturnINV returnButtonINV;
        private GameObjects.InventoryAndShop.ButtonEquip buttonEquip;
        private GameObjects.InventoryAndShop.ButtonBuy buttonBuy;
        private GameObjects.InventoryAndShop.ButtonSell buttonSell;
        private List<GameObjects.InventoryAndShop.ItemButton> itemButtons = new List<GameObjects.InventoryAndShop.ItemButton>();
        private Inventory inventory;
        private Shop shop; 

        internal override void LoadContent()
        {
            buttonSell = new GameObjects.InventoryAndShop.ButtonSell();
            AddObject(buttonSell);
            buttonBuy = new GameObjects.InventoryAndShop.ButtonBuy();
            AddObject(buttonBuy);
            buttonEquip = new GameObjects.InventoryAndShop.ButtonEquip();
            AddObject(buttonEquip);
            returnButtonINV = new GameObjects.InventoryAndShop.ButtonReturnINV();
            AddObject(returnButtonINV);

        }

        public override void ScreenOpen()
        {
            // TODO: Multiplayer
            inventory = SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().GetInventory();
            shop = SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().GetShop();
        }

        public override void ScreenClose()
        {
            //TODO : Multiplayer
            SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().SetInventory(inventory);
            SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().SetShop(shop);

        }

        public void Initialize()
        {
            shop.GetShopItems();
            foreach (var item in shop.GetShopItems())
            {
                string name = item.GetName();
                string desc = item.GetDescription();
                int price = item.GetPrice();
                int stat = item.GetStatValue();

                GameObjects.InventoryAndShop.ItemButton itemItemButton = new GameObjects.InventoryAndShop.ItemButton(name, desc, price, stat);
                itemButtons.Add(itemItemButton);
            }
        }
    }
}