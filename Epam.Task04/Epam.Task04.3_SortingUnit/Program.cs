using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task04._3_SortingUnit
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
            int[] arr1 = new int[20];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = r.Next(1, 99);
            }

            int[] arr2 = new int[20];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = r.Next(1, 99);
            }

            Console.WriteLine("***Demo of array sorting in 2 independent threads***");

            ShowArray(arr1, "First array: ");
            Console.WriteLine();
            ShowArray(arr2, "Second array: ");
            Console.WriteLine();
            Console.WriteLine("Press any button to start sorting this two arrays in 2 independent " +
                "threads (Each thread will indicate its activity in every new text line): ");

            ThreadStart ts1 = new ThreadStart(() => TestThread(arr1, "Thread 1", "Sorted first array: "));
            Thread th1 = new Thread(ts1);

            ThreadStart ts2 = new ThreadStart(() => TestThread(arr2, "Thread 2", "Sorted second array: "));
            Thread th2 = new Thread(ts2);

            Console.ReadKey();

            th1.Start();
            th2.Start();

            Console.ReadKey();
        }

        private static int IntCompare(int i1, int i2)
        {
            if (i1 < i2)
            {
                return 1;
            }
            else if (i1 > i2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static void ShowArray<T>(T[] items, string promt = "")
        {
            Console.WriteLine(promt);
            foreach (var item in items)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        private static void TestThread(int[] arr, string thread_name, string promt)
        {
            ShowArray(arr.CustomSort(IntCompare, thread_name), promt);
        }
    }
}
