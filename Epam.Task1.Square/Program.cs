using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    class Program
    {
        
        static void Square(int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == N / 2 && j == N / 2)
                        Console.Write(" ");
                    else 
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive odd number: ");

            try          //using    try..catch blocks to prevent using the incorrect format of data
            {
                int res = int.Parse(Console.ReadLine());

                if (res % 2 == 0)
                {
                    Console.WriteLine("Please enter an odd number (not even)");
                    Console.ReadLine();
                }
                else
                {
                    Square(res);
                    Console.ReadLine();
                }
            }
        
            catch(FormatException)
            {
                Console.WriteLine("You entered not a number");
                Console.ReadLine();
            }




            /*     

            //using TryParse method to prevent using the incorrect format of data
            bool check = int.TryParse(Console.ReadLine(), out int res);

            if (check)
            {
                if (res % 2 == 0)
                {
                    Console.WriteLine("Please enter an odd number (not even)");
                    Console.ReadLine();
                }
                else
                {
                    Square(res);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("You entered not a number");
                Console.ReadLine();
            }
            */

        }
    }
}
