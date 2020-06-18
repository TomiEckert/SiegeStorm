using SiegeStorm.GameObjects.Items;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SiegeStorm.Managers
{
    public class ItemManager
    {
        private Dictionary<string, Armor> Armor = new Dictionary<string, Armor>();
        private Dictionary<string, Weapon> Weapons = new Dictionary<string, Weapon>();

        public void LoadContent()
        {
            GenerateArmor();
            GenerateWeapon();
        }

        private void GenerateArmor()
        {
            var items = ReadItems("Armor.txt");
            Armor = new Dictionary<string, Armor>();
            foreach (var item in items)
            {
                var armor = new Armor(item);
                var name = item[0];
                Armor.Add(name, armor);
            }
        }

        private void GenerateWeapon()
        {
            var items = ReadItems("Weapons.txt");
            Weapons = new Dictionary<string, Weapon>();
            foreach (var item in items)
            {
                var weapon = new Weapon(item);
                var name = item[0];
                Weapons.Add(name, weapon);
            }
        }

        public void AddToShop()
        {
            foreach (var armor in Armor)
            {
                SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().AddItemToShop(armor.Value);
            }

            foreach (var weapon in Weapons)
            {
                SiegeStorm.PlayerManager.GetPlayers().FirstOrDefault().AddItemToShop(weapon.Value);
            }
        }

        private List<string[]> ReadItems(string file)
        {
            var text = File.ReadAllLines("Content/" + file);
            List<string[]> items = new List<string[]>();
            foreach (var i in text)
            {
                if (i[0] == '#')
                    continue;

                var attributes = i.Split(':');
                if (attributes.Count() != 4)
                    continue;

                var name = attributes[0];
                var description = attributes[1];

                var stat = 0;
                if (!int.TryParse(attributes[2], out stat))
                    continue;

                var price = 0;
                if (!int.TryParse(attributes[3], out price))
                    continue;

                items.Add(attributes);
            }
            return items;
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