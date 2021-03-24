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

        public PointSystem pointsystem;



        private static List<GameObject> gameObjects;
        public static List<GameObject> deleteObjects;

        private Texture2D collisionTexture;
        private Color collisionBoxColor=Color.Transparent;


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
            Wall.LoadSprites(this.Content);
            // TODO: Add your initialization logic here
            map = new Map();
            GameObjects = new List<GameObject>();

            GenerateLevels();
            currentLevel = levels[0];

            foreach(Wall w in currentLevel.Walls)
            {
                GameObjects.Add(w);
            }




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
                DrawCollisionBox(go);
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
            Level.CreateLevelArchive();
            levels = new List<Level>()
            {
                new Level(new List<Wall>()
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
                })
                
            };
            
            
            


        }


    }
}
