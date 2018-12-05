using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    abstract class Bonuses
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Usefullness { get; set; }

        public virtual void Place() { }
        
    }
}
