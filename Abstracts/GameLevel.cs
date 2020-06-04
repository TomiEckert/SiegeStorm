using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm
{
    public abstract class GameLevel: GameScreen
    {
        internal bool IsCompleted;
        internal bool IsLocked;
        
        public GameLevel(bool isCompleted, bool isLocked)
        {
            this.IsCompleted = isCompleted;
            this.IsLocked = isLocked;
        }

        public void Complete()
        {
            this.IsCompleted = true;
        }

        void Unlock()
        {
            this.IsLocked = false;
        }


        public abstract void Run();
    }
}
