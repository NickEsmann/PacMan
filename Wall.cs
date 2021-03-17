using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Wall : GameObject
    {
        private static List<Texture2D> sprites;
        private float scale;

        //And we need a Node to Connect the wall to;




        /// <summary>
        /// This is so you only have to load wall sprites once
        /// </summary>
        /// <param name="content"></param>
        /// 
        private void Base_Wall()
        {
            sprite = sprites[0];
            scale = 0.5f;

        }

        public Wall(int x, int y, int tileSize)
        {
            position = new Vector2(x * tileSize, y * tileSize);
            Base_Wall();
        }
        public Wall(int x, int y)
        {
            position = new Vector2(x * 65, y * 65); // See Gridsize in Map 
            Base_Wall();
        }
        public static void LoadSprites(ContentManager content)
        {
            sprites = new List<Texture2D>();


            sprites.Add(content.Load<Texture2D>("Map/Walls/Wall0"));

        }

        public override void LoadContent(ContentManager content)
        {
            

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 1);
        }

        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
