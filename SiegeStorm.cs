using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SiegeStorm.GameObjects.MainMenu;
using SiegeStorm.Managers;
using System;

namespace SiegeStorm
{
    public class SiegeStorm : Game
    {
        public static SiegeStorm Instance;
        public static readonly TextureManager TextureManager = new TextureManager();
        public static readonly SoundManager SoundManager = new SoundManager();
        public static readonly StringManager StringManager = new StringManager();
        public static readonly ScreenManager ScreenManager = new ScreenManager();
        
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static ContentManager ContentManager;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static bool FpsIsOn;

        private GameCursor cursor;
        private FrameCounter frameCounter;

        Song song;

        public SiegeStorm()
        {
            Instance = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentManager = Content;
            frameCounter = new FrameCounter();
        }

        /// <summary>
        /// Initializes the game.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            ScreenWidth = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            ScreenHeight = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            Graphics.PreferredBackBufferWidth = ScreenWidth;
            Graphics.PreferredBackBufferHeight = ScreenHeight;
            Graphics.ApplyChanges();
            //Graphics.ToggleFullScreen();
            IsFixedTimeStep = true;
        }

        /// <summary>
        /// Loads the game's content for startup.
        /// </summary>
        protected override void LoadContent()
        {
            ScreenWidth = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            ScreenHeight = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            //SoundManager.LoadContent();
            TextureManager.LoadContent();
            StringManager.LoadContent();
            ScreenManager.LoadContent();
            cursor = new GameCursor();
            this.song = Content.Load<Song>("awesomeness");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(song);
        }


        /// <summary>
        /// Updates the game's logic
        /// </summary>
        /// <param name="gameTime">Snapshot of game time</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                Exit();
            ScreenManager.Update(gameTime);
            cursor.Update(gameTime);
        }

        /// <summary>
        /// Draws the game's textures.
        /// </summary>
        /// <param name="gameTime">Snapshot of game time</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();
            ScreenManager.Draw(gameTime);
            cursor.Draw(gameTime);
            frameCounter.Update(gameTime);
            if (FpsIsOn)
            {
                var fps = string.Format("FPS: {0}", Math.Round(frameCounter.AverageFramesPerSecond, 2));
                SpriteBatch.DrawString(StringManager.GetFont(), fps, new Vector2(1, 1), Color.White);
            }
            SpriteBatch.End();
        }
    }
}
