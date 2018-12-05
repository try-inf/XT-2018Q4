using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._7_VectorGraphicsEditor
{
    sealed class Point
    {
        private int x;
        private int y;

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

        public Point() { }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
