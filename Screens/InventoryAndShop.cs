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
        GameObjects.SettingsMenu.ButtonFullscreen fullscreenButton;
        GameObjects.SettingsMenu.ButtonFPS fpsButton;

        List<Item> inventoryItems = new List<Item>();
        int maxCapacity = 20;
    
        internal override void LoadContent()
        {
            returnButton = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(returnButton);
            fullscreenButton = new GameObjects.SettingsMenu.ButtonFullscreen();
            AddObject(fullscreenButton);
            fpsButton = new GameObjects.SettingsMenu.ButtonFPS();
            AddObject(fpsButton);
        }

        public void AddItemToInventory(Item item)
        {
            if (inventoryItems.Count <= maxCapacity)
            {
                inventoryItems.Add(item);
            }
            else
            {
                //TODO make this not print in the console but in the game
                Console.WriteLine("Inventory is full.");
            }
        }

        public void RemoveItemFromInventory(Item item)
        {
            inventoryItems.Remove(item);
        }

    }
}
