using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class EmpRegisterRepository : Repository<EmpRegister>, IEmpRegisterRepository
    {
        private readonly HealthInsuranceMGMT _context;

        public EmpRegisterRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }
	
		public async Task UpdateAsync(EmpRegister empRegister)
        {
            var EmpRegisterDb = await _context.EmpRegister.FirstOrDefaultAsync(er => er.empno == empRegister.empno);
            if (EmpRegisterDb != null)
            {
                // Here we update the entity using EF Core's Entry API
                // This will mark the entity as 'Modified' and ensure all changes are tracked
                _context.Entry(EmpRegisterDb).CurrentValues.SetValues(empRegister);

                // Save the changes asynchronously
                await _context.SaveChangesAsync();
            }
        }
        public async Task<EmpRegister> FindEmployeeAndPolicyAsync(int employeeId)
        {
            // Using EF Core's Include method to include related Policy data
            return await _context.EmpRegister
                                 .Include(e => e.Policies) // Adjust this line if your navigation property is named differently
                                 .FirstOrDefaultAsync(e => e.empno == employeeId);
        }

        public bool ValidateUser(string username, string password, int empno)
        {
            var user = _context.EmpRegister.FirstOrDefault(u => u.username == username && u.password == password && u.empno ==empno);
            return user != null;
        }
    }
}

//public void Update(EmpRegister empRegister)
//{
//    var EmpRegisterDb = _context.EmpRegister.FirstOrDefault(er => er.empno == empRegister.empno);
//    if (EmpRegisterDb != null)
//    {
//        EmpRegisterDb.username = empRegister.username;
//        EmpRegisterDb.designation = empRegister.designation;
//        EmpRegisterDb.joindate = empRegister.joindate;
//        EmpRegisterDb.Salary = empRegister.Salary;
//        EmpRegisterDb.firstname = empRegister.firstname;
//        EmpRegisterDb.lastname = empRegister.lastname;

//        EmpRegisterDb.password = empRegister.password;
//        EmpRegisterDb.address = empRegister.address;
//        EmpRegisterDb.contactno = empRegister.contactno;
//        EmpRegisterDb.state = empRegister.state;
//        EmpRegisterDb.country = empRegister.country;
//        EmpRegisterDb.city = empRegister.city;
//        EmpRegisterDb.policystatus = empRegister.policystatus;
//        EmpRegisterDb.PolicyId = empRegister.PolicyId;
//    }

//}