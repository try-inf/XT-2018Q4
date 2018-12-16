using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._2_CustomSortDemo
{
    public static class Extensions
    {
        public static T[] CustomSort<T>(this T[] array, Func<T, T, int> comp, Func<T, T, int> comp1)
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

                    if (comp1 != null)
                    {
                        if ((comp(array[i], array[j]) == 0) && (comp1(array[i], array[j]) < 0))
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            return array;
        }
    }
}
