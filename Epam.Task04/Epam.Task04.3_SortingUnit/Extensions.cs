using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task04._3_SortingUnit
{
    public static class Extensions
    {
        public static T[] CustomSort<T>(this T[] array, Func<T, T, int> comp, string thread)
        {
            T temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comp(array[i], array[j]) < 0)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }

                    Console.WriteLine("Sorting operation {0} in {1}", i, thread);
                }
            }

            return array;
        }
    }
}
