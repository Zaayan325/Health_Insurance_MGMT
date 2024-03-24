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
            var insurance = _context.InsuranceCompany.FirstOrDefault(er => er.Ins_Id == insuranceCompany.Ins_Id);
            if (insurance != null)
            {

                insurance.Ins_Name = insuranceCompany.Ins_Name;
                insurance.Address = insuranceCompany.Address;
                insurance.Phone = insuranceCompany.Phone;
                insurance.CompantWebsiteUrl = insuranceCompany.CompantWebsiteUrl;
                insurance.Ins_CompanyLogourl = insuranceCompany.Ins_CompanyLogourl;
                insurance.Ins_Description= insuranceCompany.Ins_Description;
                
            }

        }
    }
}
