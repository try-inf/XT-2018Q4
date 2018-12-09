using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a positive odd number: ");
                try
                {
                    int res = int.Parse(Console.ReadLine());
                    if (res >= 0)
                    {
                        if (res % 2 == 0)
                        {
                            Console.WriteLine("You entered an even number instead of an odd one");
                        }
                        else
                        {
                            Square(res);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered not positive number");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered not a number");
                }
            }

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static void Square(int n)
        {
            const char Space = ' ';
            const char Asterisk = '*';

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == n / 2 && j == n / 2)
                    {
                        Console.Write(Space);
                    }
                    else
                    {
                        Console.Write(Asterisk);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
