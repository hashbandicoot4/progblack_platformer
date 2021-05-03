using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public Collidable collidable;

        public Vector2 playerPosition;
        public Vector2 playerVelocity;


        public Sprite(Texture2D texture, Vector2 vector2)
        {
            playerTexture = texture;
        }

        public void Update(GameTime gameTime)
        {

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
