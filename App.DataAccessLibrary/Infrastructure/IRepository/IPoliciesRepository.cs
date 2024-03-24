using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IPoliciesRepository : IRepository<Policies>
    {
        void Update(Policies policies);

       
    }



}
