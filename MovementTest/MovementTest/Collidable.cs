using MovementTest;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace MovementTest
{
	public class Collidable
	{
		protected Texture2D Texture;
		public Vector2 Position;
		public Vector2 Velocity;
        public float Gravity;

        public Rectangle rectangle
        {
			get
            {
				return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }
		public Collidable(Texture2D texture, Vector2 position)
		{
			Texture = texture;
			Position = position;
        }

		public virtual void Update(GameTime gameTime, List<Collidable> Collidables)
		{

        }

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, Position, Color.White);
		}

        #region Collision
        protected bool TouchingLeft(Collidable Collidable, GameTime gameTime)
        {
            return this.rectangle.Right + this.Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds > Collidable.rectangle.Left &&
                (this.rectangle.Left < Collidable.rectangle.Left) &&
                (this.rectangle.Bottom > Collidable.rectangle.Top) &&
                (this.rectangle.Top < Collidable.rectangle.Bottom);
        }

        protected bool TouchingRight(Collidable Collidable, GameTime gameTime)
        {
            return this.rectangle.Left + this.Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds < Collidable.rectangle.Right && 
                (this.rectangle.Right > Collidable.rectangle.Right) && 
                (this.rectangle.Bottom > Collidable.rectangle.Top) && 
                (this.rectangle.Top < Collidable.rectangle.Bottom);
        }

        protected bool TouchingTop(Collidable Collidable, GameTime gameTime)
        {
        return this.rectangle.Bottom + (this.Velocity.Y + this.Gravity) * (float)gameTime.ElapsedGameTime.TotalSeconds * 16 > Collidable.rectangle.Top && 
                (this.rectangle.Bottom < Collidable.rectangle.Top) && 
                (this.rectangle.Right - 15 > Collidable.rectangle.Left) && 
                (this.rectangle.Left + 15 < Collidable.rectangle.Right);
        }

        protected bool TouchingBottom(Collidable Collidable, GameTime gameTime)
        {
            return this.rectangle.Top + this.Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds * 20 < Collidable.rectangle.Bottom - 5 && 
                (this.rectangle.Top > Collidable.rectangle.Bottom) && 
                (this.rectangle.Right > Collidable.rectangle.Left) && 
                (this.rectangle.Left < Collidable.rectangle.Right);
        }
        #endregion

    }

}
