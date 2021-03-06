﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_Users.Entities;

namespace Epam.Task06_Users.DAL.Interface
{
    public interface IUserAwardDao
    {
        void Add(UserAward useraward);

        IEnumerable<UserAward> GetAll();
    }
}
