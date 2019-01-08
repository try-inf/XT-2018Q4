using System.Collections.Generic;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.DAL.Interface
{
    public interface IUserDao
    {
        void Add(User user);

        bool Delete(int id);

        IEnumerable<User> GetAll();
    }
}