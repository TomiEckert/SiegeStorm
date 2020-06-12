using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SiegeStorm
{
    internal class GameCursor : GameObject
    {
        public GameCursor()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "cursor"));
        }

        public override void Update(GameTime gameTime)
        {
            SetPosition(Mouse.GetState().Position.ToVector2());
        }
    }
}