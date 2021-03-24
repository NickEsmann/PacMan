using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    public class Level
    {
        private List<Wall> walls;

        //public delegate void DrawWallsDelagate();
        //public DrawWallsDelagate DrawCode = () => { };

        private List<GameObject> levelObjects;

        private GhostSpawn levelGhostSpawn;

        internal List<Wall> Walls { get => walls; private set => walls = value; }
        public List<GameObject> LevelObjects { get => levelObjects; private set => levelObjects = value; }
        internal GhostSpawn LevelGhostSpawn { get => levelGhostSpawn; private set => levelGhostSpawn = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="walls"></param>
        /// <param name="x">X placement of topLeft of Ghost spawn</param>
        /// <param name="y">Y Placement of top Left of Ghost spawn</param>
        public Level(List<Wall> walls, int x, int y)
        {
            Walls = walls;
            UpdateWalls();


            levelGhostSpawn = new GhostSpawn(x, y);

            AddToList();

        }

        private void AddToList()
        {
            LevelObjects = new List<GameObject>();
            foreach (Wall w in Walls)
                LevelObjects.Add(w);
            LevelObjects.Add(LevelGhostSpawn);
            foreach (Ghost g in LevelGhostSpawn.Ghosts)
            {
                LevelObjects.Add(g);
            }

        }



        //public Level(DrawWallsDelagate drawCode)
        //{
        //   // Walls = drawCode;



        //    UpdateWalls();


        //}
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

        public static Dictionary<string, List<Wall>> MazeArchive = new Dictionary<string, List<Wall>>();
        public static void CreateMazeArchive()
        {
            MazeArchive.Add("Heart", new List<Wall>()
            {
                new Wall(0,0),
                new Wall(0,19),
                new Wall(7,7),
                new Wall(7,8),
                new Wall(7,9),
                new Wall(8,6),
                new Wall(8,10),
                new Wall(9,6),
                new Wall(9,11),
                new Wall(10,7),
                new Wall(10,12),
                new Wall(11,6),
                new Wall(11,11),
                new Wall(12,6),
                new Wall(12,10),
                new Wall(13,7),
                new Wall(13,8),
                new Wall(13,9),
                new Wall(19,0),
                new Wall(19,19)
            });

            MazeArchive.Add("PacManLevel1from0x0", new List<Wall>()
            {
                new Wall(0,0),
                    new Wall(0,1),
                    new Wall(0,2),
                    new Wall(0,3),
                    new Wall(0,4),
                    new Wall(0,5),
                    new Wall(0,6),
                    new Wall(0,7),
                    new Wall(0,9),
                    new Wall(0,10),
                    new Wall(0,11),
                    new Wall(0,12),
                    new Wall(0,13),
                    new Wall(0,14),
                    new Wall(0,15),
                    new Wall(0,16),
                    new Wall(0,17),
                    new Wall(0,18),
                    new Wall(1,0),
                    new Wall(1,6),
                    new Wall(1,7),
                    new Wall(1,9),
                    new Wall(1,10),
                    new Wall(1,14),
                    new Wall(1,18),
                    new Wall(2,0),
                    new Wall(2,2),
                    new Wall(2,4),
                    new Wall(2,6),
                    new Wall(2,7),
                    new Wall(2,9),
                    new Wall(2,10),
                    new Wall(2,12),
                    new Wall(2,16),
                    new Wall(2,18),
                    new Wall(3,0),
                    new Wall(3,2),
                    new Wall(3,4),
                    new Wall(3,6),
                    new Wall(3,7),
                    new Wall(3,9),
                    new Wall(3,10),
                    new Wall(3,12),
                    new Wall(3,13),
                    new Wall(3,14),
                    new Wall(3,16),
                    new Wall(3,18),
                    new Wall(4,0),
                    new Wall(4,16),
                    new Wall(4,18),
                    new Wall(5,0),
                    new Wall(5,2),
                    new Wall(5,4),
                    new Wall(5,5),
                    new Wall(5,6),
                    new Wall(5,7),
                    new Wall(5,9),
                    new Wall(5,10),
                    new Wall(5,12),
                    new Wall(5,14),
                    new Wall(5,15),
                    new Wall(5,16),
                    new Wall(5,18),
                    new Wall(6,0),
                    new Wall(6,2),
                    new Wall(6,6),
                    new Wall(6,12),
                    new Wall(6,16),
                    new Wall(6,18),
                    new Wall(7,0),
                    new Wall(7,2),
                    new Wall(7,4),
                    new Wall(7,6),
                    new Wall(7,10),
                    new Wall(7,12),
                    new Wall(7,14),
                    new Wall(7,16),
                    new Wall(7,18),
                    new Wall(8,0),
                    new Wall(8,4),
                    new Wall(8,10),
                    new Wall(8,14),
                    new Wall(8,18),
                    new Wall(9,0),
                    new Wall(9,1),
                    new Wall(9,2),
                    new Wall(9,4),
                    new Wall(9,5),
                    new Wall(9,6),
                    new Wall(9,10),
                    new Wall(9,11),
                    new Wall(9,12),
                    new Wall(9,14),
                    new Wall(9,15),
                    new Wall(9,16),
                    new Wall(9,18),
                    new Wall(10,0),
                    new Wall(10,4),
                    new Wall(10,10),
                    new Wall(10,14),
                    new Wall(10,18),
                    new Wall(11,0),
                    new Wall(11,2),
                    new Wall(11,4),
                    new Wall(11,6),
                    new Wall(11,10),
                    new Wall(11,12),
                    new Wall(11,14),
                    new Wall(11,16),
                    new Wall(11,18),
                    new Wall(12,0),
                    new Wall(12,2),
                    new Wall(12,6),
                    new Wall(12,12),
                    new Wall(12,16),
                    new Wall(12,18),
                    new Wall(13,0),
                    new Wall(13,2),
                    new Wall(13,4),
                    new Wall(13,5),
                    new Wall(13,6),
                    new Wall(13,7),
                    new Wall(13,9),
                    new Wall(13,10),
                    new Wall(13,12),
                    new Wall(13,14),
                    new Wall(13,15),
                    new Wall(13,16),
                    new Wall(13,18),
                    new Wall(14,0),
                    new Wall(14,16),
                    new Wall(14,18),
                    new Wall(15,0),
                    new Wall(15,2),
                    new Wall(15,4),
                    new Wall(15,6),
                    new Wall(15,7),
                    new Wall(15,9),
                    new Wall(15,10),
                    new Wall(15,12),
                    new Wall(15,13),
                    new Wall(15,14),
                    new Wall(15,16),
                    new Wall(15,18),
                    new Wall(16,0),
                    new Wall(16,2),
                    new Wall(16,4),
                    new Wall(16,6),
                    new Wall(16,7),
                    new Wall(16,9),
                    new Wall(16,10),
                    new Wall(16,12),
                    new Wall(16,16),
                    new Wall(16,18),
                    new Wall(17,0),
                    new Wall(17,6),
                    new Wall(17,7),
                    new Wall(17,9),
                    new Wall(17,10),
                    new Wall(17,14),
                    new Wall(17,18),
                    new Wall(18,0),
                    new Wall(18,1),
                    new Wall(18,2),
                    new Wall(18,3),
                    new Wall(18,4),
                    new Wall(18,5),
                    new Wall(18,6),
                    new Wall(18,7),
                    new Wall(18,9),
                    new Wall(18,10),
                    new Wall(18,11),
                    new Wall(18,12),
                    new Wall(18,13),
                    new Wall(18,14),
                    new Wall(18,15),
                    new Wall(18,16),
                    new Wall(18,17),
                    new Wall(18,18)
            });

            MazeArchive.Add("PacManLevel1from1x1", new List<Wall>()
            {

                new Wall(1,1),
                    new Wall(1,2),
                    new Wall(1,3),
                    new Wall(1,4),
                    new Wall(1,5),
                    new Wall(1,6),
                    new Wall(1,7),
                    new Wall(1,8),
                    new Wall(1,10),
                    new Wall(1,11),
                    new Wall(1,12),
                    new Wall(1,13),
                    new Wall(1,14),
                    new Wall(1,15),
                    new Wall(1,16),
                    new Wall(1,17),
                    new Wall(1,18),
                    new Wall(1,19),
                    new Wall(2,1),
                    new Wall(2,7),
                    new Wall(2,8),
                    new Wall(2,10),
                    new Wall(2,11),
                    new Wall(2,15),
                    new Wall(2,19),
                    new Wall(3,1),
                    new Wall(3,3),
                    new Wall(3,5),
                    new Wall(3,7),
                    new Wall(3,8),
                    new Wall(3,10),
                    new Wall(3,11),
                    new Wall(3,13),
                    new Wall(3,17),
                    new Wall(3,19),
                    new Wall(4,1),
                    new Wall(4,3),
                    new Wall(4,5),
                    new Wall(4,7),
                    new Wall(4,8),
                    new Wall(4,10),
                    new Wall(4,11),
                    new Wall(4,13),
                    new Wall(4,14),
                    new Wall(4,15),
                    new Wall(4,17),
                    new Wall(4,19),
                    new Wall(5,1),
                    new Wall(5,17),
                    new Wall(5,19),
                    new Wall(6,1),
                    new Wall(6,3),
                    new Wall(6,5),
                    new Wall(6,6),
                    new Wall(6,7),
                    new Wall(6,8),
                    new Wall(6,10),
                    new Wall(6,11),
                    new Wall(6,13),
                    new Wall(6,15),
                    new Wall(6,16),
                    new Wall(6,17),
                    new Wall(6,19),
                    new Wall(7,1),
                    new Wall(7,3),
                    new Wall(7,7),
                    new Wall(7,13),
                    new Wall(7,17),
                    new Wall(7,19),
                    new Wall(8,1),
                    new Wall(8,3),
                    new Wall(8,5),
                    new Wall(8,7),
                    new Wall(8,11),
                    new Wall(8,13),
                    new Wall(8,15),
                    new Wall(8,17),
                    new Wall(8,19),
                    new Wall(9,1),
                    new Wall(9,5),
                    new Wall(9,11),
                    new Wall(9,15),
                    new Wall(9,19),
                    new Wall(10,1),
                    new Wall(10,2),
                    new Wall(10,3),
                    new Wall(10,5),
                    new Wall(10,6),
                    new Wall(10,7),
                    new Wall(10,11),
                    new Wall(10,12),
                    new Wall(10,13),
                    new Wall(10,15),
                    new Wall(10,16),
                    new Wall(10,17),
                    new Wall(10,19),
                    new Wall(11,1),
                    new Wall(11,5),
                    new Wall(11,11),
                    new Wall(11,15),
                    new Wall(11,19),
                    new Wall(12,1),
                    new Wall(12,3),
                    new Wall(12,5),
                    new Wall(12,7),
                    new Wall(12,11),
                    new Wall(12,13),
                    new Wall(12,15),
                    new Wall(12,17),
                    new Wall(12,19),
                    new Wall(13,1),
                    new Wall(13,3),
                    new Wall(13,7),
                    new Wall(13,13),
                    new Wall(13,17),
                    new Wall(13,19),
                    new Wall(14,1),
                    new Wall(14,3),
                    new Wall(14,5),
                    new Wall(14,6),
                    new Wall(14,7),
                    new Wall(14,8),
                    new Wall(14,10),
                    new Wall(14,11),
                    new Wall(14,13),
                    new Wall(14,15),
                    new Wall(14,16),
                    new Wall(14,17),
                    new Wall(14,19),
                    new Wall(15,1),
                    new Wall(15,17),
                    new Wall(15,19),
                    new Wall(16,1),
                    new Wall(16,3),
                    new Wall(16,5),
                    new Wall(16,7),
                    new Wall(16,8),
                    new Wall(16,10),
                    new Wall(16,11),
                    new Wall(16,13),
                    new Wall(16,14),
                    new Wall(16,15),
                    new Wall(16,17),
                    new Wall(16,19),
                    new Wall(17,1),
                    new Wall(17,3),
                    new Wall(17,5),
                    new Wall(17,7),
                    new Wall(17,8),
                    new Wall(17,10),
                    new Wall(17,11),
                    new Wall(17,13),
                    new Wall(17,17),
                    new Wall(17,19),
                    new Wall(18,1),
                    new Wall(18,7),
                    new Wall(18,8),
                    new Wall(18,10),
                    new Wall(18,11),
                    new Wall(18,15),
                    new Wall(18,19),
                    new Wall(19,1),
                    new Wall(19,2),
                    new Wall(19,3),
                    new Wall(19,4),
                    new Wall(19,5),
                    new Wall(19,6),
                    new Wall(19,7),
                    new Wall(19,8),
                    new Wall(19,10),
                    new Wall(19,11),
                    new Wall(19,12),
                    new Wall(19,13),
                    new Wall(19,14),
                    new Wall(19,15),
                    new Wall(19,16),
                    new Wall(19,17),
                    new Wall(19,18),
                    new Wall(19,19)
            });
            MazeArchive.Add("2", new List<Wall>()
            {

            });

        }







    }
}
