using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstGame
{
    public class Sprite : Platform
    {

        // Declaring a new texture
        private Texture2D playerTexture;
        // Declaring a variable for position
        private Vector2 playerPosition;
        public Vector2 playerVelocity;
        public bool hasJumped;


        public float playerSpeed = 400f;


        public Sprite(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            playerTexture = texture;
            playerPosition = position;
            hasJumped = true;

        }


        public override void Update(GameTime gameTime, List<Platform> platforms)
        {


            // For the user input, which is stored
            var kstate = Keyboard.GetState();

            // If we press 'A' then move left. If we press 'D' then move  right. Otherwise stay still.
            if (kstate.IsKeyDown(Keys.D))
                playerVelocity.X = 3f;
            else if (kstate.IsKeyDown(Keys.A))
                playerVelocity.X = -3f;
            else
                playerVelocity.X = 0f;

            // The sprite jumps if 'W' is pressed
            if (kstate.IsKeyDown(Keys.W) && hasJumped == false)
            {
                // Jumps (by how much and the speed)
                playerPosition.Y -= 20f;
                playerVelocity.Y = -10f;
                // Won't continuously go up
                hasJumped = true;
            }
            
            // If the sprite jumps, gravity will pull it down, and it will get faster as it goes down
            if (hasJumped == true)
            {
                float i = 1;
                playerVelocity.Y += 0.3f * i;
            }

            // If we're touching the floor, then hasJumped is set to false and sprite is at the bottom
            if (playerPosition.Y + playerTexture.Height >= 500)
            {
                hasJumped = false;
                playerVelocity.Y = 0f;
            }



            foreach (var platform in platforms)
            {
                if (platform == this)
                    continue;

                //Checking if we are hitting the sides of the platform and if we do then don't move
                if (this.velocity.X > 0 && this.TouchingLeft(platform) || this.velocity.X > 0 && this.TouchingRight(platform))
                    this.velocity.X = 0;

                if (this.velocity.Y > 0 && this.TouchingTop(platform) || this.velocity.Y > 0 && this.TouchingBottom(platform))
                    this.velocity.Y = 0;

            }


            playerPosition += playerVelocity;

            // So we can't keep pressing the key to get through
            velocity = Vector2.Zero;

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
