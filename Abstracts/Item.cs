using SiegeStorm.GameObjects.Characters.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Abstracts
{
    abstract class Item : GameObject
    {
        string name;
        string description;
        int statValue;
        int weight;
        bool isArmor;

        public Item(string name, string description, int statValue, int weight) {
            this.name = name;
            this.description = description;
            this.statValue = statValue;
            this.weight = weight;
        }

        public void Equip(Player ch)
        {
            if (isArmor)
            {
                // TODO increase health by statValue
            }
            else
            {
                // TODO increase attack by statValue
            }
        }

        public void Unequip(Player ch)
        {
            if (isArmor)
            {
                // TODO decrease health by statValue
            }
            else
            {
                // TODO decrease attack by statValue
            }
        }

        public string getName(){
            return this.name;
        }
        public int getPower(){
            return this.statValue;
        }
        public int getWeight()
        {
            return weight;
        }
    }
}
