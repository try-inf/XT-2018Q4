using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._7_VectorGraphicsEditor
{
    class Rectangle : Figure
    {
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle() { }
        
        public Rectangle(int x, int y, int width, int height)
        {
            StartPoint = new Point(x, y);
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine("Figure type - Rectangle.");
            Console.WriteLine("Left bottom corner coordinates: {0}.{1}", StartPoint.X, StartPoint.Y);
            Console.WriteLine("Width: {0}. Height: {1}", Width, Height);
        }
    }
}
