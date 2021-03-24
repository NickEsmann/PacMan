using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace PacMan
{
    public abstract class GameObject
    {
        protected Texture2D sprite;
        private Vector2 position;
        protected Color color;
        protected Vector2 origin;

        protected Vector2 scale = new Vector2((float)Map.GridSize / 128, (float)Map.GridSize / 128);
        protected float rotation = 0f;

        public bool NeedPath = false;
        public List<Tile> Path;

        //protected int offsetX;
        //protected int offsetY;
        protected Vector2 offset;
        public int X { get; set; }
        public int Y { get; set; }

        protected Vector2 scale;
        protected float rotation=0f;
        //protected int offsetX;
        //protected int offsetY;
        protected Vector2 offset;

        protected int layer = 1;



        public GameObject()
        {
        }

        //public virtual Rectangle Collision
        //{
        //    get
        //    {
        //        return new Rectangle(
        //               (int)Position.X + (int)offset.X,
        //               (int)Position.Y,
        //               (int)sprite.Width,
        //               (int)sprite.Height +(int) offset.Y
        //           );
        //    }
        //}
        public virtual Rectangle Collision
        {
            get
            {
                return new Rectangle(
                       (int)Position.X + (int)offset.X,
                       (int)Position.Y + (int)offset.Y,

                       (int)(sprite.Width * scale.X),
                       (int)(sprite.Height * scale.Y)

                       (int)sprite.Width,
                       (int)sprite.Height 

                   );
            }
        }
        public Vector2 Position { get => position; protected set => position = value; }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Position, null, color, rotation, origin, scale, SpriteEffects.None, layer);
        }

        public abstract void OnCollision(GameObject other);

        public void CheckCollision(GameObject other)
        {
            if (Collision.Intersects(other.Collision))
            {
                OnCollision(other);
            }
        }
    }
}
