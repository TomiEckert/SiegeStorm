using Microsoft.Xna.Framework.Graphics;

namespace SiegeStorm.Content
{
    public class Animation
    {
        public Texture2D Texture { get; private set; }
        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }
        public int FrameHeight { get { return Texture.Height; } }
        public int FrameWidth { get { return Texture.Width / FrameCount; } }
        public float FrameSpeed { get; set; }
        public bool IsLooping { get; set; }

        public Animation(Texture2D texture, int frameCount)
        {
            this.Texture = texture;
            this.FrameCount = frameCount;
            this.FrameSpeed = 0.2f;
            this.IsLooping = true;
        }
    }
}