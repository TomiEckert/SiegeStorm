using Microsoft.Xna.Framework;
using SiegeStorm.GameObjects.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class LevelManager
    {
        private Dictionary<string, GameLevel> Levels;
        private Dictionary<string, bool> IsLocked;
        private Dictionary<GameLevel, string> Next;

        public void LoadContent()
        {
            Levels = new Dictionary<string, GameLevel>();
            IsLocked = new Dictionary<string, bool>();
            Next = new Dictionary<GameLevel, string>();

            //Adding levels, locked state and next level to corresponding dictionaries
            Levels.Add("level1", new Level());
            IsLocked.Add("level1", false);
        }

        public GameLevel GetLevel(string name)
        {
            if (Levels.ContainsKey(name))
            {
                return Levels[name];
            }
            return null;
        }

        public bool GetLocked(string name)
        {
            if (IsLocked.ContainsKey(name))
            {
                return IsLocked[name];
            }
            return false;
        }

        public void SetLocked(string name, bool isLocked)
        {
            if(IsLocked.ContainsKey(name))
            {
                IsLocked[name] = isLocked;
            }
        }

        public void UnlockNext(GameLevel current)
        {
            SetLocked(Next[current], false);
        }
    }
}
