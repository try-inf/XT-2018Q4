using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Epam.Task02._6_Ring
{
    class Ring : Round
    {
        private int innerR;

        public int InnerR
        {
            get { return innerR; }
            set
            {
                if ((value > X) || (value > Y))
                {
                    innerR = (X < Y) ? X : Y;
                    Console.WriteLine("Warning! Radius can't be less" +
                        " then the distance along the x-axis or " +
                        "y-axis to the center of the circle. The value is " +
                        "set to {0} (the smallest axis)", innerR);

                }
                else if (value < 0)
                {
                    innerR = 1;
                    Console.WriteLine("Radius can't be negative. The value is set to {0}", innerR);
                }
                else if (innerR > R)
                {

                }
                else
                {
                    innerR = value;
                }
            }

        }

        public override double GetArea()
        {
            double s = Math.PI * (R * R - InnerR * InnerR);
            return s;
        }

        public override double GetLength()
        {
            return base.GetLength() + 2 * Math.PI * InnerR;
        }

    }
}
