using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.HUD
{
    class Healthbar
    {
        public int maxHealth;
        public int currentHealth;

        public Healthbar()
        {

        }

        public void Update(int currentHealth)
        {
            this.currentHealth = currentHealth;
        }

        public void Draw()
        {
            float healthPercentage = currentHealth / maxHealth;

        }
    }
}
