using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace SiegeStorm
{
    public class Animation
    {
        public Texture2D[] Texture { get; private set; }
        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }
        public double FrameSpeed { get; set; }

        private double currentTime;
        private int height = SiegeStorm.ScreenHeight / 6;
        public delegate void animationDoneEvent();
        public event animationDoneEvent AnimationDone;

        public Animation(FileInfo[] files)
        {
            AnimationDone += Animation_AnimationDone;
            List<Texture2D> tex = new List<Texture2D>();
            foreach (var file in files)
            {
                var fs = new FileStream(file.FullName, FileMode.Open);
                tex.Add(Texture2D.FromStream(SiegeStorm.Graphics.GraphicsDevice, fs));
                fs.Close();
            }
            Texture = tex.ToArray();
            CurrentFrame = 0;
            FrameCount = Texture.Length;
            FrameSpeed = 30;
        }

        private void Animation_AnimationDone()
        {

        }

        internal void Draw(GameTime gameTime, Vector2 position)
        {
            currentTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (currentTime > FrameSpeed)
            {
                currentTime = 0;
                CurrentFrame++;
                if (CurrentFrame == FrameCount)
                {
                    AnimationDone();
                    CurrentFrame = 0;
                }
            }

            SiegeStorm.SpriteBatch.Draw(Texture[CurrentFrame], new Rectangle(position.ToPoint(), new Point(height, height)), Color.White);
        }
    }
}