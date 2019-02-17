using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.BLL.Interface
{
    public interface IUserLogic
    {
        void Add(User user);

        bool Delete(int id);

        User GetById(int id);

        bool CheckById(int id);

        IEnumerable<User> GetAll();
    }
}
