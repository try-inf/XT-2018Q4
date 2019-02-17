using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.BLL.Interface
{
    public interface IAwardLogic
    {
        void Add(Award award);

        Award GetById(int id);

        bool CheckById(int id);

        IEnumerable<Award> GetAll();
    }
}
