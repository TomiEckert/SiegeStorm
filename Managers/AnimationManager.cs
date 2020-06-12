using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiegeStorm.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class AnimationManager
    {
        public Dictionary<string, Animation> animations;
        private List<Sprite> sprites;

        public AnimationManager()
        {
            this.animations = new Dictionary<string, Animation>();
            this.sprites = new List<Sprite>();
        }

        public void AddAnimation(string name, Animation animation, Vector2 position) {
            this.animations.Add(name, animation);
            this.sprites = new List<Sprite>();
            this.sprites.Add(
                new Sprite() { 
                    Position = position
                }
            );
        }

        public void RemoveAnimation(string name)
        {
            this.animations.Remove(name);
            this.sprites = new List<Sprite>();
            this.sprites.Add(new Sprite());
        }

        public Animation GetAnimation(string name)
        {
            return animations[name];
        }

        public void Update(GameTime gameTime)
        {
            foreach(var sprite in this.sprites)
            {
                sprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var sprite in this.sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }
    }
}
