using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PacMan
{
    public class Map
    {
        public int row = 19; //20
        public int col = 19; //16
        private static int gridSize = 32;//65
        private List<Tile> grid;
        private Dictionary<Point, Tile> gridDictionary;

        private const int moveCost = 10;

        public List<Tile> Grid { get => grid; set => grid = value; }
        public static int GridSize { get => gridSize; private set => gridSize = value; }
        internal Dictionary<Point, Tile> GridDictionary { get => gridDictionary; private set => gridDictionary = value; }

        public Map()
        {
            Grid = new List<Tile>();
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
            foreach (Tile go in Grid)
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

        public List<Tile> FindPath(Point beginPoint, Point lastPoint)
        {
            Tile startPoint = GridDictionary[beginPoint];
            startPoint.SetColor(Color.Blue);
            Tile endPoint = GridDictionary[lastPoint];
            endPoint.SetColor(Color.Red);
            List<Tile> openList = new List<Tile>() { startPoint };
            List<Tile> lockedList = new List<Tile>();

            bool pathDone = false;
            while (!pathDone && openList.Count > 0)
            {
                Tile best = openList.First(o => o.F == openList.Min(p => p.F));
                openList.Remove(best);
                lockedList.Add(best);

                for (int x = -1; x <= 1; x++)
                {
                    if (pathDone)
                    {
                        break;
                    }

                    for (int y = -1; y <= 1; y++)
                    {
                        if (pathDone)
                        {
                            break;
                        }

                        int neighborX = best.X + x;
                        int neighborY = best.Y + y;

                        if (neighborX < 0 || neighborY < 0 || neighborX > row || neighborY > col)
                        {
                            continue;
                        }


                        if (x != 0 && y != 0)
                        {
                            continue;
                        }


                        Tile neighbor = GridDictionary[new Point(neighborX, neighborY)];


                        if (lockedList.Contains(neighbor))
                        {
                            continue;
                        }

                        if (!neighbor.isWalkable)
                        {
                            continue;
                        }

                        int newG = best.G + moveCost;

                        bool updateNeighbor = false;

                        if (openList.Contains(neighbor))
                        {
                            if (neighbor.G > newG)
                            {
                                updateNeighbor = true;
                            }
                        }
                        else
                        {
                            openList.Add(neighbor);
                            updateNeighbor = true;
                        }

                        if (updateNeighbor)
                        {
                            neighbor.SetParent(best);

                            neighbor.G = newG;

                            neighbor.H = neighbor.Distance(endPoint) * moveCost;
                        }

                        if (neighbor == endPoint)
                        {
                            pathDone = true;
                        }
                        else
                        {
                            Thread.Sleep(1);
                            neighbor.SetColor(Color.Yellow);
                        }
                    }
                }
            }
            List<Tile> Path = new List<Tile>();

            if (endPoint.Parent == null)
            {

            }
            else
            {
                Tile currentPoint = endPoint;
                Path.Add(endPoint);
                while (currentPoint != startPoint)
                {
                    currentPoint = currentPoint.Parent;
                    if (currentPoint != startPoint)
                    {
                        currentPoint.SetColor(Color.Green);
                        Path.Add(currentPoint);
                    }
                }
            }

            Path.Reverse();
            return Path;
        }

    }
}
