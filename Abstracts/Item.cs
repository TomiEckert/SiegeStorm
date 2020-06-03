﻿using SiegeStorm.GameObjects.Characters.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Abstracts
{
    public abstract class Item : GameObject
    {
        string name;
        string description;
        int statValue;
        int price;
        bool isArmor;

        public Item(string name, string description, int statValue, int price, bool isArmor) {
            this.name = name;
            this.description = description;
            this.statValue = statValue;
            this.price = price;
            this.isArmor = isArmor;
        }

        //Getters
        public string GetName()
        {
            return this.name;
        }
        public string GetDescription()
        {
            return this.description;
        }
        public int GetPower()
        {
            return this.statValue;
        }
        public int GetPrice()
        {
            return price;
        }
        public int GetStatValue()
        {
            return this.statValue;
        }
        public bool GetIsArmor()
        {
            return this.isArmor;
        }

        //Equipping this to player
        public void Equip(Player ch)
        {
            ch.EquipItem(this);
        }
        //Unequipping this from player
        public void Unequip(Player ch)
        {
            ch.UnequipItem(this);
        }

    }
}
