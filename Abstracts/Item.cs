using SiegeStorm.GameObjects.Characters.Players;

namespace SiegeStorm.Abstracts
{
    public abstract class Item : GameObject
    {
        private string name;
        private string description;
        private int statValue;
        private int price;

        public Item(string name, string description, int statValue, int price)
        {
            this.name = name;
            this.description = description;
            this.statValue = statValue;
            this.price = price;
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