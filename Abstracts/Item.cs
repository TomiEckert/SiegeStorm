using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Abstracts
{
    abstract class Item: GameObject
    {
        string name;
        string description { get; set; }
        int power;
        int weight;

        public Item(string name, string description, int power, int weight) {
            this.name = name;
            this.description = description;
            this.power = power;
            this.weight = weight;
        }

        public string getName(){
            return this.name;
        }
        public int getPower(){
            return this.power;
        }
        public int getWeight()
        {
            return weight;
        }
    }
}
