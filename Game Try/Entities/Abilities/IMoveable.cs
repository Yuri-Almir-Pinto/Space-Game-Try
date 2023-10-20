using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game_Try.Utils.Input;

namespace Game_Try.Entities.Abilities
{
    public interface IMoveable
    {
        protected float moveSpeed { get; set; }

        public Vector2 position { get; set; }

        public float scale { get; set; }

        public void move(KeyboardState Direction, float moveSpeedModifier);
    }
}
