using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FirstGame
{
    //This class inherits from the Game class
    public class Game1 : Game
    {
        // Declaring a new texture
        Texture2D playerTexture;
        // Declaring a variable for position
        Vector2 playerPosition;
        // Declaring a variable for speed
        float playerSpeed;




        // Variables used to draw on the screen
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;






        // Used to initialise the starting variables
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }






        // Used to load any non-graphic related content
        protected override void Initialize()
        {
            // Used to initialise the position and speed
            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);
            playerSpeed = 400f;

            base.Initialize();
        }






        // Loads the game content
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the charachter
            playerTexture = Content.Load<Texture2D>("walking_right");

        }







        // Called many times to update the game state
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // For the user input, which is stored
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
                playerPosition.Y -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Down))
                playerPosition.Y += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Left))
                playerPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Right))
                playerPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // To create the bounds for the ball
            if (playerPosition.X > _graphics.PreferredBackBufferWidth - playerTexture.Width / 2)
                playerPosition.X = _graphics.PreferredBackBufferWidth - playerTexture.Width / 2;
            else if (playerPosition.X < playerTexture.Width / 2)
                playerPosition.X = playerTexture.Width / 2;

            if (playerPosition.Y > _graphics.PreferredBackBufferHeight - playerTexture.Height / 2)
                playerPosition.Y = _graphics.PreferredBackBufferHeight - playerTexture.Height / 2;
            else if (playerPosition.Y < playerTexture.Height / 2)
                playerPosition.Y = playerTexture.Height / 2;

            base.Update(gameTime);
        }







        // Called many times to update the screen
        protected override void Draw(GameTime gameTime)
        {
            // Colour the background beige
            GraphicsDevice.Clear(Color.Beige);

            // Draw the ball onto the screen, repositioning it to the centre
            _spriteBatch.Begin();
            _spriteBatch.Draw(
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
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
