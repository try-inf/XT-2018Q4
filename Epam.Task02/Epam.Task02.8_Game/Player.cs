using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._8_Game
{
    class Player
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Age { get; set; }
        public int Health { get; set; }
        public string Scills { get; set; }

        public Player() { }

        public Player(string name, int score, int age, string scills)
        {
            PlayerName = name;
            Score = score;
            Age = age;
            Scills = scills;
        }

        public void MoveLeft() { }
        public void MoveRight() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void Pick() { }
        public void AskForHelp() { }

    }
}
