using Microsoft.EntityFrameworkCore;
using App.Models.Models;


namespace App.DataAccessLibrary
{
    public class HealthInsuranceMGMT : DbContext
    {
        public HealthInsuranceMGMT(DbContextOptions<HealthInsuranceMGMT> options) : base(options)
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }

        //public DbSet<CompanyDetails> CompanyDetails { get; set; }

        public DbSet<EmpRegister> EmpRegister { get; set; }

        //public DbSet<HospitalInfo> HospitalInfo { get; set; }

        //public DbSet<Policesonemployees> Policesonemployees { get; set; }

        //public DbSet<Policies> Policies { get; set; }

        //public DbSet<PolicyApprovalDetails> PolicyApprovalDetails { get; set; }

        //public DbSet<PolicyRequestDetails> PolicyRequestDetails { get; set; }

        //public DbSet<PolicyTotalDescription> PolicyTotalDescription { get; set; }



    }
}
