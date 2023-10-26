using Game_Try.Main;
using Game_Try.Utils.Events;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Utils.Input
{
    public static class KeyboardHandler
    {
        public static Keys UP = Keys.W;
        public static Keys DOWN = Keys.S;
        public static Keys LEFT = Keys.A;
        public static Keys RIGHT = Keys.D;
        public static Keys FIRE = Keys.Space;
        public static Keys QUIT = Keys.Escape;
        public static Keys RUN = Keys.LeftShift;
        public static Keys NONE;

        public static GameEventArgs checkInput(GameEventArgs args)
        {
            if (args.eventType.Count != 0)
            {
                #region Movement
                if (args.keyboardState.IsKeyDown(UP) ||
                    args.keyboardState.IsKeyDown(DOWN) ||
                    args.keyboardState.IsKeyDown(LEFT) ||
                    args.keyboardState.IsKeyDown(RIGHT))
                {
                    args.eventType.Add(EEventType.MOVEMENT_INPUT);

                    if (args.keyboardState.IsKeyDown(UP))
                        args.eventType.Add(EEventType.MOVEMENT_INPUT_UP);
                    if (args.keyboardState.IsKeyDown(DOWN))
                        args.eventType.Add(EEventType.MOVEMENT_INPUT_DOWN);
                    if (args.keyboardState.IsKeyDown(LEFT))
                        args.eventType.Add(EEventType.MOVEMENT_INPUT_LEFT);
                    if (args.keyboardState.IsKeyDown(RIGHT))
                        args.eventType.Add(EEventType.MOVEMENT_INPUT_RIGHT);
                    if (args.keyboardState.IsKeyDown(RUN))
                        args.eventType.Add(EEventType.MOVEMENT_INPUT_RUN);
                }
                #endregion

                if (args.keyboardState.IsKeyDown(FIRE))
                    args.eventType.Add(EEventType.ATTACK_INPUT);

                if (args.keyboardState.IsKeyDown(QUIT))
                    args.eventType.Add(EEventType.QUIT_INPUT);
            }
            else
                args.eventType.Add(EEventType.NO_INPUT);

            return args;
        }

        public static void runInput(SpaceInvadersGame game)
        {
            GameEventArgs args = new GameEventArgs(game);

            args = checkInput(args);

            GameEventHandler.callEvents(args);
        }

        public static void runInput(GameEventArgs args)
        {
            args = checkInput(args);

            GameEventHandler.callEvents(args);
        }

        public static void checkInput(SpaceInvadersGame game)
        {
            GameEventArgs args = new GameEventArgs(game);

            args = checkInput(args);

            GameEventHandler.callEvents(args);
        }


    }
}
