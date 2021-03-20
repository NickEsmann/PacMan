using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace LevelCreator
{
    class Button
    {
        private int X;
        private int Y;

        private Rectangle Collision;

        //private bool Active=true;

        private static Texture2D inactiveSprite;
        private static Texture2D activeSprite;


        private bool isActive;
        private Thread CheckMouseThread;

        private string buttonText;

        public delegate void OnButtonPress(Button button);

        private OnButtonPress Command = (Button button) => { };


        private static SpriteFont font;
        


        public Texture2D sprite
        {
            get
            {
                if (isActive)
                {
                    return activeSprite;
                }
                else
                    return inactiveSprite;
            }
        }


        private void BaseButton()
        {
            isActive = false;

            
            //CheckMouseThread = new Thread(CheckMouse);
            //CheckMouseThread.IsBackground = true;
            //CheckMouseThread.Start();
        }

        public Button(int x, int y)
        {
            X = x;
            Y = y;
            buttonText ="";
            Collision = new Rectangle(
                X * (Creator.GridSize + 1),
                Y * (Creator.GridSize + 1),
                Creator.GridSize,
                Creator.GridSize);
            Command = GridCommand;
            BaseButton();

        }
        public Button(string text,int x, int y,int width)
        {
            X = x;
            Y = y;
            Collision = new Rectangle(
                X * (Creator.GridSize),
                Y * (Creator.GridSize + 1),
                width,
                Creator.GridSize);
            buttonText = text;
            Command = PrintCommand;
            BaseButton();


        }

        public static void LoadContent(ContentManager content)
        {
            inactiveSprite = content.Load<Texture2D>("MGreen");
            activeSprite = content.Load<Texture2D>("Alone");
            font = content.Load<SpriteFont>("font");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Collision, Color.White);
            spriteBatch.DrawString(font, buttonText, new Vector2(Collision.X+((Collision.Width / 2) - (font.MeasureString(buttonText).X / 2)),Collision.Y +((Collision.Height / 2) - (font.MeasureString(buttonText).Y / 2))),Color.Black);
        }
        public void Update(MyMouse mouse)
        {
            UpdateMouseCheck(mouse);

        }
        private void UpdateMouseCheck(MyMouse mouse)
        {
            if (Collision.Contains(mouse.mousePosition))
            {
                //Debug.WriteLine($"{X},{Y}");

                if (mouse.mouseState.LeftButton == ButtonState.Pressed && mouse.oldState.LeftButton == ButtonState.Released) // this makes sure that it wil only react once pr. click.
                {
                    Debug.WriteLine("Click");
                    Command(this);
                }
            }
        }

        private OnButtonPress GridCommand=(Button button) =>
        {
            if(button.isActive)
            {
                button.isActive = false;
            }
            else
            {
                button.isActive = true;
            }
        };

        private OnButtonPress PrintCommand = (Button button) =>
          {
              string bstring = "new Wall(";

              bool first = true;
              Debug.WriteLine("");


              foreach(Button b in Creator.Buttons)
              {
                  if (b.isActive)
                  {
                      if (first)
                      {
                          first = false;
                      }
                      else
                      {
                          Debug.WriteLine(",");
                      }
                      Debug.Write(bstring + $"{b.X},{b.Y}" + ")");
                  }

              }



          };

        private void CheckMouse()
        {
            MouseState mouseState = Mouse.GetState();
            MouseState oldState;
            Vector2 mousePosition;

            Thread.Sleep(1000); // Thís is here to allow everything else to startup first.
            while (true)
            {
                
                oldState = mouseState;
                mouseState = Mouse.GetState();
                mousePosition = new Vector2(mouseState.X, mouseState.Y);

                if (Collision.Contains(mousePosition))
                {
                    //Debug.WriteLine($"{X},{Y}");

                    if (mouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released) // this makes sure that it wil only react once pr. click.
                    {
                        Debug.WriteLine("Click");
                        Command(this);
                    }
                }
            }
           

        }

    }
}
