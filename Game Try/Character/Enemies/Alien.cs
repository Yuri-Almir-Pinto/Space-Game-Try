using Game_Try.Character.Abilities;
using Game_Try.Utils.Input;
using Game_Try.Utils.Spriting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Character.Enemies
{
    public class Alien : Sprite, IMoveable
    {
        public float MoveSpeed;

        float IMoveable.moveSpeed
        {
            get { return this.MoveSpeed; }
            set { this.MoveSpeed = value; }
        }

        public Alien(Vector2 position, float scale, float moveSpeed) : base(position, scale)
        {
            this.MoveSpeed = moveSpeed;
        }

        void IMoveable.move(KeyboardState keyBoardState)
        {
            throw new NotImplementedException();
        }

        public void move(EMoveTypes direction)
        {
            this.Position.X += this.MoveSpeed;
        }

        public Texture2D load(ContentManager content)
        {
            return content.Load<Texture2D>("Enemies/Alien");
        }
    }
}
