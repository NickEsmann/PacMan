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
        private Map map;

        private static List<GameObject> gameObjects;
        public static List<GameObject> deleteObjects;
      
       

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
            // TODO: Add your initialization logic here
            map = new Map();
            //worker = new Worker(1);
           
            gameObjects = new List<GameObject>();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            foreach (GameObject go in gameObjects)
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

            foreach (var item in gameObjects)
            {
                item.CheckCollision(item);
                foreach (var go in deleteObjects)
                {
                    gameObjects.Remove(go);
                }
            }
           

            ////Listen rydes.
            //deleteObjects.Clear();

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
            foreach (GameObject go in gameObjects)
            {
                go.Draw(_spriteBatch);
                DrawCollisionBox(go);
            }

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void Destroy(GameObject go)
        {
            deleteObjects.Add(go);
        }

    }
}
