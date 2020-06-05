using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.MainMenu
{
    class Background : GameObject
    {
       public Background()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "bg"));
            SetPosition(new Vector2(0, 0));
        }

        public override void Draw(GameTime gameTime)
        {
            SiegeStorm.SpriteBatch.Draw(Texture, new Rectangle(0,0, SiegeStorm.ScreenWidth, SiegeStorm.ScreenHeight), Color.White);

        }
    }
}
