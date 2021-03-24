using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PacMan
{
    public class Wall : GameObject
    {
        private static Dictionary<string, Texture2D> sprites;
        //private float scale;

        //And we need a Node to Connect the wall to;

        private float angle;

        private enum Direction : int
        {
            Up = 1, Right = 2, Down = 3, Left = 4
        }

        private Dictionary<Direction, bool> checkNeighbors;
        private List<int> neighbors;


        private Tile BaseTile;





        //FOR DEBUGGING
        private static int counter = 1;
        private int wallNum;
        private string basePosition;
        private static SpriteFont font;
        private Color textColor;
        public Point baseCoordinates;

        public override Rectangle Collision
        {
            get
            {
                return new Rectangle(
                       (int)Position.X + (int)offset.X,
                       (int)Position.Y + (int)offset.Y,
                       (int)(sprite.Width * scale.X),
                       (int)(sprite.Height * scale.Y)
                   );
            }
        }





        private void ForDebugging()
        {

            wallNum = counter;
            counter += 1;
            textColor = Color.White;

            basePosition = $"{baseCoordinates.X},{baseCoordinates.Y}";


        }


        /// <summary>
        /// This is so you only have to load wall sprites once
        /// </summary>
        /// <param name="content"></param>
        /// 
        private void Base_Wall()
        {

            ForDebugging();



            checkNeighbors = new Dictionary<Direction, bool>();
            checkNeighbors.Add(Direction.Up, false);
            checkNeighbors.Add(Direction.Right, false);
            checkNeighbors.Add(Direction.Down, false);
            checkNeighbors.Add(Direction.Left, false);

            sprite = sprites["Alone"];
            //scale = new Vector2(0.5f, 0.5f);
            color = Color.White;
            layer = 0;

            angle = (float)Math.PI / 2.0f;  // 90 degrees

            rotation = 0;

            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

            offset = new Vector2((-origin.X * scale.X) - 1, (-origin.Y * scale.Y) - 1);

            Position = new Vector2(Position.X + offset.X, Position.Y + offset.Y);

            ConnectToTile();


        }

        public Wall(int x, int y, int tileSize)
        {
            X = x;
            Y = y;

            Position = new Vector2(x * tileSize, y * tileSize);
            Base_Wall();
        }
        public Wall(int x, int y)
        {
            X = x;
            Y = y;
            //baseCoordinates = new Point(x, y);
            Position = new Vector2(x * Map.GridSize, y * Map.GridSize); // See Gridsize in Map 
            Base_Wall();
        }
        public static void LoadSprites(ContentManager content)
        {
            sprites = new Dictionary<string, Texture2D>();
            string name;

            { name = "Alone"; sprites.Add(name, content.Load<Texture2D>("Map/Walls/" + name)); }
            { name = "1Con"; sprites.Add(name, content.Load<Texture2D>("Map/Walls/" + name)); }
            { name = "2ConL"; sprites.Add(name, content.Load<Texture2D>("Map/Walls/" + name)); }
            { name = "2ConC"; sprites.Add(name, content.Load<Texture2D>("Map/Walls/" + name)); }
            { name = "3Con"; sprites.Add(name, content.Load<Texture2D>("Map/Walls/" + name)); }
            { name = "4Con"; sprites.Add(name, content.Load<Texture2D>("Map/Walls/" + name)); }

            font = content.Load<SpriteFont>("Font");


        }

        private void ConnectToTile()
        {
            if (BaseTile == null)
            {
                foreach (GameObject go in GameWorld.map.Grid)
                {
                    if (Collision.Contains(go.Collision.Center) && go is Tile)
                    {
                        if (go.X == this.X && go.Y == this.Y)
                        {
                            //Debug.WriteLine("Connected");
                            SetBaseTile((Tile)go);
                            break;
                        }

                    }
                }
            }
        }

        private void SetBaseTile(Tile tile)
        {
            BaseTile = tile;
            tile.SetConnectedObject(this);
        }

        private void FindNeighbors(List<Wall> wallList)
        {
            Point Center = Collision.Center;

            Point testPointUp = new Point(Center.X, Center.Y - Collision.Height);
            Point testPointRight = new Point(Center.X + Collision.Width, Center.Y);
            Point testPointDown = new Point(Center.X, Center.Y + Collision.Height);
            Point testPointLeft = new Point(Center.X - Collision.Width, Center.Y);

            foreach (Wall w in wallList)
            {
                if (w.Collision.Contains(testPointUp))
                {
                    checkNeighbors[Direction.Up] = true;
                }
                else if (w.Collision.Contains(testPointRight))
                {
                    checkNeighbors[Direction.Right] = true;
                }
                else if (w.Collision.Contains(testPointDown))
                {
                    checkNeighbors[Direction.Down] = true;
                }
                else if (w.Collision.Contains(testPointLeft))
                {
                    checkNeighbors[Direction.Left] = true;
                }

            }






        }

        private int FindNoNeighborSide()
        {
            List<int> temp = new List<int>() { 1, 2, 3, 4 };
            foreach (int i in neighbors)
            {
                temp.Remove(i);
            }
            int last = temp[0];

            if (last == 4)
            {
                return 0;
            }
            else
            {
                return last;
            }




        }

        private void AdvancedLogic()
        {
            int count = neighbors.Count;

            if (count == 0)
            {
                sprite = sprites["Alone"];
            }

            else if (count == 1)
            {
                rotation = angle * (neighbors[0] - 1);
                sprite = sprites["1Con"];

            }


            else if (count == 2)
            {
                if (neighbors[0] + 1 == neighbors[1] || (neighbors[0] == 1 && neighbors[1] == 4))
                {
                    if (!(neighbors[1] == 4 && neighbors[0] == 1))
                    {
                        rotation = angle * (neighbors[0] - 1);
                    }
                    else
                    {
                        rotation = angle * 3;
                    }
                    sprite = sprites["2ConC"];

                }
                else
                {
                    if (neighbors[0] == 2)
                    {
                        rotation = angle;
                    }
                    sprite = sprites["2ConL"];
                }


            }

            else if (count == 3)
            {
                rotation = angle * FindNoNeighborSide();
                sprite = sprites["3Con"];
            }



            else if (count == 4)
                sprite = sprites["4Con"];
        }

        public void AdvancedSprites(List<Wall> wallList)
        {
            FindNeighbors(wallList);
            RelistNeighbors();
            AdvancedLogic();
        }


        private void RelistNeighbors()
        {
            neighbors = new List<int>();
            //int count = 0;


            for (int i = 1; i < 5; i++)
            {
                Direction dir = (Direction)Enum.Parse(typeof(Direction), Convert.ToString(i));
                if (checkNeighbors[dir] == true)
                {
                    neighbors.Add(i);
                }

            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //spriteBatch.DrawString(font, (neighbors.Count).ToString(), Position, textColor);
            //spriteBatch.DrawString(font, wallNum.ToString(), Position, textColor);
            //spriteBatch.DrawString(font, wallNum.ToString(), Collision.Center.ToVector2(), textColor);
            //spriteBatch.DrawString(font, basePosition, Position+new Vector2(0,font.LineSpacing), textColor);
        }

        public override void LoadContent(ContentManager content)
        {


        }

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(sprite, position, null, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 1);
        //}

        public override void OnCollision(GameObject other)
        {

        }

        public override void Update(GameTime gameTime)
        {


        }
    }
}
