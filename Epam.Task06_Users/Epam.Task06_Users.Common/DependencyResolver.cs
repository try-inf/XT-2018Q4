using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.BLL;
using Epam.Task06_Users.BLL.Interface;
using Epam.Task06_Users.DAL;
using Epam.Task06_Users.DAL.Interface;

namespace Epam.Task06_Users.Common
{
    public static class DependencyResolver
    {
        private static IUserDao _UserDao;
        private static IUserLogic _userLogic;
        private static ICacheLogic _cacheLogic;

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if (_UserDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                _UserDao = new UserDaoMemory();
                                break;
                            }

                        case "textfile":
                            {
                                _UserDao = new UserDaoTextFiles();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return _UserDao;
            }
        }

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao, CacheLogic));

        public static ICacheLogic CacheLogic => _cacheLogic ?? (_cacheLogic = new CacheLogic());
    }
}
