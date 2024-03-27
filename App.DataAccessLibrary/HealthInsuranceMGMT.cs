using Microsoft.EntityFrameworkCore;
using App.Models.Models;


namespace App.DataAccessLibrary
{
    public class HealthInsuranceMGMT : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Existing configuration for Policies and InsuranceCompany.
            modelBuilder.Entity<Policies>()
                .HasOne(p => p.InsuranceCompany)
                .WithMany(b => b.Policies)
                .HasForeignKey(p => p.Ins_Id);
            // No changes here from your provided code.

            // Configuration for EmpRegister to Policies relationship.
            modelBuilder.Entity<EmpRegister>()
                .HasOne<Policies>(e => e.Policies)
                .WithMany(p => p.EmpRegister)
                .HasForeignKey(e => e.PolicyId);
            // Assuming EmpRegister is equivalent to Employee in the previous context.

            // Configure the PolicyRequestDetails relationship with EmpRegister.
            modelBuilder.Entity<PolicyRequestDetails>()
                .HasOne<EmpRegister>(p => p.EmpRegister)
                .WithMany() // If EmpRegister has navigation back to PolicyRequestDetails, define it here.
                .HasForeignKey(p => p.empno)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cycles or multiple cascades by setting to NoAction.

            // Configure the PolicyRequestDetails relationship with Policies.
            modelBuilder.Entity<PolicyRequestDetails>()
                .HasOne<Policies>(p => p.Policies)
                .WithMany() // If Policies has navigation back to PolicyRequestDetails, define it here.
                .HasForeignKey(p => p.PolicyId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cycles or multiple cascades by setting to NoAction.

            base.OnModelCreating(modelBuilder);
        }


        public HealthInsuranceMGMT(DbContextOptions<HealthInsuranceMGMT> options) : base(options)
        {

        }
        public DbSet<AdminLogin> AdminLogin { get; set; }

        public DbSet<CompanyDetails> CompanyDetails { get; set; }

        public DbSet<EmpRegister> EmpRegister { get; set; }

        public DbSet<HospitalInfo> HospitalInfo { get; set; }

        

        public DbSet<Policies> Policies { get; set; }

      
        public DbSet<PolicyRequestDetails> PolicyRequestDetails { get; set; }

       
 //Contacts in public
		public DbSet<Contact> Contact { get; set; }

        //Insurance Company 

        public DbSet<InsuranceCompany> InsuranceCompany { get; set; }



    }
}
