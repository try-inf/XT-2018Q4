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
    public class UserAwardDaoTextFiles : IUserAwardDao
    {
        private static string _projpath = Directory.GetCurrentDirectory();
        private static string _usersawards_bd_txt = _projpath + @"\users_awards.txt";

        public void Add(UserAward useraward)
        {
            int lastId = 0;
            if (File.Exists(_usersawards_bd_txt))
            {
                string last = File.ReadAllLines(_usersawards_bd_txt).Last();
                int ind = last.IndexOf(@",");
                lastId = int.Parse(last.Substring(0, ind));
            }

            useraward.Id = ++lastId;

            StringBuilder sb = new StringBuilder();
            sb = sb.Append(useraward.Id).Append(",").Append(useraward.UserId).Append(",")
                .Append(useraward.AwardId);

            using (StreamWriter sw = File.AppendText(_usersawards_bd_txt))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        public IEnumerable<UserAward> GetAll()
        {
            string[] datafromfile = null;
            StringBuilder sb = new StringBuilder();
            List<UserAward> _usersAwardsFromFile = new List<UserAward>();

            if (File.Exists(_usersawards_bd_txt))
            {
                datafromfile = File.ReadAllLines(_usersawards_bd_txt);

                foreach (var item in datafromfile)
                {
                    string[] value = item.Split(',');
                    try
                    {
                        _usersAwardsFromFile.Add(new UserAward
                        {
                            Id = int.Parse(value[0]),
                            UserId = int.Parse(value[1]),
                            AwardId = int.Parse(value[2]),
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
                throw new FileNotFoundException("File with users and awards not found");
            }

            return _usersAwardsFromFile;
        }
    }
}
