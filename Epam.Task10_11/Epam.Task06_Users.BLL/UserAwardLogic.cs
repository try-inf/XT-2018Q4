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
    public class UserAwardLogic : IUserAwardLogic
    {
        private readonly IUserAwardDao _userAwardDao;

        public UserAwardLogic(IUserAwardDao userAwardDao)
        {
            this._userAwardDao = userAwardDao;
        }

        public void Add(UserAward useraward)
        {
            try
            {
                if (useraward == null)
                {
                    throw new ValidationException("Users and Award list is empty");
                }

                this._userAwardDao.Add(useraward);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<UserAward> GetAll()
        {
            return this._userAwardDao.GetAll();
        }

        public bool checkUsersAwards()
        {
            return this._userAwardDao.checkUsersAwards();
        }
    }
}
