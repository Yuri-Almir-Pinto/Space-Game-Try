using Game_Try.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Utils.Events
{
    public class GameEventHandler
    {
        public static event EventHandler<GameEventArgs> registeredEvents;

        public static void callEvents(GameEventArgs args)
        {
            registeredEvents?.Invoke(new object(), args);
        }

        public static void registerEvents(List<EventHandler<GameEventArgs>> events)
        {
            foreach (EventHandler<GameEventArgs> EVENT in events)
            {
                registeredEvents += EVENT;
            }
            
        }
    }
}
