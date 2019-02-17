using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.DAL.Interface;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.DAL
{
    public class UserAwardDaoMemory : IUserAwardDao
    {
        private static readonly Dictionary<int, UserAward> _repoUsersAwards = new Dictionary<int, UserAward>();

        public void Add(UserAward useraward)
        {
            var lastId = _repoUsersAwards.Any()
                ? _repoUsersAwards.Keys.Max()
                : 0;

            useraward.Id = ++lastId;

            _repoUsersAwards.Add(useraward.Id, useraward);
        }

        public IEnumerable<UserAward> GetAll()
        {
            return _repoUsersAwards.Values;
        }

        public bool checkUsersAwards()
        {
            return true;
        }
    }
}
