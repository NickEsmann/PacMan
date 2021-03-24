using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    public class Tile : GameObject
    {

        private GameObject connectedObject;
        public Tile Parent { get; private set; }

        private static Texture2D tileSprite;
        public bool isWalkable
        {
            get
            {
                if (connectedObject != null)
                {
                    if (connectedObject is Wall)
                        return false;
                    else
                        return true;

                }
                else
                {
                    return true;
                }
            }
        }




        public Tile(int x, int y, int tileSize)
        {
            this.X = x;
            this.Y = y;
            Position = new Vector2((this.X * tileSize) - 1, (this.Y * tileSize) - 1);
            color = Color.Black;
            sprite = tileSprite;


            //scale = new Vector2(1, 1);
            //scale = new Vector2(0.5f, 0.5f);

        }
        /// <summary>
        /// Calculation of F value for Astar
        /// </summary>
        public int F
        {
            get
            {
                return G + H;
            }
        }
        public int G { get; set; }
        public int H { get; set; }

        public int Distance(Tile point)
        {
            return (int)Math.Sqrt(Math.Pow((point.X - X), 2) + Math.Pow((point.Y - Y), 2));
        }
        public static void StaticLoadContent(ContentManager content)
        {
            tileSprite = content.Load<Texture2D>("Map/BlankTile");
        }

        public override void LoadContent(ContentManager content)
        {
            //sprite = content.Load<Texture2D>("Map/MGreen");//

        }

        public void ChangeColor(Color color)
        {
            base.color = color;
        }

        public override void OnCollision(GameObject other)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }


        public void SetConnectedObject(GameObject go)
        {
            connectedObject = go;
        }
        public Tile SetColor(Color color)
        {
            this.color = color;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public Tile SetParent(Tile parent)
        {
            Parent = parent;
            return this;
        }
    }
}
