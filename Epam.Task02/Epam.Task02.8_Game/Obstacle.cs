using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    abstract class Obstacle
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }

        public virtual void Place() { }
    }
}
