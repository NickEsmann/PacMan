using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    public class Map
    {
        private int row = 20;
        private int col = 16;
        private int gridSize = 65;
        private List<GameObject> grid;


        public List<GameObject> Grid { get => grid; set => grid = value; }

        public Map()
        {
            Grid = new List<GameObject>();
            
            mapMaker();
        }

        public void LoadContent(ContentManager content)
        {
            foreach (GameObject go in Grid)
            {
                go.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject go in Grid)
            {
                go.Draw(spriteBatch);
            }
        }

        private void mapMaker()
        {
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    Grid.Add(new Tile(x, y, gridSize));
                }
            }
            
        }

        
    }
}
