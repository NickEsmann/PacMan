using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    public class Level
    {
        private List<Wall> walls;

        public delegate void DrawWallsDelagate();
        public DrawWallsDelagate DrawCode = () => { };

        internal List<Wall> Walls { get => walls; private set => walls = value; }

        public Level (List<Wall> walls)
        {
            Walls = walls;
            UpdateWalls();
        }
        public Level(DrawWallsDelagate drawCode)
        {
           // Walls = drawCode;
  
            

            UpdateWalls();
            

        }
        public Level()
        {
            // Walls = drawCode;
            Walls = new List<Wall>();
            DrawWalls();

            UpdateWalls();


        }
        private void DrawWallsTest()
        {



        }

        private void DrawWalls()
        {
            Walls.Add(new Wall(0, 0));


            Walls.Add(new Wall(6, 4));
            Walls.Add(new Wall(8, 6));

            for (int x = 2; x < 4; x++)
            {
                for (int y = 6; y < 8; y++)
                    Walls.Add(new Wall(x, y));
            }


            for (int i = 5; i < 13; i++)
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

            //ConnectWalls();
            
        }
        private void UpdateWalls()
        {
            foreach (Wall w in Walls)
            {
                w.AdvancedSprites(Walls);
            }
        }


        //private void ConnectWalls()
        //{
        //    foreach (Wall w in Walls)
        //    {
        //        foreach (GameObject go in Grid)
        //        {
        //            if (w.Collision.Contains(go.Position) && go is Tile)
        //            {
        //                w.SetBaseTile((Tile)go);
        //            }
        //        }
        //    }
        //}
    }
}
