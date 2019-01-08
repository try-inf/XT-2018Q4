﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_Users.BLL.Interface
{
    public interface ICacheLogic
    {
        bool Add<T>(string key, T value);

        T Get<T>(string key);

        bool Delete(string key);
    }
}
