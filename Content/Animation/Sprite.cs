using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SiegeStorm.Managers;
using System;
using System.Linq;

namespace SiegeStorm.Content
{
    public class Sprite
    {
        protected AnimationPlayer animationPlayer;
        protected Vector2 position;
        protected Texture2D texture;

        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                if (this.animationPlayer != null)
                {
                    this.animationPlayer.Position = this.position;
                }
            }
        }

        public float Speed = 5f;
        public Vector2 Velocity;

        public Sprite()
        {
            this.animationPlayer = new AnimationPlayer(SiegeStorm.AnimationManager.animations.First().Value);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (this.texture != null)
            {
                spriteBatch.Draw(this.texture, this.Position, Color.White);
            }
            else if (this.animationPlayer != null)
            {
                this.animationPlayer.Draw(spriteBatch);
            }
            else
            {
                throw new Exception("Nothing to draw :'(");
            }
        }

        protected virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.Velocity.X = Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.Velocity.X = -Speed;
            }
        }

        protected virtual void SetAnimations()
        {
            if (this.Velocity.X > 0)
            {
                this.animationPlayer.Play(SiegeStorm.AnimationManager.animations["runRight"]);
            }
            else if (this.Velocity.X < 0)
            {
                this.animationPlayer.Play(SiegeStorm.AnimationManager.animations["runLeft"]);
            }
            else
            {
                this.animationPlayer.Stop();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            Move();

            SetAnimations();

            this.animationPlayer.Update(gameTime);

            this.Position += this.Velocity;
            this.Velocity = Vector2.Zero;
        }
    }
}