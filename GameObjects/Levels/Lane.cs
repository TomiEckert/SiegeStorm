using Microsoft.Xna.Framework;
using SiegeStorm.GameObjects.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Levels
{
    class Lane : GameObject
    {
        int position;
        int maxAmountEnemies;
        List<Enemy> enemies;

        public Lane(int position)
        {
            this.position = position;
            enemies = new List<Enemy>();
        }

        public int getPosition()
        {
            return position;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
