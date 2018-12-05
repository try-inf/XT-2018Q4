using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Tree : Obstacle
    {
        public Tree() { }

        public Tree(string name, string type, int size)
        {
            Name = name;
            Type = type;
            Size = size;
        }

        public override void Place() { }
    }
}
