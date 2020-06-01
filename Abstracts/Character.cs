using SiegeStorm.GameObjects.Items;
using SiegeStorm.GameObjects.Items.Weapon;
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
        Item armor;
        Item weapon;

        public Character(string name)
        {
            this.name = name;
            this.level = 1;
            this.basePower = 1;
            this.armor = new DefaultArmor();
            this.weapon = new DefaultWeapon();
        }

        public void LevelUp()
        {
            this.level++;
            this.basePower += 5;
        }
    }
}
