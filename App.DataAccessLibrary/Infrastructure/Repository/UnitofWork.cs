using App.DataAccessLibrary.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private HealthInsuranceMGMT _context;
        public IEmpRegisterRepository EmpRegisterRepository { get; private set; }

        public IPoliciesRepository PoliciesRepository { get; private set; }

        public IPolicyRequestRepository PolicyRequestRepository { get; private set; }

        public IHospitalRepository HospitalRepository { get; private set; }
        public IContactRepository ContactRepository { get; private set; }
        public IInsuranceCompanyRepository InsuranceCompanyRepository { get; private set; }

        public IAdminLoginRepository AdminLoginRepository { get; private set; }
        public UnitofWork(HealthInsuranceMGMT context)
        {
            _context = context;
            EmpRegisterRepository = new EmpRegisterRepository(context);
            PoliciesRepository = new PoliciesRepository(context);
            InsuranceCompanyRepository = new InsuranceCompanyRepository(context);
            ContactRepository = new ContactRepository(context);
            AdminLoginRepository = new AdminLoginRepository(context);
            PolicyRequestRepository = new PolicyRequestRepository(context);
            HospitalRepository = new HospitalRepository(context);
        }
        public void save() // Make this method async
        {
             _context.SaveChanges();
            Console.WriteLine("Changes Saved To The Database");
        }
    }
}
