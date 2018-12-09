using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.NoPositive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,,] arr = new int[4, 2, 3]
                {
                { { 1, -2, 3 }, { -4, 5, 0 } },
                { { 7, 0, -9 }, { -10, -11, 12 } },
                { { 0, 14, -15 }, { 16, -5, -18 } },
                { { 19, 18, 21 }, { 22, -23, 15 } }
                };

            Console.WriteLine("Initial array: ");
            ShowArray(arr);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = (arr[i, j, k] > 0) ? 0 : arr[i, j, k];
                    }
                }
            }
            
            Console.WriteLine(Environment.NewLine + "Array after replacing positive elements with zero: ");
            ShowArray(arr);

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static void ShowArray(int[,,] nums)
        {
            foreach (var item in nums)
            {
                Console.Write("\t{0}", item);
            }

            Console.WriteLine();
        }
    }
}
