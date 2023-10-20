using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Try.Utils.Spriting
{
    public class Sprite
    {

        protected Vector2 Position;

        protected float Scale;

        public Vector2 position 
        {   
            get { return this.Position; } 
            set {  this.Position = value; }
        }

        public float scale
        {
            get { return this.Scale; }
            set { this.Scale = value; }
        }

        public Sprite(Vector2 position, float scale)
        {
            this.position = position;
            this.scale = scale;
        }

        // TODO: Adicionar atributo de vetores/retângulos para serem usados para desenhar os sprites, ao invés de criar novos toda a vez.

        public virtual void draw(SpriteBatch _spriteBatch, Texture2D texture)
        {
            _spriteBatch.Draw(texture,
                            position,
                            null,
                            Color.White,
                            0f,
                            new Vector2(texture.Width / 2, texture.Height / 2),
                            scale,
                            SpriteEffects.None,
                            1f);
        }

        public virtual Texture2D load(ContentManager content, string path)
        {
            return content.Load<Texture2D>(path);
        }
    }
}
