using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task07._3_EmailFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
            string regPattern = @"[a-zA-Z0-9]([\w\-\.]+)[a-zA-Z0-9]@[a-zA-Z0-9]([a-zA-Z0-9\-]+)[a-zA-Z0-9](\.[a-zA-Z0-9]([a-zA-Z0-9\-]+)[a-zA-Z0-9])*(\.[a-zA-Z]{2,6})";
            var regex = new Regex(regPattern, RegexOptions.IgnoreCase);
            var match = regex.Match(text);

            Console.WriteLine("Your string: ");
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();

            if (match.Success)
            {
                Console.WriteLine("Email addresses in your string: ");
                Console.WriteLine();

                foreach (var item in regex.Matches(text))
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Your string doesn't contain any email addresses");
            }

            Console.WriteLine();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
