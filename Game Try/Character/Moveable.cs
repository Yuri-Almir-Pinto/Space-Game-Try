using Game_Try.Utils;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Movement
{
    public abstract class Moveable
    {
        private float moveSpeed;
        private Vector2 position;

        protected float MoveSpeed
        {
            get { return moveSpeed; }
            set { moveSpeed = value; }
        }

        protected Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public void Move(EMoveTypes direction)
        {
            if (direction.Equals(EMoveTypes.UP))
            {
                this.Position.Y -= this.MoveSpeed;
            }

            if (direction.Equals(EMoveTypes.UP))
            {

            }

            if (direction.Equals(EMoveTypes.UP))
            {

            }

            if (direction.Equals(EMoveTypes.UP))
            {

            }
        }

        public static EMoveTypes GetMoveType()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                return EMoveTypes.UP;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                return EMoveTypes.LEFT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                return EMoveTypes.RIGHT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                return EMoveTypes.DOWN;
            }
            else
            {
                return EMoveTypes.NONE;
            }
        }
    }
}
