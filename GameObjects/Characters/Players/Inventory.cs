using SiegeStorm.Abstracts;
using System;
using System.Collections.Generic;

namespace SiegeStorm.GameObjects.Characters.Players
{
    public class Inventory
    {
        private List<Item> inventoryItems = new List<Item>();
        private int maxCapacity = 20;

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