using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.CharDoubler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first string: ");
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Please enter the second string: ");
            string str = Console.ReadLine();
            char[] strToChar = str.ToCharArray();

            for (int i = 0; i < strToChar.Length; i++)
            {
                sb.Replace(strToChar[i].ToString(), strToChar[i].ToString() + strToChar[i].ToString());
            }

            Console.WriteLine("The result string: {0}", sb.ToString());

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }
    }
}
