using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game_Try.Utils.Input;

namespace Game_Try.Character.Abilities
{
    public interface IMoveable
    {
        public float moveSpeed { get; set; }

        public void move(KeyboardState keyBoardState);
    }
}
