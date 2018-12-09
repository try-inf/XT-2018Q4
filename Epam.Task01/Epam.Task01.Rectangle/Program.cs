using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.Rectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Calculating the area of rectangle with sides 'а' and 'b': ");
            int a = ReadSide("a");
            int b = ReadSide("b");
            Console.WriteLine("The square of a rectangle is {0}", SquareRect(a, b));

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static int ReadSide(string name)
        {
            while (true)
            {
                Console.Write("Enter the length of side '{0}' (positive integer number) = ", name);
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

        private static int SquareRect(int a, int b)
        {
            return a * b;
        }

        private static bool CheckNegativeOrZero(int n)
        {
            return n <= 0;
        }

        private static void WarningMessage()
            => Console.WriteLine("Warning! You are able to enter only positive values");
    }
}
