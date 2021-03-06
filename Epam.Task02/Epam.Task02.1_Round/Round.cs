﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._1_Round
{
    class Round
    {
        private int x;
        private int y;
        private int r;

        public int X
        {
            get { return x; }
            set
            {
                while (true)
                {
                    if (value < 1)
                    {
                        throw new ArgumentException("Warning! X shouldn't be less then 1.");
                    }
                    else 
                    {
                        x = value;
                        break;
                    }
                }
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                while (true)
                {
                    if (value < 1)
                    {
                        throw new ArgumentException("Warning! Y shouldn't be less then 1.");
                    }
                    else
                    {
                        y = value;
                        break;
                    }
                }
            }
        }

        public int R
        {
            get { return r; }
            set
            {
                if ((value > X)||(value > Y))
                {
                    r= (X < Y) ? X : Y;
                    Console.WriteLine("Warning! Radius can't be less" +
                        " then the distance along the x-axis or " +
                        "y-axis to the center of the circle. The value is " +
                        "set to {0} (the smallest axis)", r);
                    
                }
                else if (value < 0)
                {
                    r = 1;
                    Console.WriteLine("Radius can't be negative. The value is set to {0}",r);
                }
                else
                {
                    r = value;
                }
            }
        }


        public Round() { }

        public Round(int x, int y, int r)
        {
            X = x;
            Y = y;
            R = r;
        }

        public double GetCircumference()
        {
            double c = 2 * Math.PI * R; ;
            return c;
        }

        public double GetArea()
        {
            double s = Math.PI * R * R;
            return s;
        }
     }
}
