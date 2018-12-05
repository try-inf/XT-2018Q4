using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Eagle : Animal, IKindness, IReversable, IFlyable
    {
        public int Age { get; set; }
        public double Degree { get; set; }
        public string Type { get; set; }
        public string Direction { get; set; }

        public Eagle() { }

        public Eagle(string name, int velocity, int age)
        {
            Name = name;
            Velocity = velocity;
            Age = age;
        }

        public override void Move() { }
        public override void Attack() { }
        public override void VelocityIncrease() { }
        public void Exploring() { }
        public void MakeSurprize() { }
        public void ChangeSide() { }
        public void Fly() { }
    }
}
