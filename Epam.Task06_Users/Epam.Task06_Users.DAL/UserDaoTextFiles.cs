using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.DAL.Interface;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.DAL
{
    public class UserDaoTextFiles : IUserDao
    {
        private static string _projpath = Directory.GetCurrentDirectory();
        private static string _users_bd_txt = _projpath + @"\users.txt";
        
        public void Add(User user)
        {
            int lastId = 0; 
            if (File.Exists(_users_bd_txt))
            {
                string last = File.ReadAllLines(_users_bd_txt).Last();
                int ind = last.IndexOf(@",");
                lastId = int.Parse(last.Substring(0, ind));
            }

            user.Id = ++lastId;

            StringBuilder sb = new StringBuilder();
            sb = sb.Append(user.Id).Append(",").Append(user.Name).Append(",")
                .Append(user.DateOfBirth).Append(",").Append(user.Age);
            
            using (StreamWriter sw = File.AppendText(_users_bd_txt))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        public bool Delete(int id)
        {
            string[] datafromfile = null;
            StringBuilder sb = new StringBuilder();
            bool flag = false;
            
            if (File.Exists(_users_bd_txt))
            {
                datafromfile = File.ReadAllLines(_users_bd_txt);
                
                int seekId = 0;
                for (int i = 0; i < datafromfile.Length; i++)
                {
                    string[] value = datafromfile[i].Split(',');
                    seekId = int.Parse(value[0]);
                    if (seekId != id)
                    {
                        sb = sb.Append(value[0]).Append(",").Append(value[1]).Append(",")
                            .Append(value[2]).Append(",").Append(value[3]).Append(Environment.NewLine);
                    }

                    if (seekId == id)
                    {
                        flag = true;
                    }
                }
                
                using (StreamWriter sw = File.CreateText(_users_bd_txt))
                {
                    sw.Write(sb.ToString());
                }
            }
            else
            {
                throw new FileNotFoundException("File with users not found!");
            }

            return flag;
        }

        public IEnumerable<User> GetAll()
        {
            string[] datafromfile = null;
            StringBuilder sb = new StringBuilder();
            List<User> _usersFromFile = new List<User>();

            if (File.Exists(_users_bd_txt))
            {
                datafromfile = File.ReadAllLines(_users_bd_txt);

                foreach (var item in datafromfile)
                {
                    string[] value = item.Split(',');
                    try
                    {
                        _usersFromFile.Add(new User
                        {
                            Id = int.Parse(value[0]),
                            Name = value[1],
                            DateOfBirth = DateTime.Parse(value[2]),
                            Age = int.Parse(value[3]),
                        });
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("File with users not found");
            }

            return _usersFromFile;
        }
    }
}
