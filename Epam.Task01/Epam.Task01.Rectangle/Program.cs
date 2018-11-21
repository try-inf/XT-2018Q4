using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.Rectangle
{
    class Program
    {
        static int SquareRect(int a, int b)
        {
            return a * b;
        }

        static bool CheckNegativeOrZero(int n)
        {
            if (n <= 0) return true;
            return false;
        }

        static void WarningMessage()
            => Console.WriteLine("Warning! You are able to enter only positive values");


        static void Main(string[] args)
        {
            Console.WriteLine("Calculating the area of rectangle with sides 'а' and 'b': ");

            SideA:
            Console.Write("Enter the length of side 'a' (positive integer number) = ");
            int a;

            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                goto SideA;   //ignoring user ability to input something wrong(not positive integer number)
            }

            if (CheckNegativeOrZero(a))   //check for positive value of typed number
            {
                WarningMessage();
                goto SideA;
            }

            SideB:
            Console.Write("Enter the length of side 'b' (positive integer number) = ");
            int b;

            try
            {
                b = int.Parse(Console.ReadLine());
            }
            catch
            {
                goto SideB;   //ignoring user ability to input something wrong(not positive integer number)
            }

            if (CheckNegativeOrZero(b))      //check for positive value of typed number
            {
                WarningMessage();
                goto SideB;
            }


            Console.WriteLine("The square of a rectangle is {0}", SquareRect(a,b));
            Console.ReadLine();
        }
    }
}
