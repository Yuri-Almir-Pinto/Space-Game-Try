using Game_Try.Main;
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
        protected SpriteBatch _spriteBatch = SpaceInvadersGame._spriteBatch;
        private Vector2 Position;
        private Vector2 Origin;
        private Rectangle DestinationRectangle;
        private float Scale;
        private Texture2D Texture;
        public delegate void DrawMethod();
        public DrawMethod DrawingMethod;
        public Rectangle destinationRectangle
        {
            get { return DestinationRectangle; }
            set { DestinationRectangle = value; }
        }
        public Texture2D texture
        {
            get { return Texture; }
            set { Texture = value; }
        }
        public Vector2 origin
        {
            get { return Origin; }
            set { Origin = value; }
        }
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
        public Sprite(Vector2 position, Texture2D texture, float scale)
        {
            this.position = position;
            this.scale = scale;
            this.texture = texture;
            this.origin = new Vector2(texture.Width/2, texture.Height/2);
            DrawingMethod += () =>
            {
                this._spriteBatch.Draw(this.texture,
                            this.position,
                            null,
                            Color.White,
                            0f,
                            this.origin,
                            this.scale,
                            SpriteEffects.None,
                            1f);
            };
        }

        public Sprite(Rectangle destinationRectangle, Texture2D texture)
        {
            this.position = new Vector2(destinationRectangle.X, destinationRectangle.Y);
            this.destinationRectangle = destinationRectangle;
            this.texture = texture;
            DrawingMethod += () => _spriteBatch.Draw(this.texture,
                                                    this.destinationRectangle,
                                                    Color.White);
        }

        public static Texture2D getTexture(ContentManager content, string path)
        {
            return content.Load<Texture2D>(path);
        }
    }
}
