using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SiegeStorm.Managers;
using System;

namespace SiegeStorm
{
    public class SiegeStorm : Game
    {
        public static SiegeStorm Instance;
        public static readonly AnimationManager AnimationManager = new AnimationManager();
        public static readonly ItemManager ItemManager = new ItemManager();
        public static readonly LevelManager LevelManager = new LevelManager();
        public static readonly PlayerManager PlayerManager = new PlayerManager();
        public static readonly EnemyManager EnemyManager = new EnemyManager();
        public static readonly ScreenManager ScreenManager = new ScreenManager();
        public static readonly SoundManager SoundManager = new SoundManager();
        public static readonly StringManager StringManager = new StringManager();
        public static readonly TextureManager TextureManager = new TextureManager();

        public static ContentManager ContentManager;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;

        public static bool FpsIsOn;
        public static int ScreenHeight;
        public static int ScreenWidth;

        private GameCursor cursor;
        private FrameCounter frameCounter;

        public SiegeStorm()
        {
            Instance = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentManager = Content;
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
            SoundManager.LoadContent();
            TextureManager.LoadContent();
            ItemManager.LoadContent();
            PlayerManager.LoadContent();
            EnemyManager.LoadContent();
            StringManager.LoadContent();
            LevelManager.LoadContent();
            ScreenManager.LoadContent();
            cursor = new GameCursor();
            frameCounter = new FrameCounter();
        }

        /// <summary>
        /// Updates the game's logic
        /// </summary>
        /// <param name="gameTime">Snapshot of game time</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.LeftAlt) && Keyboard.GetState().IsKeyDown(Keys.Enter))
                Graphics.ToggleFullScreen();
            ScreenManager.Update(gameTime);
            SoundManager.Update(gameTime);
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