using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task07._4_NumberValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = ReadString("Please enter some number: ");
            string regPatternDecimal = @"^\-?\d+\.?\d+$";
            string regPatternScientific = @"^\-?\d+\.?\d+(e\-?\d+)$";

            if (Regex.IsMatch(text, regPatternDecimal))
            {
                Console.WriteLine("This number written in decimal notation.");
            }
            else if (Regex.IsMatch(text, regPatternScientific))
            {
                Console.WriteLine("This number written in scientific notation");
            }
            else
            {
                Console.WriteLine("You entered not a numeber");
            }

            Console.WriteLine();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static string ReadString(string str)
        {
            while (true)
            {
                Console.Write(str);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("You entered nothing!");
                }
                else
                {
                    return input;
                }
            }
        }
    }
}
