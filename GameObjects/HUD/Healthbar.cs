using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.HUD
{
    class Healthbar : GameObject
    {
        public int maxHealth;
        public float currentHealth;

        public Healthbar()
        {
            
        }

        public void SetHealth(int health, int maxHealth, Vector2 position)
        {
            this.maxHealth = maxHealth; 
            currentHealth = (float)health / maxHealth;

            Texture2D rectangle = new Texture2D(SiegeStorm.Graphics.GraphicsDevice, 10, 1);

            Color[] pixels = new Color[10];
            Color fill = Color.Green;
            for (int i = 0; i < pixels.Length; ++i)
            {
                pixels[i] = fill;

                if (i + 1 > currentHealth * 10)
                {
                    fill = Color.Red;
                }               
            }
            rectangle.SetData(pixels);
            SetTexture(rectangle);
            SetPosition(new Vector2(position.X + 60, position.Y + 20));
        }

        public override void Draw(GameTime gameTime)
        {
            var w = SiegeStorm.ScreenWidth;
            var h = SiegeStorm.ScreenHeight;
            SiegeStorm.SpriteBatch.Draw(Texture, new Rectangle(Position.ToPoint(), new Point(w/17, h/50)), Color.White);
        }
    }
}
