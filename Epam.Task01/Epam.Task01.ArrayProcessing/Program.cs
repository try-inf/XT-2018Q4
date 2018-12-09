using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.ArrayProcessing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[5];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(3, 8);
            }

            Console.Write("Initial array: ");
            ShowArray(arr);
            Console.WriteLine("Min value: {0}", Min(arr));
            Console.WriteLine("Max value: {0}", Max(arr));
            Console.Write("Sorted array: ");
            ShowArray(ArraySort(arr));

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static int Max(int[] nums)
        {
            int max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
            }

            return max;
        }

        private static int Min(int[] nums)
        {
            int min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                }
            }

            return min;
        }

        private static int[] ArraySort(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

            return nums;
        }

        private static void ShowArray(int[] nums)
        {
            foreach (var item in nums)
            {
                Console.Write("{0}", item);
            }

            Console.WriteLine();
        }
    }
}
