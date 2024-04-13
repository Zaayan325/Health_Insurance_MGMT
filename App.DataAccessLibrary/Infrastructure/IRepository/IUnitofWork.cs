using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataAccessLibrary.Infrastructure.Repository;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IUnitofWork
    {
        IEmpRegisterRepository EmpRegisterRepository { get; }
        IPoliciesRepository PoliciesRepository { get; }
       
        IHospitalRepository HospitalRepository { get; }
        IPolicyRequestRepository PolicyRequestRepository { get; }
        IContactRepository ContactRepository { get; }

        IInsuranceCompanyRepository InsuranceCompanyRepository { get; }

        IAdminLoginRepository AdminLoginRepository { get; }   

        //Task save();
        void save();
    }
}
