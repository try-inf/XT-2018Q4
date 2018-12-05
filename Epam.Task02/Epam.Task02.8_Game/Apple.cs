using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Apple : Bonuses
    {
        public int Size { get; set; }
        public Apple() { }

        public Apple(string name, string type, int usefullness, int size)
        {
            Name = name;
            Type = type;
            Usefullness = usefullness;
            Size = size;
        }

        public override void Place() { }

    }
}
