using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.AnotherTriangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a positive integer number: ");
                bool check = int.TryParse(Console.ReadLine(), out int result);
                if (check)
                {
                    if (result > 0)
                    {
                        AnotherTriangle(result);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static void AnotherTriangle(int n)
        {
            const char Space = ' ';
            const char Asterisk = '*';

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (2 * n) + 1; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write((j < n - i) || (j > n + i) ? Space : Asterisk);
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
