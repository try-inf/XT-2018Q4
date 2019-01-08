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
            var awardLogic = DependencyResolver.AwardLogic;
            var userAwardLogic = DependencyResolver.UserAwardLogic;

            Console.WriteLine("Please choose an option to do:");
            Console.WriteLine("\t 1: Create user.");
            Console.WriteLine("\t 2: Show list of users.");
            Console.WriteLine("\t 3: Remove user.");
            Console.WriteLine("\t 4: Award user.");
            Console.WriteLine("\t 5: Create award.");
            Console.WriteLine("\t 6: Show list of awards.");
            Console.WriteLine("\t 7: Show more detailed information about users.");
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
                else if (s == "4")
                {
                    AwardUser(userLogic, awardLogic, userAwardLogic);
                    break;
                }
                else if (s == "5")
                {
                    AddAward(awardLogic);
                    break;
                }
                else if (s == "6")
                {
                    ShowAwards(awardLogic);
                    break;
                }
                else if (s == "7")
                {
                    ShowDetails(userLogic, awardLogic, userAwardLogic);
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
            Console.WriteLine();
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

        private static void AwardUser(IUserLogic userLogic, IAwardLogic awardLogic, IUserAwardLogic userAwardLogic)
        {
            var useraward = new UserAward();
            Console.WriteLine();
            try
            {
                while (true)
                {
                    int _userId = ReadInt("Enter the Id of User you want to award: ");
                    if (userLogic.CheckById(_userId))
                    {
                        useraward.UserId = _userId;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There's no user with such Id");
                    }
                }

                Console.WriteLine();

                while (true)
                {
                    int _awardId = ReadInt("Enter the Id of Award you want to award with: ");
                    if (awardLogic.CheckById(_awardId))
                    {
                        useraward.AwardId = _awardId;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There's no award with such Id");
                    }
                }

                userAwardLogic.Add(useraward);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            Console.WriteLine();
            Init();
        }

        private static void AddAward(IAwardLogic awardLogic)
        {
            var award = new Award();

            Console.WriteLine();
            while (true)
            {
                try
                {
                    award.Title = ReadName("Enter the title of award: ");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: {0}", ex.Message);
                    Console.WriteLine();
                }
            }

            awardLogic.Add(award);
            Console.WriteLine();
            Init();
        }

        private static void ShowAwards(IAwardLogic awardLogic)
        {
            Console.WriteLine();
            Console.WriteLine("Id , Title");
            try
            {
                foreach (var award in awardLogic.GetAll())
                {
                    Console.WriteLine($"{award.Id} , {award.Title}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: {0}. Before using this option, create at least one award", ex.Message);
            }

            Console.WriteLine();
            Init();
        }

        private static void ShowDetails(IUserLogic userLogic, IAwardLogic awardLogic, IUserAwardLogic userAwardLogic)
        {
            Console.WriteLine();
            int id = ReadInt("Enter the Id of user: ");
            try
            {
                var selectedUser = userLogic.GetById(id);
                Console.WriteLine();
                Console.WriteLine("Detailed information about selected user:");
                Console.WriteLine();
                Console.WriteLine("User Id: {0}", selectedUser.Id);
                Console.WriteLine("User Name: {0}", selectedUser.Name);
                Console.WriteLine("User date of birth: {0:D}", selectedUser.DateOfBirth);
                Console.WriteLine("User age: {0}", selectedUser.Age);
                Console.WriteLine();

                if (userAwardLogic.GetAll().Where(x => x.UserId == selectedUser.Id).Count() == 0)
                {
                    Console.WriteLine("User \"{0}\" has not any awards.", selectedUser.Name);
                }
                else
                {
                    Console.WriteLine("The awards list of \"{0}\":", selectedUser.Name);
                    foreach (var item in userAwardLogic.GetAll())
                    {
                        if (item.UserId == selectedUser.Id)
                        {
                            Console.WriteLine(awardLogic.GetById(item.AwardId).Title);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("It's not possible to show any information " +
                    "about awards of selected user because {0}. One of the reasons is " +
                    "that no one of users never get any award. Or may be somebody removed file with " +
                    "information about it.", ex.Message);
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
