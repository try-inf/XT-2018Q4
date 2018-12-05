using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Fox : Animal, IBadness
    {
        public int Slyness { get; set; }
        public double Degree { get; set; }

        public Fox() { }

        public Fox(string name, int velocity, int slyness)
        {
            Name = name;
            Velocity = velocity;
            Slyness = slyness;
        }


        public override void Move() { }
        public override void Attack() { }
        public override void VelocityIncrease() { }
        public void Cheating() { }
        public void MakePursuit() { }
    }
}
