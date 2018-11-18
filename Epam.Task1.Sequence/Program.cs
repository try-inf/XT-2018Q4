using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    class Program
    {

        static void Sequence(int N)
        {
            for (int i = 1; i < N; i++)
            {
                Console.Write("{0}, ", i );
            }
            Console.Write(N);
        }


        static void Main(string[] args)
        {
            Console.Write("Enter a positive number from 1 to ...N: ");
            string nStr = Console.ReadLine();
            bool check = int.TryParse(nStr, out int res);
            if (check)
            {
                Sequence(res);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You entered not a number");
                Console.ReadLine();
            }

        }
    }
}
