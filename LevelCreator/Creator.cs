using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LevelCreator
{
    public class Creator : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private static int gridSize=16;

        private static List<Button> buttons;

        private int gridX = 19;
        private int gridY = 19;

        public static int GridSize { get => gridSize; private set => gridSize = value; }
        internal static List<Button> Buttons { get => buttons; private set => buttons = value; }

        public MyMouse myMouse;

        public Creator()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferWidth = gridX * (GridSize + 1);
            _graphics.PreferredBackBufferHeight = (gridY+1) * (GridSize + 1);
            _graphics.ApplyChanges();

            myMouse = new MyMouse();

            Button.LoadContent(Content);
            Buttons = new List<Button>();
            for(int x=0; x<gridX; x++)
            {
                for(int y=0; y<gridY;y++)
                {
                    Buttons.Add(new Button(x, y));
                }
            }
            Buttons.Add(new Button("Print", 0, gridY, gridX * (gridSize + 1)));
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            myMouse.Update();
            foreach(Button b in Buttons)
            {
                b.Update(myMouse);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            foreach(Button b in Buttons)
            {
                b.Draw(_spriteBatch);
            }

            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
