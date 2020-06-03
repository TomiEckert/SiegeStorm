using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Levels
{
    class Lane
    {
        int position;
        public Lane(int position)
        {
            this.position = position;
        }

        public int getPosition()
        {
            return position;
        }
    }
}
