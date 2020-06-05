using Microsoft.Xna.Framework;
using SiegeStorm.GameObjects.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Levels
{
    public class Lane : GameObject
    {
        private List<Enemy> enemies;

        public void SetEnemies(List<Enemy> enemies)
        {
            this.enemies = enemies;
        }

        public void SetPosition(int position)
        {
            SetPosition(new Vector2(0, position));
        }

        public int GetPosition()
        {
            return (int) Position.Y;
        }

        public override void Update(GameTime gameTime)
        {

        }

    }
}
