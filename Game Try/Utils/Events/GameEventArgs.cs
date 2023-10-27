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
        public Dictionary<string, string> data { get; set; } = new();

        public GameEventArgs(List<EEventType> eventType, SpaceInvadersGame game)
        {
            this.eventType = eventType;
            //foreach(EEventType type in eventType)
            //{
            //    this.eventType.Add(type);
            //}
            // Code of shame
            this.game = game;
            this.keyboardState = Keyboard.GetState();
        }

        public GameEventArgs(SpaceInvadersGame game)
        {
            this.eventType.Add(EEventType.NO_INPUT);
            this.game = game;
            this.keyboardState = Keyboard.GetState();
        }

        public GameEventArgs()
        {
            throw new Exception("Utilize algum construtor com argumentos. Se incerto, passe 'SpaceInvadersGame' como argumento.");
        }
    }
}
