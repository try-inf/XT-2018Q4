using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task07._2_HTMLReplacer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами";
            string regPattern = @"<.+?>";
            string blank = "_";
            var regex = new Regex(regPattern, RegexOptions.IgnoreCase);
            string result = regex.Replace(text, blank);

            Console.WriteLine("The string with HTML tegs: ");
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("The string after replacing all HTML tegs with symbol \"_\": ");
            Console.WriteLine();
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
