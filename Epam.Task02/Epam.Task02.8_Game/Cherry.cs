using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Cherry : Bonuses
    {
        public Cherry() { }

        public Cherry(string name, string type, int usefullness)
        {
            Name = name;
            Type = type;
            Usefullness = usefullness;
        }

        public override void Place() { }

    }
}
