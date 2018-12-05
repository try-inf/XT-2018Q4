using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._7_VectorGraphicsEditor
{
    class Round : Circle
    {
        public Round() { }

        public Round(int x, int y, int r) : base(x, y, r) { }
        
        public virtual double GetArea()
        {
            double s = Math.PI * R * R;
            return s;
        }

        public override void Draw()
        {
            Console.WriteLine("Figure type - Round.");
            Console.WriteLine("Round's center coordinates: {0}.{1}", StartPoint.X, StartPoint.Y);
            Console.WriteLine("Radius: {0}.", R);
        }


    }
}
