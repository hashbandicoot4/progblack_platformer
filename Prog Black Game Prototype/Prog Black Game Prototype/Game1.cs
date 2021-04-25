using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Prog_Black_Game_Prototype
{
    public class Game1 : Game
    {
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

        private Player _player;
        private List<Collidable> _Collidables = new List<Collidable>();
        //private TiledMap _tiledMap;
        //private TiledMapRenderer _tiledMapRenderer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here


            // Load the characters
            var playerTexture = Content.Load<Texture2D>("StandingRat");
            //_tiledMap = Content.Load<TiledMap>("TestLevel");
            //_tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

            _player = new Player(playerTexture, new Vector2(100, 250), _graphics);

            // Load the platforms, with a particular texture
            _Collidables.Add(new Collidable(Content.Load<Texture2D>("platform"), new Vector2(600, 300)));
            _Collidables.Add(new Collidable(Content.Load<Texture2D>("platform"), new Vector2(900, 500)));
        }

        protected override void Update(GameTime gameTime)
        {

            _player.Update(gameTime, _Collidables);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //_tiledMapRenderer.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Collidable Collidable in _Collidables)
                Collidable.Draw(_spriteBatch);

            _player.Draw(_spriteBatch);
            _spriteBatch.End();

            //_tiledMapRenderer.Draw();

            base.Draw(gameTime);
        }
    }
}
