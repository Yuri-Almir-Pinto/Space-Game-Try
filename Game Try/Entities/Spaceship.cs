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

        public float moveSpeed 
        {
            get { return this.MoveSpeed; }
            set { this.MoveSpeed = value; }
        }

        public Spaceship (Vector2 position, float scale, float moveSpeed) : base (position, scale)
        {
            this.MoveSpeed= moveSpeed;
        }

        public void move(KeyboardState direction, float moveSpeedModifier = 1)
        {

            if (direction.IsKeyDown(KeyboardHelper.UP))
            {
                this.Position.Y -= (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.DOWN))
            {
                this.Position.Y += (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.LEFT))
            {
                this.Position.X -= (MoveSpeed * moveSpeedModifier);
            }

            if (direction.IsKeyDown(KeyboardHelper.RIGHT))
            {
                this.Position.X += (MoveSpeed * moveSpeedModifier);
            }
        }

        public Texture2D loadSpaceship(ContentManager content)
        {
            return content.Load<Texture2D>("Character/Spaceship");
        }

        public static void handlePlayerInput(SpaceInvadersGame game)
        {
        // TODO: Atualizar para adicionar todos os EEventType em uma única List<EEventType>, e então realizar um único "GameEventHandler.callEvents(eventArgs)" para todos os eventos.
            if (KeyboardHelper.checkInput() == EEventType.QUIT_INPUT)
            {
                GameEventArgs eventArgs = new GameEventArgs(new List<EEventType> { EEventType.QUIT_INPUT}, game);

                GameEventHandler.callEvents(eventArgs);
            }

            if (KeyboardHelper.checkInput() == EEventType.MOVEMENT_INPUT)
            {
                GameEventArgs eventArgs = new GameEventArgs(new List<EEventType> { EEventType.MOVEMENT_INPUT }, game);

                GameEventHandler.callEvents(eventArgs);
            }
        }

        public static void registerPlayerInputEvents(Spaceship spaceship)
        {
            EventHandler<GameEventArgs> move = (sender, eventArgs) =>
            {
                if (eventArgs.eventType.Contains(EEventType.MOVEMENT_INPUT))
                {
                    spaceship.move(eventArgs.keyboardState, eventArgs.moveSpeedModifier);
                }
            };

            EventHandler<GameEventArgs> quit = (sender, eventArgs) =>
            {
                if (eventArgs.eventType.Contains(EEventType.QUIT_INPUT))
                {
                    eventArgs.game.Exit();
                }
            };

            List<EventHandler<GameEventArgs>> send = new();
            send.Add(move);
            send.Add(quit);

            GameEventHandler.registerEvents(send);

        }
    }
}
