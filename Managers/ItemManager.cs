using SiegeStorm.Abstracts;
using SiegeStorm.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class ItemManager
    {
        Dictionary<string, Armor> Armor = new Dictionary<string, Armor>();
        Dictionary<string, Weapon> Weapons = new Dictionary<string, Weapon>();

        public void LoadContent()
        {

        }

        void GenerateArmor() 
        { 
            //TODO
        }

        void GenerateWeapon()
        {
            //TODO
        }

        void GenerateItems()
        {
            //TODO
        }

        public Armor GetArmor(string name)
        {
            if (Armor.ContainsKey(name))
            {
                return Armor[name];
            }
            return null;
        }

        public Weapon GetWeapon(string name)
        {
            if (Weapons.ContainsKey(name))
            {
                return Weapons[name];
            }
            return null;
        }
    }
}
