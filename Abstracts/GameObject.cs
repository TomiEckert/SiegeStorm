using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm
{
    public abstract class GameObject
    {
        Vector2 position;
        Texture2D texture;

        public GameObject()
        {
            texture = SiegeStorm.TextureManager.GetTexture(this);
        }

        protected Vector2 Position { get => position; }
        protected Texture2D Texture { get => texture; }

        protected void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        protected void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime)
        {
            SiegeStorm.SpriteBatch.Draw(texture, position, Color.White);
        }

        public void Dispose()
        {
            SiegeStorm.TextureManager.Dispose(this);
        }
    }
}
