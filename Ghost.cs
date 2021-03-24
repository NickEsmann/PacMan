using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacMan
{
    class Ghost : GameObject
    {
        private static Dictionary<string, Texture2D> ghostSprites;

        private GhostSpawn spawn;

        private string name;
        private Tile currentTile;
        private Color ghostColor;

        private Vector2 spawnPos;

        private Vector2 basePos
        {
            get
            {
                return new Vector2(Position.X / (float) Map.GridSize, (float)(Position.Y / Map.GridSize));
            }
}

private Tile targetTile;

        private Thread AStar;

        private bool isInSpawn
        {
            get
            {
                if (spawn.Collision.Contains(Position))
                    return true;
                else
                    return false;
            }
        }
        private float respawnTimer;


        public Ghost(string name, int x, int y,GhostSpawn spawn)
        {
            this.name = name;
            this.spawn = spawn;
            sprite = ghostSprites[name];
            color = Color.White;
            ghostColor = AssignColor();
            //basePos = new Point(x, y);
            spawnPos = new Vector2(x, y);
            Position = new Vector2(x * Map.GridSize, y * Map.GridSize);

            respawnTimer = 0;

            AStar = new Thread(Pathfinding);



            FindCurrentTile();
            //UpdateTarget();

        }

        public override void Update(GameTime gameTime)
        {
            FindCurrentTile();


            if (isInSpawn)
            {
                //color = Color.Black;//For Testing 
                if (respawnTimer<=0)
                {
                    //GoOutOfSpawn();
                }
            }
            else
            {
                //color = Color.White;


            }

        }
        private Color AssignColor()
        {
            switch(name)
            {
                case "Blinky":
                    return Color.Red;
                case "Pinky":
                    return Color.Pink;
                case "Inky":
                    return Color.Turquoise;
                case "Clyde":
                    return Color.Orange;
                default:
                    return Color.White;

            }
        }

        private void FindCurrentTile()
        {
            AssignTile(GameWorld.map.GridDictionary[basePos]);




            //foreach (Tile t in GameWorld.map.Grid)
            //{
            //    if (t.Collision.Contains(Position))
            //    {
            //        AssignTile(t);
            //        break;
            //    }
            //}
        }     
        private void AssignTile(Tile t)
        {
            if (currentTile != null)
            {
                if (currentTile != t)
                {
                    currentTile.ChangeColor(Color.Black);
                    currentTile = t;
                    t.ChangeColor(ghostColor);
                }
            }
            else
            {
                currentTile = t;
                t.ChangeColor(ghostColor);
            }

            

        }

        private void UpdateTarget()
        {
            targetTile = GameWorld.map.GridDictionary[spawnPos+new Vector2(0,9)];
            targetTile.ChangeColor(ghostColor);
        }

        /// <summary>
        /// For getting out of spawn So we can make spawn unwalkable
        /// </summary>
        private void GoOutOfSpawn()
        {
            //Temp Code
            Position = new Vector2((spawn.X + 2) * Map.GridSize, (spawn.Y - 1) * Map.GridSize);


        }


        private void Pathfinding()
        {



        }

        public static void StaticLoadContent(ContentManager content)
        {
            ghostSprites = new Dictionary<string, Texture2D>();
            string name;

            { name = "Blinky"; ghostSprites.Add(name, content.Load<Texture2D>("Entity/Ghosts/" + name)); }
            { name = "Pinky"; ghostSprites.Add(name, content.Load<Texture2D>("Entity/Ghosts/" + name)); }
            { name = "Inky"; ghostSprites.Add(name, content.Load<Texture2D>("Entity/Ghosts/" + name)); }
            { name = "Clyde"; ghostSprites.Add(name, content.Load<Texture2D>("Entity/Ghosts/" + name)); }

        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }

        
    }
}
