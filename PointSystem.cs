using System;
using System.Collections.Generic;
using System.Text;

namespace PacMan
{
    public class PointSystem
    {
        private int points_;

        public int Points
        { 
            get { return points_; }
            private set
            {
                if (value < 0)
                {
                    points_ = 0;
                }
                else
                {
                    points_ = value;
                }

            }

        }

        public void IncreasePoints(int num)
        {
            Points += num;
        }

    }
}
