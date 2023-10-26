using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Utils.Events
{
    public enum EEventType
    {
        PLAYER_INPUT,
        QUIT_INPUT,
        MOVEMENT_INPUT,
        MOVEMENT_INPUT_UP,
        MOVEMENT_INPUT_DOWN,
        MOVEMENT_INPUT_LEFT,
        MOVEMENT_INPUT_RIGHT,
        MOVEMENT_INPUT_RUN,
        ATTACK_INPUT,
        NO_INPUT
    }
}