using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.FontAdjustment
{
    public class Program
    {
        [Flags]
        private enum FontStyles
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        public static void Main(string[] args)
        {
            string t = string.Empty;
            int n = 0;
            int sum = 0;
            char[] resToChar = new char[3];
            while (true)
            {
                Console.WriteLine("Please choose font style: \n\r 1: bold \n\r 2: italic \n\r 4: underline \n\n\r If you want to exit then press \"9\"");

                bool check = int.TryParse(Console.ReadLine(), out n);
                if (check)
                {
                    if (n == 1 | n == 2 | n == 4)
                    {
                        if (t.Contains(n.ToString()))
                        {
                            int i = t.IndexOf(n.ToString());
                            t = t.Remove(i, 1);
                        }
                        else
                        {
                            t += n.ToString();
                        }

                        resToChar = t.ToCharArray();

                        for (int i = 0; i < resToChar.Length; i++)
                        {
                            sum += int.Parse(resToChar[i].ToString());
                        }

                        Console.WriteLine();
                        Console.WriteLine("Selected parametres: {0}", (FontStyles)sum);
                        sum = 0;
                    }
                    else if (n == 9)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You should enter 1, 2 or 4 to choose font style (or 9-to exit)");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }
    }
}
