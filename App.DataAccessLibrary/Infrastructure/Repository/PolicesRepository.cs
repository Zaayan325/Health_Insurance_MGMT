using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class PolicesRepository : Repository<Policies>, IPoliciesRepository
    {
        private HealthInsuranceMGMT _context;

        public PolicesRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        public void update(Policies policy)
        {
            var pol = _context.Policies.FirstOrDefault(p => p.Id == policy.Id);
            if (pol != null)
            {
                pol.PolicyName = policy.PolicyName;
                pol.PolicyDescription = policy.PolicyDescription;
                pol.Amount = policy.Amount;
                pol.Emi = policy.Emi;
                pol.CompanyId = policy.CompanyId;
                pol.CompanyDetails = policy.CompanyDetails;
            }
        }
        
    }    
}
