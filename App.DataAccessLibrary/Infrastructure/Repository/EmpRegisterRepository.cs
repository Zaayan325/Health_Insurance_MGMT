using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class EmpRegisterRepository : Repository<EmpRegister>, IEmpRegisterRepository
    {
        private HealthInsuranceMGMT _context;

        public EmpRegisterRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        public void Update(EmpRegister empRegister)
        {
            var EmpRegisterDb = _context.EmpRegister.FirstOrDefault(er => er.empno == empRegister.empno);
            if (EmpRegisterDb != null)
            {
                EmpRegisterDb.designation = empRegister.designation;
                EmpRegisterDb.joindate = empRegister.joindate;
                EmpRegisterDb.Salary = empRegister.Salary;
                EmpRegisterDb.firstname = empRegister.firstname;
                EmpRegisterDb.lastname = empRegister.lastname;
                EmpRegisterDb.username = empRegister.username;
                EmpRegisterDb.password = empRegister.password;
                EmpRegisterDb.address = empRegister.address;
                EmpRegisterDb.contactno = empRegister.contactno;
                EmpRegisterDb.state = empRegister.state;
                EmpRegisterDb.country = empRegister.country;
                EmpRegisterDb.city = empRegister.city;
                EmpRegisterDb.policystatus = empRegister.policystatus;
                EmpRegisterDb.Policyid = empRegister.Policyid;
            }

        }
    }
}
