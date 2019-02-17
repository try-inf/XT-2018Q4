using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.DAL.Interface;
using Epam.Task06_Users.Entities;
using Epam.Task06_Users.Entities.Exceptions;

namespace Epam.Task06_Users.DAL
{
    public class AwardDaoTextFiles : IAwardDao
    {
        private static string _projpath = Directory.GetCurrentDirectory();
        private static string _awards_bd_txt = _projpath + @"\awards.txt";

        public void Add(Award award)
        {
            int lastId = 0;
            if (File.Exists(_awards_bd_txt))
            {
                string last = File.ReadAllLines(_awards_bd_txt).Last();
                int ind = last.IndexOf(@",");
                lastId = int.Parse(last.Substring(0, ind));
            }

            award.Id = ++lastId;

            StringBuilder sb = new StringBuilder();
            sb = sb.Append(award.Id).Append(",").Append(award.Title);

            using (StreamWriter sw = File.AppendText(_awards_bd_txt))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        public Award GetById(int id)
        {
            string[] datafromfile = null;
            StringBuilder sb = new StringBuilder();
            List<User> _awardsFromFile = new List<User>();

            if (File.Exists(_awards_bd_txt))
            {
                datafromfile = File.ReadAllLines(_awards_bd_txt);

                foreach (var item in datafromfile)
                {
                    string[] value = item.Split(',');
                    try
                    {
                        if (int.Parse(value[0]) == id)
                        {
                            return new Award
                            {
                                Id = int.Parse(value[0]),
                                Title = value[1],
                            };
                        }
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

            throw new ValidationException("There's no such award");
        }

        public bool CheckById(int id)
        {
            string[] datafromfile = null;

            if (File.Exists(_awards_bd_txt))
            {
                datafromfile = File.ReadAllLines(_awards_bd_txt);

                foreach (var item in datafromfile)
                {
                    string[] value = item.Split(',');
                    try
                    {
                        if (int.Parse(value[0]) == id)
                        {
                            return true;
                        }
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

            return false;
        }

        public IEnumerable<Award> GetAll()
        {
            string[] datafromfile = null;
            StringBuilder sb = new StringBuilder();
            List<Award> _awardsFromFile = new List<Award>();

            if (File.Exists(_awards_bd_txt))
            {
                datafromfile = File.ReadAllLines(_awards_bd_txt);

                foreach (var item in datafromfile)
                {
                    string[] value = item.Split(',');
                    try
                    {
                        _awardsFromFile.Add(new Award
                        {
                            Id = int.Parse(value[0]),
                            Title = value[1],
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
                throw new FileNotFoundException("File with awards not found");
            }

            return _awardsFromFile;
        }
    }
}
