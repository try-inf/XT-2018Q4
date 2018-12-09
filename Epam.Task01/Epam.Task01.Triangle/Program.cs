using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int h = ReadNum("Enter a positive integer number: ");
            Triangle(h);

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

        private static void Triangle(int n)
        {
            const char Space = ' ';
            const char Asterisk = '*';

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(i < j ? Space : Asterisk);
                }

                Console.WriteLine();
            }
        }
    }
}
