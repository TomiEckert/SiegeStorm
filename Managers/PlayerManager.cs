using SiegeStorm.GameObjects.Characters.Players;
using System.Collections.Generic;
using System.Linq;

namespace SiegeStorm.Managers
{
    public class PlayerManager
    {
        private Dictionary<string, Player> players = new Dictionary<string, Player>();

        public void LoadContent()
        {
            var p = new Player("one");
            players.Add("one", p);
        }

        public Player[] GetPlayers()
        {
            return players.Values.ToArray();
        }

        public Player GetPlayer(string name)
        {
            if (players.ContainsKey(name))
                return players[name];
            return null;
        }
    }
}