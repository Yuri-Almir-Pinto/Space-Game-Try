using Game_Try.Utils.Events;
using Game_Try.Utils.Spriting;
using Microsoft.Xna.Framework;

namespace Game_Try.Entities.Abilities
{
    public interface IArmed
    {
        public float moveSpeed { get; set; }
        public Vector2 position { get; set; }
        public Rectangle destinationRectangle { get; set; }
        public Sprite sprite { get; set; }

        public void vectorFire(GameEventArgs eventArgs);
        public void rectangleFire(GameEventArgs eventArgs);
    }
}
