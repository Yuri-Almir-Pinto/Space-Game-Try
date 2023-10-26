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
        public delegate void MoveType(GameEventArgs eventArgs);
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

        public void vectorMove(GameEventArgs args)
        {
            Vector2 movement = this.position;
            float speed;
            if (args.data.Count > 0)
                speed = MoveSpeed * float.Parse(args.data["moveSpeedModifier"]);
            else
                speed = MoveSpeed;


            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_UP))
                movement.Y -= speed;
            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_DOWN))
                movement.Y += speed;
            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_LEFT))
                movement.X -= speed;
            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_RIGHT))
                movement.X += speed;

            this.position = movement;
        }

        public void rectangleMove(GameEventArgs args)
        {
            Rectangle movement = this.destinationRectangle;
            int speed;
            if (args.data.ContainsKey("moveSpeedModifier"))
            {
                float teste = float.Parse(args.data["moveSpeedModifier"]);
                speed = (int)(MoveSpeed*teste);
            }
                
            else
                speed = (int) MoveSpeed;

            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_UP))
                movement.Y -= speed;
            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_DOWN))
                movement.Y += speed;
            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_LEFT))
                movement.X -= speed;
            if (args.eventType.Contains(EEventType.MOVEMENT_INPUT_RIGHT))
                movement.X += speed;

            this.destinationRectangle = movement;
        }

        public static Texture2D getSpaceshipTexture(ContentManager content)
        {
            return content.Load<Texture2D>(ESprites.SPACESHIP_PATH);
        }

        public static void registerPlayerInputEvents(Spaceship spaceship)
        {
            EventHandler<GameEventArgs> move = (sender, eventArgs) =>
            {
                if (eventArgs.eventType.Contains(EEventType.MOVEMENT_INPUT))
                {
                    spaceship.moveType(eventArgs);
                }
            };

            EventHandler<GameEventArgs> quit = (sender, eventArgs) =>
            {
                if (eventArgs.eventType.Contains(EEventType.QUIT_INPUT))
                {
                    eventArgs.game.Exit();
                }
            };

            GameEventHandler.registerEvents(
                new List<EventHandler<GameEventArgs>>
                {
                    move, quit
                });

        }
    }
}
