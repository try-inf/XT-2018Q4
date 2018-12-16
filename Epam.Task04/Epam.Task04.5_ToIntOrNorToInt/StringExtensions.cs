using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._5_ToIntOrNorToInt
{
    public static class StringExtensions
    {
        public static bool IsPositiveIntNumber(this string str)
        {
            var char_str = str.ToCharArray();
            for (int i = 0; i < char_str.Length; i++)
            {
                if (char_str[0] == '-')
                {
                    return false;
                }

                if (!char.IsDigit(char_str[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
