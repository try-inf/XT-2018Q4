using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._1_Round
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

        static void Main(string[] args)
        {
            Round myCircle = new Round();
            Console.WriteLine("Please enter the coordinates of the center" +
                " of the circle and its radius");
            myCircle.X = ReadInt("X-coordinate: ");
            myCircle.Y = ReadInt("Y-coordinate: ");
            myCircle.R = ReadInt("Radius: ");

            Console.WriteLine();
            Console.WriteLine("You've made a circle with center in point ({0},{1}) and Radius = {2}", myCircle.X, myCircle.Y,myCircle.R);
            Console.WriteLine("Its circumference is {0:#.##} and its area is {1:#.##}" , myCircle.GetCircumference(), myCircle.GetArea());

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();

        }
    }
}
