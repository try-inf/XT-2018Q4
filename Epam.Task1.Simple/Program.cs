using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a positive number from 1 to ...N: ");
                string str = Console.ReadLine();
                bool check = int.TryParse(str, out int res);
                if (check)
                {
                    if (res >= 0)
                    {
                        if (Simple(res))
                        {
                            Console.WriteLine("{0} is a prime number", res);
                        }
                        else
                        {
                            Console.WriteLine("{0} is not a prime number", res);
                        }

                        break;
                    }
                    else
                    {
                        Console.WriteLine("You entered not positive number");
                    }
                }
                else
                {
                    Console.WriteLine("You entered not a number");
                }
            }

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static bool Simple(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
