using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SiegeStorm
{
    public class SiegeStorm : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public SiegeStorm()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Initializes the game.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// Loads the game's content for startup.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Updates the game's logic
        /// </summary>
        /// <param name="gameTime">Snapshot of game time</param>
        protected override void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the game's textures.
        /// </summary>
        /// <param name="gameTime">Snapshot of game time</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
        }
    }
}
