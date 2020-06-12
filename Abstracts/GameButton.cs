using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SiegeStorm
{
    public abstract class GameButton : GameObject
    {
        private bool down;

        public override void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Released && down)
            {
                if (Mouse.GetState().Position.X > Position.X && Mouse.GetState().Position.X < Position.X + Texture.Width)
                {
                    if (Mouse.GetState().Position.Y > Position.Y && Mouse.GetState().Position.Y < Position.Y + Texture.Height)
                    {
                        down = false;
                        Pressed();
                    }
                }
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !down)
            {
                if (Mouse.GetState().Position.X > Position.X && Mouse.GetState().Position.X < Position.X + Texture.Width)
                {
                    if (Mouse.GetState().Position.Y > Position.Y && Mouse.GetState().Position.Y < Position.Y + Texture.Height)
                    {
                        down = true;
                    }
                }
            }
        }

        public abstract void Pressed();
    }
}