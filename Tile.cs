using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    class Tile : GameObject
    {
        private int x;
        private int y;
        private GameObject connectedObject;

        private static Texture2D tileSprite;
        public bool isWalkable
        {
            get
            {
                if(connectedObject!=null)
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
            Position = new Vector2((x * tileSize)-1, (y * tileSize)-1);
            color = Color.Black;
            sprite = tileSprite;
            //scale = new Vector2(1, 1);
            //scale = new Vector2(0.5f, 0.5f);
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

    }
}
