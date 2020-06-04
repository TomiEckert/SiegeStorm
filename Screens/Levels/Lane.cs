using Microsoft.Xna.Framework;
using SiegeStorm.GameObjects.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameScreens.Levels
{
    public class Lane : GameObject
    {
        private int position;
        private List<Enemy> enemies;

        public void SetEnemies(List<Enemy> enemies)
        {
            this.enemies = enemies;
        }

        public void SetPosition(int position)
        {
            this.position = position;
        }

        public int GetPosition()
        {
            return position;
        }

        public override void Update(GameTime gameTime)
        {

        }

    }
}
