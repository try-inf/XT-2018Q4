﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    sealed class Point
    {
        public int X{ get; set; }
        public int Y{ get; set; }

        public Point() { }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
