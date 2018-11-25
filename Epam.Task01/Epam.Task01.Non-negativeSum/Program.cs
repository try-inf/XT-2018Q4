using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.Non_negativeSum
{
    class Program
    {
    
        static void Main(string[] args)
        {
            int[] arr = new int[] { 23, 34, -5, 6, -8, 0, -23, 56, 89 };
            Console.WriteLine("Initial array: ");
            foreach (var item in arr)
            {
                Console.Write("\t{0}", item);
            }

            Console.WriteLine(Environment.NewLine + "The sum of all non-negative elements: {0}", Array.FindAll(arr, x => x >= 0).Sum());

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();

        }
    }
}
