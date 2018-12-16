using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._2_CustomSortDemo
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

            string[] strarr = new string[] { "one", "two", "three", "four", "five" };

            Console.Write("Initial int array: ");
            ShowArray(arr);

            Console.Write("Sorted int array: ");
            ShowArray(arr.CustomSort(IntCompare, null));
            
            Console.Write("Initial string array: ");
            ShowArray(strarr);

            Console.Write("Sorted string array: ");
            ShowArray(strarr.CustomSort(StringCompare, StringAlphabetCompare));
            
            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static void ShowArray<T>(T[] items)
        {
            foreach (var item in items)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
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

        private static int StringCompare(string str1, string str2)
        {
            if (str1.Length < str2.Length)
            {
                return 1;
            }
            else if (str1.Length > str2.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static int StringAlphabetCompare(string str1, string str2)
        {
            var len = str1.Length > str2.Length ? str2.Length : str1.Length;
            for (int i = 0; i < len; i++)
            {
                if (str1.ToCharArray()[i] < str2.ToCharArray()[i])
                {
                    return 1;
                }

                if (str1.ToCharArray()[i] > str2.ToCharArray()[i])
                {
                    return -1;
                }
            }

            return 1;
        }
    }
}
