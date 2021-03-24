using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class GhostSpawn : GameObject
    {

        private static Texture2D ghostspawnSprite;
        private List<Ghost> ghosts;
        internal List<Ghost> Ghosts { get => ghosts; private set => ghosts = value; }
        public int X { get => x; private set => x = value; }
        public int Y { get => y; private set => y = value; }

        private int x;
        private int y;

        public Vector2 basePos
        {
            get
            {
                return new Vector2(X, Y);
            }
        }


        public GhostSpawn(int x, int y)
        {
            X = x;
            Y = y;
            color = Color.White;
            sprite = ghostspawnSprite;
            Position = new Vector2(x * Map.GridSize-1, y * Map.GridSize-1);


            AddGhosts();
            



        }
        private void AddGhosts()
        {
            Ghosts = new List<Ghost>();
            Ghosts.Add(new Ghost("Blinky", X, Y,this));
            Ghosts.Add(new Ghost("Pinky", X+1, Y,this));
            Ghosts.Add(new Ghost("Inky", X+3, Y,this));
            Ghosts.Add(new Ghost("Clyde", X+4, Y,this));

        }


        public static void StaticLoadContent(ContentManager content)
        {
            ghostspawnSprite = content.Load<Texture2D>("Map/GhostSpawn");
        }

        public override void LoadContent(ContentManager content)
        {
           
        }

        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}
