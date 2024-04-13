using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IEmpRegisterRepository : IRepository<EmpRegister>
    {
        void Update(EmpRegister empRegister); // Updated to return Task

        bool ValidateUser(string username, string password,int empno);

        Task<EmpRegister> FindEmployeeAndPolicyAsync(int employeeId);
    }
}
