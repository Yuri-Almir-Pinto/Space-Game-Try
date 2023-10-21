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

        public static IEnumerable<EEventType> checkInput()
        {
            KeyboardState keyboard = Keyboard.GetState();
            List<EEventType> inputType = new();
            bool hadInput = false;

            if (keyboard.IsKeyDown(UP) || keyboard.IsKeyDown(DOWN) || keyboard.IsKeyDown(LEFT) || keyboard.IsKeyDown(RIGHT))
            {
                inputType.Add(EEventType.MOVEMENT_INPUT);
                hadInput = true;
            }
            if (keyboard.IsKeyDown(FIRE))
            {
                inputType.Add(EEventType.ATTACK_INPUT);
                hadInput = true;
            }
            if (keyboard.IsKeyDown(QUIT))
            {
                inputType.Add(EEventType.QUIT_INPUT);
                hadInput = true;
            }
            if (!hadInput) 
            {
                inputType.Add(EEventType.NO_INPUT);
            }
            return inputType;
        }
    }
}
