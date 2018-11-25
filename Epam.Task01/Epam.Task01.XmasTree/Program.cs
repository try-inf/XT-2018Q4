using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.XmasTree
{
    class Program
    {
        static void XmasTree(int n)
        {
            for (int m = 1; m <= n; m++)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < 2 * m + 1 + n; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write((j < n - i) || (j > n + i) ? " " : "*");
                    }
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Init:
            Console.Write("Enter a positive integer number: ");
            bool check = int.TryParse(Console.ReadLine(), out int result);
            if (check)
            {
                if (result > 0)   //check for positive value of typed number
                {
                    XmasTree(result);
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
