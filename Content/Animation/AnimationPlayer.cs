using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiegeStorm.Content;

namespace SiegeStorm.Managers
{
    public class AnimationPlayer
    {
        private Animation animation;
        private float timer;

        public Vector2 Position { get; set; }

        public AnimationPlayer(Animation animation)
        {
            this.animation = animation;
        }

        public void Play(Animation animation)
        {
            if (this.animation == animation)
            {
                return;
            }
            this.animation = animation;
            this.animation.CurrentFrame = 0;
            this.timer = 0f;
        }

        public void Stop()
        {
            this.timer = 0f;
            this.animation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.animation.FrameSpeed)
            {
                this.timer = 0f;
                this.animation.CurrentFrame++;
                if (this.animation.CurrentFrame >= this.animation.FrameCount)
                {
                    this.animation.CurrentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.animation.Texture,
                             this.Position,
                             new Rectangle(this.animation.CurrentFrame * this.animation.FrameWidth,
                                            0,
                                            this.animation.FrameWidth,
                                            this.animation.FrameHeight),
                             Color.White);
        }
    }
}