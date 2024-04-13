using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using NHibernate.Linq;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class HospitalRepository : Repository<Hospital>, IHospitalRepository
    {

        private HealthInsuranceMGMT _context;

        public HospitalRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }
       

        public void Update(Hospital hospital)
        {
            var hospitalFromDb = _context.Hospital.FirstOrDefault(er => er.HospitalId == hospital.HospitalId);
            if (hospitalFromDb != null)
            {
                // Update properties
                hospitalFromDb.HospitalName = hospital.HospitalName;
                hospitalFromDb.HospitalContactNo = hospital.HospitalContactNo;
                hospitalFromDb.HospitalAddress = hospital.HospitalAddress;
                hospitalFromDb.DocumentsUrl = hospital.DocumentsUrl;
                hospitalFromDb.FullBillPictureUrl = hospital.FullBillPictureUrl;
                hospitalFromDb.ExpenseIncurred = hospital.ExpenseIncurred;
                hospitalFromDb.StatusReport = hospital.StatusReport;
                hospitalFromDb.PolicyId = hospital.PolicyId;
                hospitalFromDb.empno = hospital.empno;

                // Now update the database context
                _context.Hospital.Update(hospitalFromDb);

                // Note: You don't call _context.SaveChanges() here because that should be done by the UnitOfWork.
            }
        }

    }
}
