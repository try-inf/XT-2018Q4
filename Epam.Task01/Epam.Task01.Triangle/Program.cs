using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.Triangle
{
    class Program
    {
        static void Triangle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n ; j++)
                {
                    Console.Write(i < j ? " ":"*");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Init:
            Console.Write("Enter a positive integer number: ");
            bool check = int.TryParse(Console.ReadLine(), out int result);
            if (check)
            {
                if (result > 0)       //check for positive value of typed number
                {
                    Triangle(result);
                    Console.WriteLine(Environment.NewLine + "Press any key to exit.");
                    Console.ReadKey();
                }
                else goto Init;
            }
            else
            {
                Console.WriteLine("Wrong input");
                goto Init;
            }
        }
    }
}
