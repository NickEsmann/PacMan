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
        protected Texture2D[] sprites;
        private int newSprite = 35;
        private int currentIndex = 0;
        protected Vector2 position;
        protected Vector2 offset;
        protected Vector2 origin;
        protected Vector2 scale;
        protected Color color;
        
        public GameObject()
        {
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(
                    (int)(position.X + offset.X),
                    (int)(position.Y + offset.Y),
                    sprite.Width,
                    sprite.Height
                    );

            }
        }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 1);
        }

        public abstract void OnCollision(GameObject other);

        public void CheckCollision(GameObject other)
        {
            //if (Collision.Intersects(other.Collision))
            //{
            //    OnCollision(other);
            //}
        }
    }
}
