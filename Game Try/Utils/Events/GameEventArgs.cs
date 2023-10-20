using Game_Try.Main;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Utils.Events
{
    public struct GameEventArgs
    {
        public List<EEventType> eventType { get; set; } = new();
        public KeyboardState keyboardState { get; set; }
        public SpaceInvadersGame game { get; set; }
        public float moveSpeedModifier { get; set; }

        public GameEventArgs(List<EEventType> eventType, SpaceInvadersGame game)
        {
            foreach(EEventType type in eventType)
            {
                this.eventType.Add(type);
            }
            this.game = game;
            this.keyboardState = Keyboard.GetState();
            this.moveSpeedModifier = 1;
        }

        public GameEventArgs(SpaceInvadersGame game)
        {
            this.eventType.Add(EEventType.NO_INPUT);
            this.game = game;
            this.keyboardState = Keyboard.GetState();
            this.moveSpeedModifier = 1;
        }
    }
}
