﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SiegeStorm
{
    public class FrameCounter : GameObject
    {
        public const int MAXIMUM_SAMPLES = 50;

        private Queue<float> _sampleBuffer = new Queue<float>();

        public FrameCounter()
        {
        }

        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }
        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }

        public override void Update(GameTime gameTime)
        {
            CurrentFramesPerSecond = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;

            _sampleBuffer.Enqueue(CurrentFramesPerSecond);

            if (_sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                _sampleBuffer.Dequeue();
                AverageFramesPerSecond = _sampleBuffer.Average(i => i);
            }
            else
            {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            TotalFrames++;
            TotalSeconds += gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}