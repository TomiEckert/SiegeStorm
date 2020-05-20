using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm
{
    public abstract class GameLevel
    {
        public bool IsCompleted;
        public GameLevel()
        {
            this.IsCompleted = false;
        }
        public GameLevel(bool isCompleted)
        {
            this.IsCompleted = isCompleted;
        }

        public void Complete()
        {
            this.IsCompleted = true;
            SiegeStorm.LevelManager.UnlockNext(this);
        }

        public abstract void Run();
    }
}
