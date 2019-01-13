using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task07._5_TimeCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "В 7:55 я встал, позавтракал и к 10:17 прошёл на работу";
            string regPattern = @"\b([0-1]?[0-9]|2[0-3]):([0-5][0-9])\b";
            var regex = new Regex(regPattern);
            Console.WriteLine("Your string: ");
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            int matchesCount = regex.Matches(text).Count;
            Console.WriteLine("In your string time is found {0} times", matchesCount);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
