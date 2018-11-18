using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    class Program
    {

        static bool Simple(int N)
        {
            for (int i = 2; i < N; i++)
            {
                if (N % i == 0) return false ;

            }
            
            return true;
        }


        static void Main(string[] args)
        {


            Console.Write("Enter a positive number from 1 to ...N: ");
            string nStr = Console.ReadLine();
            bool check = int.TryParse(nStr, out int res);
            if (check)
            {
                if (Simple(res))
                {
                    Console.WriteLine("{0} is a prime number", res);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("{0} is not a prime number", res);
                    Console.ReadLine();

                }

            }
            else
            {
                Console.WriteLine("You entered not a number");
                Console.ReadLine();
            }
        }
    }
}
