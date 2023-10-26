using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game_Try.Utils.Input;
using Game_Try.Utils.Events;

namespace Game_Try.Entities.Abilities
{
    public interface IMoveable
    {
        public float moveSpeed { get; set; }
        public Vector2 position { get; set; }
        public Rectangle destinationRectangle {  get; set; }

        public void vectorMove(GameEventArgs eventArgs);
        public void rectangleMove(GameEventArgs eventArgs);
    }
}
