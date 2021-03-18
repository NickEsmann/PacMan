using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    class Tile : GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string spriteName;

        public Tile(string name, int x, int y, int size)
        {
            spriteName = name;
            this.X = x;
            this.Y = y;
            position = new Vector2(x * size, y * size); //the position of the sprite uses the variables in the construtors parentese and therefore we kinda choice where we place the sprite when we make a instans of this class
            color = Color.White;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Map/" + spriteName); //here we load our sprite and we use the string we define when we make a instans of this tile class
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void OnCollision(GameObject other)
        {

        }
    }
}