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

        List<Player> ListOfPlayers = new List<Player>();
        public void LoadContent()
        {

        }

        public Player[] GetPlayers()
        {
            return ListOfPlayers.ToArray();
        }
    }
}
