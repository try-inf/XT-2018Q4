using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._2_Triangle
{
    class Program
    {
        static int ReadInt(string str)
        {
            init:
            Console.Write(str);
            string intStr = Console.ReadLine();
            bool check = int.TryParse(intStr, out int result);
            if (check)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Wrong input");
                goto init;
            }
        }

        static bool TriangleCheck(Triangle t, out string mistake)
        {
            bool result = (((t.A + t.B) > t.C) && ((t.A + t.C) > t.B) && ((t.B + t.C) > t.A));

            mistake = "";
            if ((t.A + t.B) < t.C)
            {
                mistake = string.Format("Side C({0}) should be less than Side A({1}) + Side B({2})", t.C, t.A, t.B);
            }
            else if ((t.A + t.C) < t.B)
            {
                mistake = string.Format("Side B({0}) should be less than Side A({1}) + Side C({2})", t.B, t.A, t.C);
            }
            else if ((t.B + t.C) < t.A)
            {
                mistake = string.Format("Side A({0}) should be less than Side B({1}) + Side C({2})", t.A, t.B, t.C);
            }

            return result;
        }

        static void Main(string[] args)
        {
            TriangleInit:

            Triangle myTriangle = new Triangle();
            Console.WriteLine("Please enter the values of the three sides" +
                " of the triangle");
            myTriangle.A = ReadInt("Side A: ");
            myTriangle.B = ReadInt("Side B: ");
            myTriangle.C = ReadInt("Side C: ");

            if (TriangleCheck(myTriangle, out string mistake))
            {
                Console.WriteLine();
                Console.WriteLine("Perimeter of the trinagle is {0:N2}", myTriangle.GetPerimeter());
                Console.WriteLine("The area of the triangle is {0:N2}", myTriangle.GetArea());
            }
            else
            {
                Console.WriteLine("The sum of the two sides of the triangle " +
                    "should be greater than the third one. The error is that {0}", mistake);

                goto TriangleInit;
            }

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }
    }
}
