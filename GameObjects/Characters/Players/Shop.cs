using SiegeStorm.Abstracts;
using System;
using System.Collections.Generic;

namespace SiegeStorm.GameObjects.Characters.Players
{
    public class Shop
    {
        private List<Item> shopItems = new List<Item>();

        public void AddItemToShop(Item item)
        {
            shopItems.Add(item);
        }
    }
}