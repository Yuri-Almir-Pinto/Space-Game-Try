using Game_Try.Utils.Events;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Utils.Input
{
    public class KeyboardHelper
    {
        public static Keys UP = Keys.W;
        public static Keys DOWN = Keys.S;
        public static Keys LEFT = Keys.A;
        public static Keys RIGHT = Keys.D;
        public static Keys FIRE = Keys.Space;
        public static Keys QUIT = Keys.Escape;
        public static Keys NONE;

        public static EEventType checkInput()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(UP) || keyboard.IsKeyDown(DOWN) || keyboard.IsKeyDown(LEFT) || keyboard.IsKeyDown(RIGHT))
            {
                return EEventType.MOVEMENT_INPUT;
            }
            if (keyboard.IsKeyDown(FIRE))
            {
                return EEventType.ATTACK_INPUT;
            }
            if (keyboard.IsKeyDown(QUIT))
            {
                return EEventType.QUIT_INPUT;
            }
            return EEventType.NO_INPUT;
        }
    }
}
