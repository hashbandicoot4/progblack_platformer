using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MovementTest
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Vector2 ballPosition;
        Vector2 ballSpeed;
        float ballAccel;
        float Gravity;
        float JumpSpeed;
        bool Grounded;
        float Drag;
        float MaxSpeed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = new Vector2(0f, 0f);
            ballAccel = 13f;
            Gravity = 15f;
            JumpSpeed = 300f;
            Grounded = false;
            Drag = 0.93f;
            MaxSpeed = 300f;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
                if (Grounded == true)
                {
                    ballSpeed.Y -= JumpSpeed;
                    Grounded = false;
                }
                //ballSpeed.Y -= ballAccel;
                ballPosition.Y += ballSpeed.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.S))
                ballSpeed.Y += ballAccel;
                ballPosition.Y += ballSpeed.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.A))
                if (ballSpeed.X <= -MaxSpeed)
                    ballSpeed.X = -MaxSpeed;
                else
                    ballSpeed.X -= ballAccel;
                ballPosition.X += ballSpeed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.D))
                if (ballSpeed.X >= MaxSpeed)
                    ballSpeed.X = MaxSpeed;
                else
                    ballSpeed.X += ballAccel;
            ballPosition.X += ballSpeed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyUp(Keys.A) && kstate.IsKeyUp(Keys.D))
                ballSpeed.X *= Drag;

            ballSpeed.Y += Gravity;

            if (Math.Abs(ballSpeed.X) <= 14f * (float)gameTime.ElapsedGameTime.TotalSeconds)
                ballSpeed.X = 0f;

            float CollidedScreenX = IsCollide(ballPosition.X, 0, _graphics.PreferredBackBufferWidth, ballTexture.Width);
            float CollidedScreenY = IsCollide(ballPosition.Y, 0, _graphics.PreferredBackBufferHeight, ballTexture.Height);

            if (CollidedScreenX == 1)
            {
                ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
                ballSpeed.X = -0.9f * ballSpeed.X;
            }
            else if (CollidedScreenX == 2)
            {
                ballPosition.X = ballTexture.Width / 2;
                ballSpeed.X = -0.9f * ballSpeed.X;
            }
                

            if (CollidedScreenY == 1)
            {
                ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
                Grounded = true;
                ballSpeed.Y = 0f;
            }

            else if (CollidedScreenY == 2)
            {
                ballPosition.Y = ballTexture.Height / 2;
                ballSpeed.Y = 0f;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(
    ballTexture,
    ballPosition,
    null,
    Color.White,
    0f,
    new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
    Vector2.One,
    SpriteEffects.None,
    0f
);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        //Take in obj position, obj size (in given dimension), boundary start and end (in given dimension).
        //Return 1 if collision on end of boundary (right or down), 2 if on start (left or up), 0 if no collision
        public float IsCollide(float Position, float boundaryStart, float boundaryEnd, float Dimension)
        {
            if (Position > boundaryEnd - Dimension / 2)
            {return 1;}

            else if (Position < boundaryStart + Dimension / 2)
            {return 2;}

            else
            {return 0;}
        }
    }
}
