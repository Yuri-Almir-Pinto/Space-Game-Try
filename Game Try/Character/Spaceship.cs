using Game_Try.Character.Abilities;
using Game_Try.Main;
using Game_Try.Utils.Input;
using Game_Try.Utils.Spriting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Character
{
    public class Spaceship : Sprite, IMoveable
    {
        public float MoveSpeed;

        float IMoveable.moveSpeed 
        {
            get { return this.MoveSpeed; }
            set { this.MoveSpeed = value; }
        }

        public Spaceship(Vector2 position, float scale, float moveSpeed) : base(position, scale)
        {
            this.MoveSpeed= moveSpeed;
        }

        public void move(KeyboardState direction)
        {

            if (direction.IsKeyDown((Keys) EMoveTypes.UP))
            {
                Position.Y -= MoveSpeed;
            }

            if (direction.IsKeyDown((Keys) EMoveTypes.DOWN))
            {
                Position.Y += MoveSpeed;
            }

            if (direction.IsKeyDown((Keys) EMoveTypes.LEFT))
            {
                Position.X -= MoveSpeed;
            }

            if (direction.IsKeyDown((Keys) EMoveTypes.RIGHT))
            {
                Position.X += MoveSpeed;
            }
        }

        public Texture2D load(ContentManager content)
        {
            return content.Load<Texture2D>("Character/Spaceship");
        }
    }
}
