using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    class Map
    {
        private int row = 20;
        private int col = 16;
        private int gridSize = 65;
        private List<GameObject> grid; //the list we create for our sprites
        
        public List<Vector2> EnemyPath { get; set; } = new List<Vector2>(); //This is the list of how the enemy should move



        public Map()
        {
            grid = new List<GameObject>();
            enemyGridPos = new List<Vector2>();
            mapMaker();
        }

        public void LoadContent(ContentManager content)
        {
            foreach (GameObject go in grid)
            {
                go.LoadContent(content); //here we load our sprites in the grid
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject go in grid)
            {
                go.Draw(spriteBatch); //here we draw our sprites in the grid
            }
        }

        private void mapMaker()
        {
            enemyGridPos.Add(new Vector2(1, 1));
            

            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    if (enemyGridPos.Exists(t => t.X == x && t.Y == y)) //if the position we get from the 2 forloops exist in the list of position then it returns true, otherwise it returns false
                    {

                        grid.Add(new Tile("Tile2", x, y, gridSize)); //places the brown sprite
                    }
                    else
                    {
                        grid.Add(new Tile("Tile1", x, y, gridSize)); //place the green sprite
                    }
                }
            }
        }
    }
}
