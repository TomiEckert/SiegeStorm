using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm
{
    public abstract class GameScreen
    {
        List<GameObject> gameObjects;

        public GameScreen()
        {
            gameObjects = new List<GameObject>();
        }

        /// <summary>
        /// Returns an array of GameObjects
        /// </summary>
        /// <returns>Array of GameObjects</returns>
        protected GameObject[] GetObjects()
        {
            return gameObjects.ToArray();
        }

        /// <summary>
        /// Adds an object to the screen.
        /// </summary>
        /// <param name="gameObject">GameObject to add</param>
        protected void AddObject(GameObject gameObject)
        {
            if (!gameObjects.Contains(gameObject))
                gameObjects.Add(gameObject);
        }

        /// <summary>
        /// Removes an object from the screen.
        /// </summary>
        /// <param name="gameObject">GameObject to remove</param>
        protected void RemoveObject(GameObject gameObject)
        {
            if (gameObjects.Contains(gameObject))
                gameObjects.Remove(gameObject);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var gameObject in gameObjects) {
                gameObject.Update(gameTime); // TODO Implement update priority
            }
        }

        internal abstract void LoadContent();

        public virtual void Draw(GameTime gameTime)
        {
            foreach (var gameObject in gameObjects) {
                gameObject.Draw(gameTime); // TODO Implement draw priority/layers
            }
        }

        public void OnSO()
        {
            LoadContent();
            ScreenOpen();
        }
        public virtual void ScreenOpen()
        {
        }

        public void OnSC()
        {
            ScreenClose();
            foreach (var child in gameObjects)
            {
                child.Dispose();
            }
            gameObjects = new List<GameObject>();
        }
        public virtual void ScreenClose()
        {

        }
    }
}
