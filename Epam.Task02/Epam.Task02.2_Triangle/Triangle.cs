using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._2_Triangle
{
    class Triangle
    {
        private int a;
        private int b;
        private int c;

        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public int C
        {
            get { return c; }
            set { c = value; }
        }

        public Triangle() { }

        
        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double GetPerimeter()
        {
            double P = A + B + C;
            return P;
        }

        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            double s = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            return s;
        }



    }
}
