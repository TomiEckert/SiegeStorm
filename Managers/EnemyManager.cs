using SiegeStorm.GameObjects.Characters.Enemies;
using System.Collections.Generic;
using System.Linq;


namespace SiegeStorm.Managers
{
   public class EnemyManager

    {
        private Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();

        public void LoadContent()
        {
            for (int i = 1; i <= 5; i++)
            {
                var e = new Enemy();
                enemies.Add(i.ToString(), e);
            }
        }

        public Enemy[] GetEnemies()
        {
            return enemies.Values.ToArray();
        }

        public Enemy GetEnemy(string name)
        {
            if (enemies.ContainsKey(name))
                return enemies[name];
            return null;
        }
    }
}
