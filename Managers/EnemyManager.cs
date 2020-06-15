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
            var e = new Enemy();
            enemies.Add("one", e);
        }

        public Enemy[] GetPlayers()
        {
            return enemies.Values.ToArray();
        }

        public Enemy GetPlayer(string name)
        {
            if (enemies.ContainsKey(name))
                return enemies[name];
            return null;
        }
    }
}
