using Game_Try.Entities.Abilities;
using Game_Try.Utils.Input;
using Game_Try.Utils.Spriting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Entities.Enemies
{
    public class Alien : Sprite
    {
        private float MoveSpeed;

        public float moveSpeed
        {
            get { return this.MoveSpeed; }
            set { this.MoveSpeed = value; }
        }

        public Alien(Vector2 position, Texture2D texture, float scale, float moveSpeed) : base(position, texture, scale)
        {
            this.MoveSpeed = moveSpeed;
        }

        public void move(KeyboardState direction, float moveSpeedModifier = 1)
        {
            
            
        }

        public static Texture2D getAlienTexture(ContentManager content)
        {
            return content.Load<Texture2D>(ESprites.ALIEN_PATH);
        }

        public void drawAlien(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(this.texture,
                            this.position,
                            null,
                            Color.White,
                            0f,
                            this.origin,
                            this.scale,
                            SpriteEffects.None,
                            1f);
        }
    }
}
