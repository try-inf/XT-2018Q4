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
        private static IUserDao _userDao;
        private static IUserLogic _userLogic;
        private static IAwardDao _awardDao;
        private static IAwardLogic _awardLogic;
        private static ICacheLogic _cacheLogic;
        private static IUserAwardDao _userAwardDao;
        private static IUserAwardLogic _userAwardLogic;
        
        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if (_userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                _userDao = new UserDaoMemory();
                                break;
                            }

                        case "textfile":
                            {
                                _userDao = new UserDaoTextFiles();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return _userDao;
            }
        }

        public static IAwardDao AwardDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoAwardKey"];

                if (_awardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                _awardDao = new AwardDaoMemory();
                                break;
                            }

                        case "textfile":
                            {
                                _awardDao = new AwardDaoTextFiles();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return _awardDao;
            }
        }

        public static IUserAwardDao UserAwardDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserAwardKey"];

                if (_userAwardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                _userAwardDao = new UserAwardDaoMemory();
                                break;
                            }

                        case "textfile":
                            {
                                _userAwardDao = new UserAwardDaoTextFiles();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return _userAwardDao;
            }
        }

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao, CacheLogic));

        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao, CacheLogic));

        public static ICacheLogic CacheLogic => _cacheLogic ?? (_cacheLogic = new CacheLogic());

        public static IUserAwardLogic UserAwardLogic => _userAwardLogic ?? (_userAwardLogic = new UserAwardLogic(UserAwardDao));
    }
}
