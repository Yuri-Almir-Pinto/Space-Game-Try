using Game_Try.Entities;
using Game_Try.Entities.Enemies;
using Game_Try.Utils.Events;
using Game_Try.Utils.Input;
using Game_Try.Utils.Spriting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Try.Main
{
    public class SpaceInvadersGame : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        private static Spaceship spaceship;
        private static Alien alien;
        private static Sprite background;

        public SpaceInvadersGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            alien = new Alien(new Vector2(100, 50), Alien.getAlienTexture(Content), 0.05f, 8);
            spaceship = new Spaceship(new Rectangle(100, 100, 50, 50), Spaceship.getSpaceshipTexture(Content), 8);
            background = new Sprite(new Rectangle(0, 0, 800, 480),
                                Content.Load<Texture2D>(ESprites.BACKGROUND_PATH));

            Spaceship.registerPlayerInputEvents(spaceship);
        }

        protected override void Update(GameTime gameTime)
        {
            GameEventArgs args = KeyboardHandler.checkInput(new GameEventArgs(this));
            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_RUN))
            {
                args.data["moveSpeedModifier"] = "2";
                GameEventHandler.callEvents(args);
            }
            else
                KeyboardHandler.runInput(this);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            background.DrawingMethod();
            alien.DrawingMethod();
            spaceship.DrawingMethod();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
