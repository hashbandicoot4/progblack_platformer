using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstGame
{
    //This class inherits from the Game class
    public class Game1 : Game
    {
        // Declaring a new texture
        private Texture2D playerTexture;
        // Declaring a variable for position
        private Vector2 playerPosition;





        // Variables used to draw on the screen
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private Sprite _sprite1;
        private Sprite _sprite2;

        // A list of platforms
        private List<Platform> _platforms = new List<Platform>();






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

            base.Initialize();
        }






        // Loads the game content
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the charachters
            var playerTexture = Content.Load<Texture2D>("pokeball");

            _sprite1 = new Sprite(playerTexture, new Vector2(100,0));
            _sprite2 = new Sprite(playerTexture, new Vector2(500,0));

            // Load the platforms, with a particular texture
            _platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(100, 0)));
            _platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(400, 300)));
        }







        // Called many times to update the game state
        protected override void Update(GameTime gameTime)
        {

            _sprite1.Update(gameTime, _platforms);
            _sprite2.Update(gameTime, _platforms);
            base.Update(gameTime);
        }







        // Called many times to update the screen
        protected override void Draw(GameTime gameTime)
        {
            // Colour the background beige
            GraphicsDevice.Clear(Color.White);

            
            _spriteBatch.Begin();

            // Draw all the platforms onto the screen
            foreach (Platform platform in _platforms)
                platform.Draw(_spriteBatch);

            // Draw the balls onto the screen
            _sprite1.Draw(_spriteBatch);
            _sprite2.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

static class RectangleHelper
{
    const int margin = 5;

    //What will happen if the object touches the top of the platform
    public static bool onTopOf(this Rectangle r1, Rectangle r2)
    {
        return ((r1.Bottom >= r2.Top - margin) && (r1.Bottom <= r2.Top + (r2.Height/2)) && (r1.Right >= r2.Left + 5) && (r1.Left <= r2.Right - 5));
    }

}