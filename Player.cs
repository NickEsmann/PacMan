using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Player : GameObject
    {
        private Vector2 velocity;

        public Player()
        {
            speed = 150;
            velocity = Vector2.Zero;
            fps = 10;

        }

        public override void Update(GameTime gametime)
        {
            HandleInput();
            Move(gametime);


            Animate(gametime);

        }

        private void Animate(GameTime gametime)
        {
            throw new NotImplementedException();
        }

        public void HandleInput()
        {
            velocity = Vector2.Zero;
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }


            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
        }

        public override void LoadContent(ContentManager content)
        {


            sprites = new Texture2D[4];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>((i + 1) + "fwd");
            }

            sprite = sprites[0];

            this.position = new Vector2(GameWorld.Screensize.X / 2, GameWorld.Screensize.Y - sprite.Height / 2);
            this.origin = new Vector2(sprite.Height / 2, sprite.Width / 2);



        }

        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}    
