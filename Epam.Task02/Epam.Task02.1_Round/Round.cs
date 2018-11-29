using System;
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
                if (value < 2)
                {
                    Console.WriteLine("Warning! X shouldn't be less then 1. The value is set to 1");
                    x = 1;
                }
                else
                {
                    x = value;
                }
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Warning! Y shouldn't be less then 1. The value is set to 1");
                    y = 1;
                }
                else
                {
                    y = value;
                }
            }
        }

        public int R
        {
            get { return r; }
            set
            {
                if ((value > x)||(value > y))
                {
                    r= (x < y) ? x : y;
                    Console.WriteLine("Warning! Radius can't be less" +
                        " then the distance along the x-axis or " +
                        "y-axis to the center of the circle. The value is " +
                        "set to {0} (the smallest axis)", r);
                    
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
            return 2 * Math.PI * R;
        }

        public double GetArea()
        {
            return Math.PI * R * R;
        }
     }
}
