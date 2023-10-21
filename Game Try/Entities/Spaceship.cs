using Game_Try.Entities.Abilities;
using Game_Try.Main;
using Game_Try.Utils.Events;
using Game_Try.Utils.Input;
using Game_Try.Utils.Spriting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Try.Entities
{
    public class Spaceship : Sprite, IMoveable
    {
        private float MoveSpeed;
        public delegate void MoveType(KeyboardState direction, float moveSpeedModifier = 1);
        public MoveType moveType;

        public float moveSpeed 
        {
            get { return this.MoveSpeed; }
            set { this.MoveSpeed = value; }
        }

        public Spaceship (Vector2 position, Texture2D texture, float scale, float moveSpeed) : base (position, texture, scale)
        {
            this.MoveSpeed = moveSpeed;
            this.moveType += vectorMove;
        }

        public Spaceship(Rectangle destinationRectangle, Texture2D texture, float moveSpeed) : base(destinationRectangle, texture)
        {
            this.MoveSpeed = moveSpeed;
            this.moveType += rectangleMove;
        }

        public void vectorMove(KeyboardState direction, float moveSpeedModifier = 1)
        {
            Vector2 movement = this.position;
            if (direction.IsKeyDown(KeyboardHelper.UP))
            {
                movement.Y -= (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.DOWN))
            {
                movement.Y += (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.LEFT))
            {
                movement.X -= (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.RIGHT))
            {
                movement.X += (MoveSpeed * moveSpeedModifier);
            }
            this.position = movement;
        }

        public void rectangleMove(KeyboardState direction, float moveSpeedModifier = 1)
        {
            Rectangle movement = this.destinationRectangle;
            if (direction.IsKeyDown(KeyboardHelper.UP))
            {
                movement.Y -= (int) (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.DOWN))
            {
                movement.Y += (int) (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.LEFT))
            {
                movement.X -= (int)(MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.RIGHT))
            {
                movement.X += (int) (MoveSpeed * moveSpeedModifier);
            }
            this.destinationRectangle = movement;
        }

        public static Texture2D getSpaceshipTexture(ContentManager content)
        {
            return content.Load<Texture2D>(ESprites.SPACESHIP_PATH);
        }

        public static void handlePlayerInput(SpaceInvadersGame game)
        {
            List<EEventType> eEvents = new List<EEventType>();

            if (KeyboardHelper.checkInput().Contains(EEventType.QUIT_INPUT))
                eEvents.Add(EEventType.QUIT_INPUT);

            if (KeyboardHelper.checkInput().Contains(EEventType.MOVEMENT_INPUT))
                eEvents.Add(EEventType.MOVEMENT_INPUT);

            GameEventArgs eventArgs = new GameEventArgs(game)
            {
                eventType = eEvents
            };

            GameEventHandler.callEvents(eventArgs);
        }

        public static void registerPlayerInputEvents(Spaceship spaceship)
        {
            EventHandler<GameEventArgs> move = (sender, eventArgs) =>
            {
                if (eventArgs.eventType.Contains(EEventType.MOVEMENT_INPUT))
                {
                    spaceship.moveType(eventArgs.keyboardState, eventArgs.moveSpeedModifier);
                }
            };

            EventHandler<GameEventArgs> quit = (sender, eventArgs) =>
            {
                if (eventArgs.eventType.Contains(EEventType.QUIT_INPUT))
                {
                    eventArgs.game.Exit();
                }
            };

            List<EventHandler<GameEventArgs>> send = new()
            {
                move,
                quit
            };

            GameEventHandler.registerEvents(send);

        }
    }
}
