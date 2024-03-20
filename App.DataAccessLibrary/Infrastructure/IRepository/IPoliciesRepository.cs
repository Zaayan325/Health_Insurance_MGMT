﻿using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IPoliciesRepository : IRepository<Policies>
    {
        void update(Policies policies);
    }
}