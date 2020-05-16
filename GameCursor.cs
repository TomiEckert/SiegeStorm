using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm
{
    class GameCursor : GameObject
    {

        public GameCursor()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture("cursor"));
        }

        public override void Update(GameTime gameTime)
        {
            SetPosition(Mouse.GetState().Position.ToVector2());
        }
    }
}
