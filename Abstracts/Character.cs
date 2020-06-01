using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Abstracts
{
    abstract class Character: GameObject
    {
        string name;
        int level;
        int basePower;
        List<Item> equiptment;

        public Character(string name, int basePower)
        {
            this.name = name;
            this.level = 1;
            this.basePower = 1;
            this.equiptment = new List<Item>();
        }
    }
}
