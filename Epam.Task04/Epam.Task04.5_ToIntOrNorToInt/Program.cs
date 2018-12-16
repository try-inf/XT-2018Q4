using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._5_ToIntOrNorToInt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunDemo();

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static void RunDemo()
        {
            Console.WriteLine("***Demo of checking the string on being \"positive integer number\" by extension method***");

            Console.Write("Please enter your number: ");
            string input = Console.ReadLine();

            if (input.IsPositiveIntNumber())
            {
                Console.WriteLine("Yes, you entered a positive integer number.");
            }
            else
            {
                Console.WriteLine("May be you entered something really interesting, " +
                    "but it was not a positive integer number.");
            }
        }
    }
}
