using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._4_NumberArraySum
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
            Random r = new Random();
            int[] arr = new int[20];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1, 99);
            }

            Console.WriteLine("***Demo of array items counting by extension method***");

            ShowArray(arr, "Yor random int array: ");
            Console.WriteLine();

            Console.Write("The sum of all items of your array: {0}.", arr.MySumm());
        }

        private static void ShowArray(int[] items, string promt = "")
        {
            Console.WriteLine(promt);
            foreach (var item in items)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }
    }
}
