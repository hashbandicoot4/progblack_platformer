using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstGame
{
    public class Platform
    {
        protected Texture2D platformTexture;
        public Vector2 platformPosition;
        public Vector2 velocity;
        public float Speed;

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)platformPosition.X, (int)platformPosition.Y, platformTexture.Width, platformTexture.Height);
            }
        }





        public Platform(Texture2D texture, Vector2 position)
        {
            platformTexture = texture;
            platformPosition = position;

        }





        public virtual void Update(GameTime gameTime, List<Platform> platforms)
        { }





        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(platformTexture, platformPosition, Color.White);
        }





        #region Collision
        protected bool TouchingLeft(Platform platform)
        {
            return this.rectangle.Right + this.velocity.X > platform.rectangle.Left && (this.rectangle.Left < platform.rectangle.Left) && (this.rectangle.Bottom > platform.rectangle.Top) && (this.rectangle.Top < platform.rectangle.Bottom);
        }

        protected bool TouchingRight(Platform platform)
        {
            return this.rectangle.Left + this.velocity.X < platform.rectangle.Right && (this.rectangle.Right > platform.rectangle.Right) && (this.rectangle.Bottom > platform.rectangle.Top) && (this.rectangle.Top < platform.rectangle.Bottom);
        }

        protected bool TouchingTop(Platform platform)
        {
            return this.rectangle.Bottom + this.velocity.Y > platform.rectangle.Top && (this.rectangle.Top < platform.rectangle.Top) && (this.rectangle.Right > platform.rectangle.Left) && (this.rectangle.Left < platform.rectangle.Left);
        }

        protected bool TouchingBottom(Platform platform)
        {
            return this.rectangle.Top + this.velocity.Y < platform.rectangle.Bottom && (this.rectangle.Bottom > platform.rectangle.Bottom) && (this.rectangle.Right > platform.rectangle.Left) && (this.rectangle.Left < platform.rectangle.Left);
        }
        #endregion


    }
}