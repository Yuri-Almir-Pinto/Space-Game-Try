using Game_Try.Entities.Abilities;
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

namespace Game_Try.Entities.Enemies
{
    public class Alien : Sprite, IMoveable
    {
        private float MoveSpeed;

        public float moveSpeed
        {
            get { return this.MoveSpeed; }
            set { this.MoveSpeed = value; }
        }

        public Alien(Vector2 position, float scale, float moveSpeed) : base(position, scale)
        {
            this.MoveSpeed = moveSpeed;
        }

        public void move(KeyboardState direction, float moveSpeedModifier = 1)
        {
            
            this.Position.X += this.MoveSpeed;
        }

        public Texture2D load(ContentManager content)
        {
            return content.Load<Texture2D>("Enemies/Alien");
        }
    }
}
