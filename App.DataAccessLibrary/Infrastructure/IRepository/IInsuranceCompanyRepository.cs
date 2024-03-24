using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Models;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IInsuranceCompanyRepository : IRepository<InsuranceCompany>
    {
        void Update(InsuranceCompany insuranceCompany);
    

    }
}
