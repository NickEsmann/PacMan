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

        private List<Wall> walls;

        internal List<Wall> Walls { get => walls; private set => walls = value; }
        public List<GameObject> Grid { get => grid; set => grid = value; }

        public Map()
        {
            Grid = new List<GameObject>();
            
            mapMaker();

            Walls = new List<Wall>();
            DrawWalls();
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

        private void DrawWalls()
        {
            Walls.Add(new Wall(0, 0));


            Walls.Add(new Wall(6, 4));
            Walls.Add(new Wall(8, 6));

            for(int x=2;x<4;x++)
            {
                for(int y=6;y<8;y++)
                    Walls.Add(new Wall(x, y));
            }


            for(int i=5;i<13;i++)
            {
                Walls.Add(new Wall(9, i));
            }
            for (int i = 5; i < 7; i++)
            {
                Walls.Add(new Wall(13, i));
            }
            for (int i = 7; i < 9; i++)
            {
                Walls.Add(new Wall(i, 10));
            }
            for (int i = 10; i < 12; i++)
            {
                Walls.Add(new Wall(i, 10));
            }
            for (int i = 10; i < 14; i++)
            {
                Walls.Add(new Wall(i, 7));
            }

            ConnectWalls();
            MergeLists();
            UpdateWalls();
        }
        private void UpdateWalls()
        {
            foreach(Wall w in Walls)
            {
                w.AdvancedSprites(Walls);
            }
        }

        private void MergeLists()
        {
            foreach (Wall w in Walls)
            {
                Grid.Add(w);
            }
        }
        private void ConnectWalls()
        {
            foreach(Wall w in Walls)
            {
                foreach(GameObject go in Grid)
                {
                    if(w.Collision.Contains(go.Position) && go is Tile)
                    {
                        w.SetBaseTile((Tile)go);
                    }
                }
            }
        }
    }
}
