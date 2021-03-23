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
        private int row = 19; //20
        private int col = 19; //16
        private static int gridSize = 32;//65
        private List<GameObject> grid;
        private Dictionary<Point, Tile> gridDictionary;

        public List<GameObject> Grid { get => grid; set => grid = value; }
        public static int GridSize { get => gridSize; private set => gridSize = value; }
        internal Dictionary<Point, Tile> GridDictionary { get => gridDictionary; private set => gridDictionary = value; }

        public Map()
        {
            Grid = new List<GameObject>();
            GridDictionary = new Dictionary<Point, Tile>();
            
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
                    Tile tile = new Tile(x, y, GridSize);
                    Grid.Add(tile);
                    GridDictionary.Add(new Point(x, y), tile);
                }
            }
            
        }

        
    }
}
