using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class GameField
    {
        public Point StartPoint { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public GameField() { }

        public GameField(int x, int y, int width, int height)
        {
            StartPoint = new Point(x, y);
            Width = width;
            Height = height;
        }

        public void ShowField()
        {
            Console.WriteLine("Game field:");
            Console.WriteLine("Left bottom corner coordinates: {0}.{1}", StartPoint.X, StartPoint.Y);
            Console.WriteLine("Right top corner coordinates: {0}.{1}", StartPoint.X + Width, StartPoint.Y + Height);
        }
    }
}
