using Game_Try.Entities;
using Game_Try.Entities.Enemies;
using Game_Try.Utils.Events;
using Game_Try.Utils.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game_Try.Main
{
    public class SpaceInvadersGame : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        private static Spaceship spaceship = new Spaceship(new Vector2(100, 100), 0.1f, 8);
        private Texture2D spaceshipSprite;
        private static Alien alien = new Alien(new Vector2(100, 200), 0.05f, 2);
        private Texture2D alienSprite;
        private Texture2D background;

        public SpaceInvadersGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Spaceship.registerPlayerInputEvents(spaceship);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            alienSprite = alien.load(Content);
            spaceshipSprite = spaceship.loadSpaceship(Content);
            background = Content.Load<Texture2D>("Background/Space");
        }

        protected override void Update(GameTime gameTime)
        {
            if (KeyboardHelper.checkInput() != EEventType.NO_INPUT)
            {
                Spaceship.handlePlayerInput(this);
            }
            GameEventHandler.callEvents(new GameEventArgs(this)
            {
                eventType = new List<EEventType> { EEventType.MOVEMENT_INPUT },
                keyboardState = new KeyboardState(new Keys[] { Keys.S }),
                moveSpeedModifier = 0.5f

            });

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            alien.draw(_spriteBatch, alienSprite);
            spaceship.draw(_spriteBatch, spaceshipSprite);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void ExitGame()
        {
            Exit();
        }
    }
}