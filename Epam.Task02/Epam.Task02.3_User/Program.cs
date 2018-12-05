using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._3_User
{
    class Program
    {
        static DateTime ReadDateTime(string str)
        {
            while (true)
            {
                Console.Write(str);
                string intStr = Console.ReadLine();
                bool check = DateTime.TryParse(intStr, out DateTime result);
                if (check)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }


        static void Main(string[] args)
        {
            User myUser = new User();
            Console.WriteLine("Please enter your details:");
            Console.Write("Firstname: ");
            myUser.FName = Console.ReadLine();
            Console.Write("Lastname: ");
            myUser.LName = Console.ReadLine();
            Console.Write("Patronymic: ");
            myUser.PName = Console.ReadLine();

            while (true)
            {
                try
                {
                    myUser.BDate = ReadDateTime("Date of birth (in format dd-mm-yyyy or dd.mm.yyyy: ");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("{0} Please check the year of birth that you've entered.", ex.Message);
                }
            }





    Console.WriteLine();
            Console.WriteLine("Congratulations! Now you are in our database");
            Console.WriteLine();
            Console.WriteLine("Please check the data entered:");
            Console.WriteLine("Firstname: {0}", myUser.FName);
            Console.WriteLine("Lastname: {0}", myUser.LName);
            Console.WriteLine("Patronymic: {0}", myUser.PName);
            Console.WriteLine("Date of birth: {0:D}", myUser.BDate);

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }
    }
}
