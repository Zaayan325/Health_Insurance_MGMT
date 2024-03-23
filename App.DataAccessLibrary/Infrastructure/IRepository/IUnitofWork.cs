using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IUnitofWork
    {
        IEmpRegisterRepository EmpRegisterRepository { get; }
        ICompanyDetailsRepository CompanyDetailsRepository { get; }
       
        IContactRepository ContactRepository { get; }

        void save();
    }
}
