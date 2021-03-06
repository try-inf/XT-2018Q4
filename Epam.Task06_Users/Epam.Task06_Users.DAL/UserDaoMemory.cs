﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.DAL.Interface;
using Epam.Task06_Users.Entities;
using Epam.Task06_Users.Entities.Exceptions;

namespace Epam.Task06_Users.DAL
{
    public class UserDaoMemory : IUserDao
    {
        private static readonly Dictionary<int, User> _repoUsers = new Dictionary<int, User>();

        public void Add(User user)
        {
            var lastId = _repoUsers.Any()
                ? _repoUsers.Keys.Max()
                : 0;
            user.Id = ++lastId;

            _repoUsers.Add(user.Id, user);
        }

        public bool Delete(int id)
        {
            return _repoUsers.Remove(id);
        }

        public User GetById(int id)
        {
            return _repoUsers.TryGetValue(id, out var user)
                ? user
                : throw new ValidationException("There's no such user");
        }

        public bool CheckById(int id)
        {
            return _repoUsers.ContainsKey(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repoUsers.Values;
        }
    }
}
