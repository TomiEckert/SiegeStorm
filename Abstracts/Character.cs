namespace SiegeStorm.Abstracts
{
    public abstract class Character : GameObject
    {
        private string name;
        private int level;
        private int basePower;
        private int baseHealth;

        public Character(string name)
        {
            this.name = name;
            this.level = 1;
            this.basePower = 10 * this.level;
            this.baseHealth = 25 * this.level + 50;
        }

        //Getters

        public string getName()
        {
            return this.name;
        }

        public int getLevel()
        {
            return this.level;
        }

        public int GetBasePower()
        {
            return this.basePower;
        }

        public int GetBaseHealth()
        {
            return this.baseHealth;
        }

        //Leveling Up
        public void LevelUp()
        {
            this.level++;
            this.basePower = 10 * this.level;
            this.baseHealth = 25 * this.level + 50;
        }
    }
}