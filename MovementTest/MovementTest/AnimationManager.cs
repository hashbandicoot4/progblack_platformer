using MovementTest;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovementTest
{
    public class AnimationManager
    {
        private Animation _animation;
        private float _timer;
        public Vector2 Position { get; set; }

        public AnimationManager(Animation animation)
        {
            _animation = animation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture,
                             Position,
                             new Rectangle(_animation.Frame * _animation.FrameWidth, 0, _animation.FrameWidth, _animation.FrameHeight), Color.White);
        }

        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;
            _animation.Frame = 0;
            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0f;
            _animation.Frame = 0;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;
                _animation.Frame++;

                if (_animation.Frame >= _animation.FrameCount)
                    _animation.Frame = 0;
            }
        }
    }
}