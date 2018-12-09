using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    public class Program
    {
       public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a positive number from 1 to ...N: ");
                string str = Console.ReadLine();
                bool check = int.TryParse(str, out int res);
                if (check)
                {
                    Sequence(res);
                    break;
                }
                else
                {
                    Console.WriteLine("You entered not a number");
                }
            }

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        internal static void Sequence(int n)
        {
            for (int i = 1; i < n; i++)
            {
                Console.Write("{0}, ", i);
            }

            Console.Write(n);
        }
    }
}
