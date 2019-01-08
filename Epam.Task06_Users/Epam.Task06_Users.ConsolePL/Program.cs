using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.BLL.Interface;
using Epam.Task06_Users.Common;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.ConsolePL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Init();
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void Init()
        {
            var userLogic = DependencyResolver.UserLogic;

            Console.WriteLine("Please choose an option to do:");
            Console.WriteLine("\t 1: Create user.");
            Console.WriteLine("\t 2: Show list of users.");
            Console.WriteLine("\t 3: Remove user.");
            Console.WriteLine();
            Console.WriteLine("If you want to quit application type \"exit\".");
            Console.WriteLine();
            Console.Write("Your choice: ");

            while (true)
            {
                string s = Console.ReadLine();

                if (s == "1")
                {
                    AddUser(userLogic);
                    break;
                }
                else if (s == "2")
                {
                    ShowUsers(userLogic);
                    break;
                }
                else if (s == "3")
                {
                    DeleteUsers(userLogic);
                    break;
                }
                else if (s.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.Write("Please choose the correct option: ");
                }
            }
        }

        private static void AddUser(IUserLogic userLogic)
        {
            var user = new User();

            Console.WriteLine();
            while (true)
            {
                try
                {
                    user.Name = ReadName("Enter the name of user: ");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: {0}", ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            while (true)
            {
                try
                {
                    user.DateOfBirth = ReadDateTime("Enter date of birth(in format dd-mm-yyyy or dd.mm.yyyy): ");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: {0}", ex.Message);
                    Console.WriteLine();
                }
            }

            int age = (DateTime.Now - user.DateOfBirth).Days / 365;
            user.Age = age;

            userLogic.Add(user);
            Init();
        }

        private static void ShowUsers(IUserLogic userLogic)
        {
            Console.WriteLine();
            Console.WriteLine("Id , Name , DateOfBirth , Age");
            try
            {
                foreach (var user in userLogic.GetAll())
                {
                    Console.WriteLine($"{user.Id} , {user.Name} , {user.DateOfBirth:D} , {user.Age}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: {0}. Before using this option, create at least one user", ex.Message);
            }

            Console.WriteLine();
            Init();
        }

        private static void DeleteUsers(IUserLogic userLogic)
        {
            Console.WriteLine();
            int id = ReadInt("Enter the Id of user: ");
            Console.WriteLine();
            if (userLogic.Delete(id))
            {
                Console.WriteLine("User with Id \"{0}\" was successfully removed", id);
            }
            else
            {
                Console.WriteLine("User with Id \"{0}\" wasn't removed", id);
            }

            Console.WriteLine();
            Init();
        }
        
        private static string ReadName(string str)
        {
            while (true)
            {
                Console.Write(str);
                string name = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("You entered nothing!");
                }
                else
                {
                    return name;
                }
            }
        }

        private static DateTime ReadDateTime(string str)
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

        private static int ReadInt(string str)
        {
            while (true)
            {
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
                }
            }
        }
    }
}
