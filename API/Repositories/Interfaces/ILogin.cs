﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface ILogin
    {
        int Create(LoginVM loginVM);

        int Update(Account account, int id);

    }
}
