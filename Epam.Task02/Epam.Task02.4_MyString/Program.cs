using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._4_MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString newString1 = new MyString();
            Console.Write("Please enter some text: ");

            newString1.Append(Console.ReadLine());
            

            Console.WriteLine("Your string now is an array which consists of the following characters: ");

            for (int i = 0; i < newString1.GetLength(); i++)
            {
                Console.WriteLine("Number {0} in array: {1}", i, newString1.ArrChars[i]);
            }


            Console.WriteLine();
            Console.WriteLine("****Demonstrating Append method of MyString class****");
            Console.WriteLine();
            Console.Write("Please enter some more text: ");

            newString1.Append(Console.ReadLine());

            Console.WriteLine("Now your string is an array which consists of the following characters: ");

            for (int i = 0; i < newString1.GetLength(); i++)
            {
                Console.WriteLine("Number {0} in array: {1}", i, newString1.ArrChars[i]);
            }


            Console.WriteLine();
            Console.WriteLine("****Demonstrating ConCat method of MyString class****");
            Console.WriteLine();
            Console.Write("Please enter some symbols: ");
            string string1 = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please enter some more symbols: ");
            string string2 = Console.ReadLine();
            string string3 = MyString.ConCat(string1, string2);
            Console.WriteLine();
            Console.WriteLine("Your strings: \"{0}\" and \"{1}\" after ConCat: {2}", string1, string2, string3);


            Console.WriteLine();
            Console.WriteLine("****Demonstrating Equal method of MyString class****");
            Console.WriteLine();
            MyString newString2 = new MyString();
            Console.Write("Please enter few symbols for string 1: ");
            newString2.Append(Console.ReadLine());
            Console.Write("Please enter few symbols for string 2: ");
            string string4 = Console.ReadLine();
            if (newString2.Equal(string4))
            {
                Console.WriteLine("string 1 equal to string 2");
            }
            else
            {
                Console.WriteLine("string 1 doesn't equal to string 2");
            }


            Console.WriteLine();
            Console.WriteLine("****Demonstrating IndexOf method of MyString class****");
            Console.WriteLine();
            MyString newString5 = new MyString();
            Console.Write("Please enter few symbols: ");
            newString5.Append(Console.ReadLine());

            char char1 = ' ';
            int yourIndex = 0;
            while (true)
            {
                Console.Write("Please enter one symbol which index you wanted to find: ");
                string intStr = Console.ReadLine();
                bool check = char.TryParse(intStr, out char result);
                if (check)
                {
                    char1 = result;
                    yourIndex = newString5.IndexOf(result);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
            if (yourIndex == -1)
            {
                Console.WriteLine("Character '{0}' isn't located in input string", char1);
            }
            else
            {
                Console.WriteLine("Index of '{0}' is {1}", char1, yourIndex);
            }
            
            

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();


        }
    }
}
