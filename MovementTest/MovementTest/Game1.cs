using FirstGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovementTest
{
    public class Game1 : Game
    {
        // Declaring a new texture
        private Texture2D playerTexture;
        // Declaring a variable for position
        private Vector2 playerPosition;
        //
        //
        //KNOWN ISSUES
        //
        // 1) DODGY COLLISIONS - SINKS INTO THE COLLISION RATHER THAN NORMAL FOR FALLING
        // 2) CAN JUMP IN MID AIR IF FALLING OFF PLATFORM RATHER THAN JUMPING OFF DUE TO HOW "GROUNDED" WORKS
        // 3) HITBOX DODGY WHEN JUMPING UP
        //
        //
        //

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;



        private List<Sprite> _sprites;

        private List<Collidable> _Collidables = new List<Collidable>();






        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }





        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }





        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Load the charachters
            var playerTexture = Content.Load<Texture2D>("StandingRat");

            _sprites = new List<Sprite>()
            {
                new Sprite(playerTexture)
                {
                    playerPosition = new Vector2(100, 100),
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D
                    }
                },
                new Sprite(playerTexture)
                {
                    playerPosition = new Vector2(200, 100),
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right
                    }
                },
            };

            // Load the platforms, with a particular texture
            _Collidables.Add(new Collidable(Content.Load<Texture2D>("platform"), new Vector2(100, 200)));
            _Collidables.Add(new Collidable(Content.Load<Texture2D>("platform"), new Vector2(400, 400)));
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (var sprite in _sprites)
                sprite.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Collidable Collidable in _Collidables)
                Collidable.Draw(_spriteBatch);

            foreach (var sprite in _sprites)
                sprite.Draw(SpriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
