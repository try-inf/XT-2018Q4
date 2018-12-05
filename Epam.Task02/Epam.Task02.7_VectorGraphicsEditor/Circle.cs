using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._7_VectorGraphicsEditor
{
    class Circle : Figure
    {
        public Point StartPoint { get; set; }
        
        private int r;

        public int R
        {
            get { return r; }
            set
            {
                if ((value > StartPoint.X) || (value > StartPoint.Y))
                {
                    r = (StartPoint.X < StartPoint.Y) ? StartPoint.X : StartPoint.Y;
                    Console.WriteLine("Warning! Radius can't be less" +
                        " then the distance along the x-axis or " +
                        "y-axis to the center of the circle. The value is " +
                        "set to {0} (the smallest axis)", r);

                }
                else if (value < 0)
                {
                    r = 1;
                    Console.WriteLine("Radius can't be negative. The value is set to {0}", r);
                }
                else
                {
                    r = value;
                }
            }
        }

        public Circle() { }

        public Circle(int x, int y, int r)
        {
            StartPoint = new Point(x, y);
            R = r;
        }

        public virtual double GetLength()
        {
            double l = 2 * Math.PI * R; ;
            return l;
        }

        public override void Draw()
        {
            Console.WriteLine("Figure type - Circle.");
            Console.WriteLine("Circle's center coordinates: {0}.{1}", StartPoint.X, StartPoint.Y);
            Console.WriteLine("Radius: {0}.", R);
        }

    }
}
