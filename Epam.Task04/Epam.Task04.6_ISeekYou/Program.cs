using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._6_ISeekYou
{
    public class Program
    {
        private Predicate<int> positiveIntAnonymousExp = delegate(int x) { return x >= 0; };

        private Predicate<int> positiveIntLambda = (x) => x >= 0;

        private delegate bool Function_2method(int x);

        public static void Main(string[] args)
        {
            Random r = new Random();
            int[] arr = new int[500];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-50, 50);
            }

            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            Stopwatch sw4 = new Stopwatch();
            Stopwatch sw5 = new Stopwatch();

            sw1.Start();
            RunDemo1(arr);
            sw1.Stop();
            Console.WriteLine();
            sw2.Start();
            RunDemo2(arr);
            sw2.Stop();
            Console.WriteLine();
            sw3.Start();
            RunDemo3(arr);
            sw3.Stop();
            Console.WriteLine();
            sw4.Start();
            RunDemo4(arr);
            sw4.Stop();
            Console.WriteLine();
            sw5.Start();
            RunDemo5(arr);
            sw5.Stop();
            Console.WriteLine();

            Console.WriteLine("Performance indicators of methods:");
            Console.WriteLine();
            Console.WriteLine("Method 1: {0}", sw1.ElapsedMilliseconds);
            Console.WriteLine("Method 2: {0}", sw2.ElapsedMilliseconds);
            Console.WriteLine("Method 3: {0}", sw3.ElapsedMilliseconds);
            Console.WriteLine("Method 4: {0}", sw4.ElapsedMilliseconds);
            Console.WriteLine("Method 5: {0}", sw5.ElapsedMilliseconds);

            long[] sw_array = new long[] 
            {
                sw1.ElapsedMilliseconds,
                sw2.ElapsedMilliseconds,
                sw3.ElapsedMilliseconds,
                sw4.ElapsedMilliseconds,
                sw5.ElapsedMilliseconds
            };
            int indexofbestresult = Array.IndexOf(sw_array, sw_array.Min()) + 1;

            Console.WriteLine("The best result - method {0}", indexofbestresult);

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static void RunDemo1(int[] array)
        {
            Console.WriteLine("***Demo of the first method (finding all positive elements of array) ***");

            ShowArray(array, "Your random int array: ");
            Console.WriteLine();

            int[] result = FindAllPositive(array);
            ShowArray(result, "All positive numbers of the above array :");
        }

        private static void RunDemo2(int[] array)
        {
            Function_2method func = new Function_2method(IsPositive);

            Console.WriteLine("***Demo of the second method (finding all positive (Condition gets by delegate instance.) elements of array). ***");

            ShowArray(array, "Your random int array: ");
            Console.WriteLine();

            int[] result = FindSmthInIntArray1(array, func);
            ShowArray(result, "All positive numbers of the above array :");
        }

        private static void RunDemo3(int[] array)
        {
            Program p = new Program();

            Console.WriteLine("***Demo of the third method (finding all positive (Condition gets by delegate as an anonymous function) elements of array) ***");

            ShowArray(array, "Your random int array: ");
            Console.WriteLine();

            int[] result = FindSmthInIntArray2(array, p.positiveIntAnonymousExp);
            ShowArray(result, "All positive numbers of the above array :");
        }

        private static void RunDemo4(int[] array)
        {
            Program p = new Program();

            Console.WriteLine("***Demo of the fourth method (finding all positive (Condition gets by delegate as a lambda expression) elements of array) ***");

            ShowArray(array, "Your random int array: ");
            Console.WriteLine();

            int[] result = FindSmthInIntArray2(array, p.positiveIntLambda);
            ShowArray(result, "All positive numbers of the above array :");
        }

        private static void RunDemo5(int[] array)
        {
            Console.WriteLine("***Demo of the fifth method (finding all positive (using LINQ) elements of array) ***");

            ShowArray(array, "Your random int array: ");
            Console.WriteLine();

            int[] result = Array.FindAll(array, x => x >= 0);
            ShowArray(result, "All positive numbers of the above array :");
        }

        private static int[] FindAllPositive(int[] array)
        {
            List<int> result = new List<int> { };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }

        private static int[] FindSmthInIntArray1(int[] array, Function_2method predicate)
        {
            List<int> result = new List<int> { };
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }

        private static int[] FindSmthInIntArray2(int[] array, Predicate<int> predicate)
        {
            List<int> result = new List<int> { };
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }

        private static bool IsPositive(int value)
        {
            if (value >= 0)
            {
                return true;
            }

            return false;
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
