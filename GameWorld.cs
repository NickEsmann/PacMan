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

        public static List<GameObject> GameObjects { get => gameObjects; private set => gameObjects = value; }

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
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

        private void DrawCollisionBox(GameObject go)
        {




        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            map.Draw(_spriteBatch);
            foreach (GameObject go in GameObjects)
            {
                go.Draw(_spriteBatch);
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
            levels = new List<Level>()
            {
                new Level()
            };
            
            
            


        }


    }
}
