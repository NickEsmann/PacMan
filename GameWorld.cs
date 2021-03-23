using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace PacMan
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Map map;
        public static Level currentLevel;
        private List<Level> levels;

        private static List<GameObject> gameObjects;
        public static List<GameObject> deleteObjects;

        private Texture2D collisionTexture;
        private Color collisionBoxColor = Color.Red;


        public static List<GameObject> GameObjects { get => gameObjects; private set => gameObjects = value; }

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            GhostSpawn.StaticLoadContent(this.Content);
            Wall.LoadSprites(this.Content);
            Ghost.StaticLoadContent(this.Content);
            Tile.StaticLoadContent(this.Content);
            // TODO: Add your initialization logic here
            map = new Map();
            GameObjects = new List<GameObject>();

            GenerateLevels();
            currentLevel = levels[0];

            foreach (GameObject go in currentLevel.LevelObjects)
            {
                GameObjects.Add(go);
            }


            //GameObjects.Add(new Ghost("Blinky", 7, 8));
            //GameObjects.Add(new Ghost("Pinky", 8, 8));
            //GameObjects.Add(new Ghost("Inky", 10, 8));
            //GameObjects.Add(new Ghost("Clyde", 11, 8));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            collisionTexture = Content.Load<Texture2D>("CollisionTexture");

            foreach (GameObject go in GameObjects)
            {
                go.LoadContent(this.Content);
            }
            map.LoadContent(Content);

            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject go in GameObjects)
            {
                go.Update(gameTime);
                if (go is Ghost)
                {
                    if (go.NeedPath)
                    {
                        go.Path = map.FindPath(new Point(1, 1), new Point(go.X, go.Y));
                        go.NeedPath = false;
                    }
                }
            }

            base.Update(gameTime);
        }

        private void DrawCollisionBox(GameObject o)
        {
            Rectangle topLine = new Rectangle(o.Collision.X, o.Collision.Y, o.Collision.Width, 1);
            Rectangle bottomLine = new Rectangle(o.Collision.X, o.Collision.Y + o.Collision.Height, o.Collision.Width, 1);
            Rectangle rightLine = new Rectangle(o.Collision.X + o.Collision.Width, o.Collision.Y, 1, o.Collision.Height);
            Rectangle leftLine = new Rectangle(o.Collision.X, o.Collision.Y, 1, o.Collision.Height);

            _spriteBatch.Draw(collisionTexture, topLine, collisionBoxColor);
            _spriteBatch.Draw(collisionTexture, bottomLine, collisionBoxColor);
            _spriteBatch.Draw(collisionTexture, rightLine, collisionBoxColor);
            _spriteBatch.Draw(collisionTexture, leftLine, collisionBoxColor);



        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            map.Draw(_spriteBatch);
            foreach (GameObject go in GameObjects)
            {
                go.Draw(_spriteBatch);
#if DEBUG
                //DrawCollisionBox(go);
                /*
                foreach (GameObject item in map.Grid)
                {
                    DrawCollisionBox(item);
                }*/

#endif
            }

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void Destroy(GameObject go)
        {
            deleteObjects.Add(go);
        }

        private void GenerateLevels()
        {
            Level.CreateMazeArchive();
            levels = new List<Level>()
            {
                new Level(Level.MazeArchive["PacManLevel1from1x1"],7,8)

            };

        }


    }
}
