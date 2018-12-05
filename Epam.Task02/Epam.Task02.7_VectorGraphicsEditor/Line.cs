using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._7_VectorGraphicsEditor
{
    class Line : Figure
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line() { }

        public Line(int x1, int y1, int x2, int y2)
        {
            StartPoint = new Point(x1, y1);
            EndPoint = new Point(x2, y2);
        }

        public override void Draw()
        {
            Console.WriteLine("Figure type - Line.");
            Console.WriteLine("Start point of the line : {0}.{1}", StartPoint.X, StartPoint.Y);
            Console.WriteLine("End point of the line : {0}.{1}", EndPoint.X, EndPoint.Y);
        }

    }
}
