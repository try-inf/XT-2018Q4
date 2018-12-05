using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Bear : Animal, IKindness, IReversable
    {
        public int Strength { get; set; }
        public double Degree { get; set; }
        public string Type { get; set; }

        public Bear() { }

        public Bear(string name, int velocity, int strength)
        {
            Name = name;
            Velocity = velocity;
            Strength = strength;
        }


        public override void Move() { }
        public override void Attack() { }
        public override void VelocityIncrease() { }
        public void Hibernation() { }
        public void MakeSurprize() { }
        public void ChangeSide() { }
    }
}
