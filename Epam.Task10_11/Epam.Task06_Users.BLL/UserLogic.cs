using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.BLL.Interface;
using Epam.Task06_Users.DAL.Interface;
using Epam.Task06_Users.Entities;
using Epam.Task06_Users.Entities.Exceptions;

namespace Epam.Task06_Users.BLL
{
    public class UserLogic : IUserLogic
    {
        private const string ALL_USERS_CACHE_KEY = "GetAllUsers";
        private readonly IUserDao _userDao;
        private readonly ICacheLogic _cacheLogic;

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic)
        {
            this._userDao = userDao;
            this._cacheLogic = cacheLogic;
        }

        public void Add(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ValidationException("User is null");
                }

                this._cacheLogic.Delete(ALL_USERS_CACHE_KEY);
                this._userDao.Add(user);
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            this._cacheLogic.Delete(ALL_USERS_CACHE_KEY);
            return this._userDao.Delete(id);
        }

        public User GetById(int id)
        {
            return this._userDao.GetById(id);
        }

        public bool CheckById(int id)
        {
            return this._userDao.CheckById(id);
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = this._cacheLogic.Get<IEnumerable<User>>(ALL_USERS_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = this._userDao.GetAll();
                this._cacheLogic.Add(ALL_USERS_CACHE_KEY, result);

                return result;
            }

            return cacheResult;
        }

        public bool Edit(int id, User editUser)
        {
            this._cacheLogic.Delete(ALL_USERS_CACHE_KEY);
            return this._userDao.Edit(id, editUser);
        }
    }
}
