using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MovementTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    public class Sprite
    {

        // Declaring a new texture
        private Texture2D playerTexture;
        // Declaring a variable for position
        public float Speed = 2;
        public Input Input;

        public Vector2 playerPosition;
        public Vector2 playerVelocity;


        public Sprite(Texture2D texture)
        {
            playerTexture = texture;
        }

        public void Update(GameTime gameTime, List<Collidable> _Collidables)
        {

        }

        public void Move()
        {
            if (Input == null)
                return;

            if(Keyboard.GetState().IsKeyDown(Input.Left))
            {
                playerPosition.X -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                playerPosition.X += Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                playerPosition.Y -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                playerPosition.Y += Speed;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the ball onto the screen, repositioning it to the centre
            spriteBatch.Draw(
                playerTexture,
                playerPosition,
                null,
                Color.White,
                0f,
                new Vector2(playerTexture.Width / 2, playerTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

        }

    }


}
