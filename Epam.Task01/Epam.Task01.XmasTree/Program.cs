using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.XmasTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int h = ReadNum("Enter a positive integer number: ");
            XmasTree(h);

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static int ReadNum(string name)
        {
            while (true)
            {
                Console.Write("{0}", name);
                string str = Console.ReadLine();
                bool check = int.TryParse(str, out int result);
                if (check)
                {
                    if (CheckNegativeOrZero(result))
                    {
                        WarningMessage();
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }

        private static bool CheckNegativeOrZero(int n)
        {
            return n <= 0;
        }

        private static void WarningMessage()
            => Console.WriteLine("Warning! You are able to enter only positive values");

        private static void XmasTree(int n)
        {
            const char Space = ' ';
            const char Asterisk = '*';

            for (int m = 1; m <= n; m++)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < (2 * m) + 1 + n; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write((j < n - i) || (j > n + i) ? Space : Asterisk);
                    }

                    Console.WriteLine();
                }
            }

            Console.ResetColor();
        }
    }
}
