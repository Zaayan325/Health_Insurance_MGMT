using Microsoft.EntityFrameworkCore;
using App.Models.Models;


namespace App.DataAccessLibrary
{
    public class HealthInsuranceMGMT : DbContext
    {
       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Policies>()
        .HasOne(p => p.InsuranceCompany)
        .WithMany(b => b.Policies)
        .HasForeignKey(p => p.Ins_Id)
        .OnDelete(DeleteBehavior.Cascade); // Changed to Cascade to enable cascading deletes

            // Configure cascading deletes for other entities if necessary
            // For example, if `Policies` has related entities that should also be deleted
            // when a `Policies` record is deleted, configure those here as well.

            // Explicit configuration for the EmpRegister to Policies relationship
            modelBuilder.Entity<EmpRegister>()
                .HasOne<Policies>(e => e.Policies) // EmpRegister has one Policies
                .WithMany(p => p.EmpRegister) // Policies has many EmpRegister
                .HasForeignKey(e => e.PolicyId); // Foreign key in EmpRegister pointing to Policies

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

       
 //Contacts in public
		public DbSet<Contact> Contact { get; set; }

        //Insurance Company 

        public DbSet<InsuranceCompany> InsuranceCompany { get; set; }

    }
}
