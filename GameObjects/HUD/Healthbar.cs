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

        public void SetHealth(int health, Vector2 position)
        {
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
            SetPosition(new Vector2(position.X + 80, position.Y + 30));
        }

        public override void Draw(GameTime gameTime)
        {
            SiegeStorm.SpriteBatch.Draw(Texture, new Rectangle(Position.ToPoint(), new Point(150, 15)), Color.White);
        }
    }
}
