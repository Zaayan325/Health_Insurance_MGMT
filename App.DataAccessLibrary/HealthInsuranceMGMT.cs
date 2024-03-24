using Microsoft.EntityFrameworkCore;
using App.Models.Models;


namespace App.DataAccessLibrary
{
    public class HealthInsuranceMGMT : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyRequestDetails>()
                .HasOne(p => p.Policies)
                .WithMany()
                .HasForeignKey(p => p.PolicyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Policesonemployees>()
                .HasOne(p => p.Policies)
                .WithMany()
                .HasForeignKey(p => p.policyid)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PolicyApprovalDetails>()
                .HasOne(p => p.RequestDetails)
                .WithMany()
                .HasForeignKey(p => p.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PolicyTotalDescription>()
                .HasOne(p => p.PolicyRequestDetails)
                .WithMany()
                .HasForeignKey(p => p.policyId)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }

        public HealthInsuranceMGMT(DbContextOptions<HealthInsuranceMGMT> options) : base(options)
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }

        public DbSet<CompanyDetails> CompanyDetails { get; set; }

        public DbSet<EmpRegister> EmpRegister { get; set; }

        public DbSet<HospitalInfo> HospitalInfo { get; set; }

        public DbSet<Policesonemployees> Policesonemployees { get; set; }

        public DbSet<Policies> Policies { get; set; }

        public DbSet<PolicyApprovalDetails> PolicyApprovalDetails { get; set; }

        public DbSet<PolicyRequestDetails> PolicyRequestDetails { get; set; }

        public DbSet<PolicyTotalDescription> PolicyTotalDescription { get; set; }
 //Contacts in public
		public DbSet<Contact> Contact { get; set; }

        //Insurance Company 

        public DbSet<InsuranceCompany> InsuranceCompany { get; set; }

    }
}
