using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SiegeStorm.Managers;

namespace SiegeStorm
{
    public class SiegeStorm : Game
    {
        public static readonly TextureManager TextureManager = new TextureManager();
        public static readonly SoundManager SoundManager = new SoundManager();
        public static readonly StringManager StringManager = new StringManager();
        public static readonly ScreenManager ScreenManager = new ScreenManager();
        
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static ContentManager ContentManager;

        public SiegeStorm()
        {
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
            var screenWidth = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            var screenHeight = Graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            Graphics.PreferredBackBufferWidth = screenWidth;
            Graphics.PreferredBackBufferHeight = screenHeight;
            Graphics.ApplyChanges();
            Graphics.ToggleFullScreen();
        }

        /// <summary>
        /// Loads the game's content for startup.
        /// </summary>
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            SoundManager.LoadContent();
            TextureManager.LoadContent();
            StringManager.LoadContent();
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
            SpriteBatch.End();
        }
    }
}
