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

        public ICompanyDetailsRepository CompanyDetailsRepository { get; private set; }

       

        public IContactRepository ContactRepository { get; private set; }

        public UnitofWork(HealthInsuranceMGMT context)
        {
            _context = context;
            EmpRegisterRepository = new EmpRegisterRepository(context);
            CompanyDetailsRepository = new CompanyDetailsRepository(context);
            
            ContactRepository = new ContactRepository(context);
        }
        public void save()
        {

            _context.SaveChanges();
            Console.WriteLine("Changes Saved To The Database");
        }
    }
}
