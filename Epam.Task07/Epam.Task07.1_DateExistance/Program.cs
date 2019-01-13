using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task07._1_DateExistance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = ReadString("Please type some text that contains date (format dd-mm-yyyy): ");
            string regPattern = @"\d{2}-\d{2}-\d{4}";

            if (Regex.IsMatch(text, regPattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine($"Your text \"{text}\" contains date.");
            }
            else
            {
                Console.WriteLine($"Your text \"{text}\" doesn't contain date.");
            }

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
