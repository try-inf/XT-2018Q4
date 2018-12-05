using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Wolf : Animal, IBadness
    {
        public bool Leader { get; set; }
        public double Degree { get; set; }

        public Wolf() { }

        public Wolf(string name, int velocity, bool leader)
        {
            Name = name;
            Velocity = velocity;
            Leader = leader;
        }


        public override void Move() { }
        public override void Attack() { }
        public override void VelocityIncrease() { }
        public void MakePursuit() { }

    }
}
