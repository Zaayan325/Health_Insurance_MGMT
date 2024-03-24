using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class InsuranceCompanyRepository : Repository<InsuranceCompany>, IInsuranceCompanyRepository
    {

        private HealthInsuranceMGMT _context;

        public InsuranceCompanyRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        public void Update(InsuranceCompany insuranceCompany)
        {
            var insuranceFromDb = _context.InsuranceCompany.FirstOrDefault(er => er.Ins_Id == insuranceCompany.Ins_Id);
            if (insuranceFromDb != null)
            {
                // Update properties
                insuranceFromDb.Ins_Name = insuranceCompany.Ins_Name;
                insuranceFromDb.Address = insuranceCompany.Address;
                insuranceFromDb.Phone = insuranceCompany.Phone;
                insuranceFromDb.CompantWebsiteUrl = insuranceCompany.CompantWebsiteUrl;
                insuranceFromDb.Ins_CompanyLogourl = insuranceCompany.Ins_CompanyLogourl;
                insuranceFromDb.Ins_Description = insuranceCompany.Ins_Description;

                // Now update the database context
                _context.InsuranceCompany.Update(insuranceFromDb);

                // Note: You don't call _context.SaveChanges() here because that should be done by the UnitOfWork.
            }
        }

    }
}
