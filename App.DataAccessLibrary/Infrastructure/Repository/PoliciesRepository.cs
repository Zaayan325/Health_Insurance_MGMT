using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class PoliciesRepository : Repository<Policies>, IPoliciesRepository
    {

        private HealthInsuranceMGMT _context;

        public PoliciesRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        public void Update(Policies policies)
        {
            var policiesFromDb = _context.Policies.FirstOrDefault(po => po.PolicyId == policies.PolicyId);
            if (policiesFromDb != null)
            {
                // Update properties
                policiesFromDb.PolicyName = policies.PolicyName;
                policiesFromDb.PolicyDescription = policies.PolicyDescription;
                policiesFromDb.PolicyFullAmount = policies.PolicyFullAmount;
                policiesFromDb.equatedmonthlyinstalment = policies.equatedmonthlyinstalment;
                policiesFromDb.policymonths = policies.policymonths;
                policiesFromDb.Ins_Id = policies.Ins_Id;
                policiesFromDb.MedicalId = policies.MedicalId;
                policiesFromDb.PolicyTermasandConditionsurl = policies.PolicyTermasandConditionsurl;

                _context.Policies.Update(policiesFromDb);
            }
        }

    }
}
