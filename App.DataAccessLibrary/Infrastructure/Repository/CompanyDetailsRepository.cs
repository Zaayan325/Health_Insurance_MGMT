using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class CompanyDetailsRepository : Repository<CompanyDetails>, ICompanyDetailsRepository
    {
        private HealthInsuranceMGMT _context;
        
        public CompanyDetailsRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        public void Update(CompanyDetails companyDetails)
        {
            var CompanyDetailsDb = _context.CompanyDetails.FirstOrDefault(cd => cd.CompanyId == companyDetails.CompanyId);
            if (CompanyDetailsDb != null)
            {
                CompanyDetailsDb.CompanyName = companyDetails.CompanyName;
                CompanyDetailsDb.Address = companyDetails.Address;
                CompanyDetailsDb.Phone = companyDetails.Phone;
                CompanyDetailsDb.CompanyURL = companyDetails.CompanyURL;
            }
        }
    }
}
