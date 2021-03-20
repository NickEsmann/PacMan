using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

using System.Text;

namespace LevelCreator
{
    public class MyMouse
    {

        public MouseState mouseState;
        public MouseState oldState;
        public Vector2 mousePosition;


        public MyMouse()
        {
            mouseState = Mouse.GetState();
            oldState = mouseState;
            mousePosition = new Vector2(mouseState.X, mouseState.Y);

        }

        public void Update()
        {
            oldState = mouseState;
            mouseState = Mouse.GetState();
            mousePosition = new Vector2(mouseState.X, mouseState.Y);

        }



    }
}
