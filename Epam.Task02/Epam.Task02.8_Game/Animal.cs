using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    abstract class Animal
    {
        public string Name { get; set; }
        public int Velocity { get; set; }

        public virtual void Move() { }
        public virtual void Attack() { }
        public virtual void VelocityIncrease() { }

    }
}
