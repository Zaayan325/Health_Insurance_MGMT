using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IAdminLoginRepository : IRepository<AdminLogin>
    {
        void Update(AdminLogin adminLoginn);
		bool ValidateAdmin(string Email, string AdminPassword, int Adm_Id);

	






    }
}
