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
    public class PolicyRequestRepository : Repository<PolicyRequestDetails>, IPolicyRequestRepository
    {

        private HealthInsuranceMGMT _context;

        public PolicyRequestRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        public void Update(PolicyRequestDetails policyRequestDetails)
        {
            var policyreqfromdb = _context.PolicyRequestDetails.FirstOrDefault(p => p.RequestId == policyRequestDetails.RequestId);
            if (policyreqfromdb != null)
            {
                // Update properties
                policyreqfromdb.Status = policyRequestDetails.Status;
                
               
              
                _context.PolicyRequestDetails.Update(policyreqfromdb);
            }
        }

    }
}
