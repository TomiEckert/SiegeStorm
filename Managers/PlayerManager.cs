using SiegeStorm.GameObjects.Characters.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class PlayerManager 
    {

        Dictionary<string, Player> players = new Dictionary<string, Player>();
        public void LoadContent()
        {
            var p = new Player("one");
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
