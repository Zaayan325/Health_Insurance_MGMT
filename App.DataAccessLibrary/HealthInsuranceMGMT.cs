using Microsoft.EntityFrameworkCore;
using App.Models.Models;
using System.Numerics;


namespace App.DataAccessLibrary
{
    public class HealthInsuranceMGMT : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceCompany>().HasData(
      new InsuranceCompany
      {
          Ins_Id = 1,
          Ins_Name = "HealthGuard",
          Ins_Description = "Comprehensive health insurance for all your needs.",
          Address = "123 Insurance Lane",
          Phone = "1234567890",
          CompantWebsiteUrl = "https://www.healthguard.com",
          Ins_CompanyLogourl = "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg"

      },  new InsuranceCompany
      {
          Ins_Id = 2,
          Ins_Name = "HealtyLife",
          Ins_Description = "Comprehensive health i for all your needs.",
          Address = "123 Insurance Lane",
          Phone = "1234567890",
          CompantWebsiteUrl = "https://www.healthguard.com",
          Ins_CompanyLogourl = "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg"


      }, new InsuranceCompany
      {
          Ins_Id = 3,
          Ins_Name = "Pure Life",
          Ins_Description = "Life is Great do all Work.",
          Address = "12334 Insurance Lane",
          Phone = "1234567890",
          CompantWebsiteUrl = "https://www.healthguard.com",
          Ins_CompanyLogourl = "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg"


      }

  // Add more as needed
  );

            // Seed Policies
            modelBuilder.Entity<Policies>().HasData(
     new Policies
     {
         PolicyId = 1,
         PolicyName = "Family Health Plan",
         PolicyDescription = "Covers all medical expenses for your family.",
         PolicyFullAmount = 500000,
         equatedmonthlyinstalment = 15000,
         policymonths = 36,
         Ins_Id = 1, // Ensure this matches an existing InsuranceCompany
         MedicalId = "MED123",
         PolicyTermasandConditionsurl = "~/documents/Instagram for Business Guide 2023.pdf"
     },
     new Policies
     {
         PolicyId = 2,
         PolicyName = "Individual Health Plan",
         PolicyDescription = "Personal health insurance plan for individuals.",
         PolicyFullAmount = 200000,
         equatedmonthlyinstalment = 5500,
         policymonths = 24,
         Ins_Id = 2, // Assuming this InsuranceCompany exists
         MedicalId = "MED234",
         PolicyTermasandConditionsurl = "~/documents/Instagram for Business Guide 2023.pdf"
     },
     new Policies
     {
         PolicyId = 3,
         PolicyName = "Dental Care Plan",
         PolicyDescription = "Comprehensive dental care for families and individuals.",
         PolicyFullAmount = 100000,
         equatedmonthlyinstalment = 4000,
         policymonths = 12,
         Ins_Id = 2,
         MedicalId = "MED345",
         PolicyTermasandConditionsurl = "~/documents/Instagram for Business Guide 2023.pdf"
     },
     new Policies
     {
         PolicyId = 4,
         PolicyName = "Vision Care Plan",
         PolicyDescription = "Insurance coverage for eye care and vision health.",
         PolicyFullAmount = 75000,
         equatedmonthlyinstalment = 3100,
         policymonths = 12,
         Ins_Id = 3,
         MedicalId = "MED456",
         PolicyTermasandConditionsurl = "~/documents/Instagram for Business Guide 2023.pdf"
     },
     new Policies
     {
         PolicyId = 5,
         PolicyName = "Emergency Health Plan",
         PolicyDescription = "Emergency health coverage for unexpected medical needs.",
         PolicyFullAmount = 300000,
         equatedmonthlyinstalment = 8300,
         policymonths = 18,
         Ins_Id = 1,
         MedicalId = "MED567",
         PolicyTermasandConditionsurl = "~/documents/Instagram for Business Guide 2023.pdf"
     }
 );


            // Seed EmpRegister
            modelBuilder.Entity<EmpRegister>().HasData(
     new EmpRegister
     {
         empno = 1,
         designation = "Software Engineer",
         joindate = DateTime.Now.AddDays(-100), // Example of how to set different join dates
         Salary = 80000,
         firstname = "John",
         lastname = "Doe",
         username = "johndoe",
         password = "password", // Note: In a real application, store a hashed password
         address = "456 Developer Rd.",
         contactno = "0987654321",
         state = "TechState",
         Employee_Pictureurl = "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg",
         country = "TechLand",
         city = "DevCity",
         policystatus = "Active",
         PolicyId = 1 // Assuming this policy exists
     },
     new EmpRegister
     {
         empno = 2,
         designation = "Project Manager",
         joindate = DateTime.Now.AddDays(-200),
         Salary = 95000,
         firstname = "Alice",
         lastname = "Johnson",
         username = "alicejohnson",
         password = "securepassword", // Reminder about hashed passwords
         address = "789 Project Blvd.",
         contactno = "1234567890",
         state = "ManageState",
         Employee_Pictureurl = "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg",
         country = "LeadLand",
         city = "ManageCity",
         policystatus = "Active",
         PolicyId = 2
     },
     new EmpRegister
     {
         empno = 3,
         designation = "QA Engineer",
         joindate = DateTime.Now.AddDays(-150),
         Salary = 70000,
         firstname = "Bob",
         lastname = "Smith",
         username = "bobsmith",
         password = "testpassword", // Reminder about hashed passwords
         address = "101 QA Lane",
         contactno = "2345678901",
         state = "TestState",
         Employee_Pictureurl =  "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg",
         country = "QualityLand",
         city = "TestCity",
         policystatus = "Active",
         PolicyId = 3
     },
     new EmpRegister
     {
         empno = 4,
         designation = "DevOps Specialist",
         joindate = DateTime.Now.AddDays(-120),
         Salary = 85000,
         firstname = "Carol",
         lastname = "Williams",
         username = "carolw",
         password = "devopspass", // Reminder about hashed passwords
         address = "404 DevOps Way",
         contactno = "3456789012",
         state = "OpsState",
         Employee_Pictureurl =  "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg",
         country = "DeployLand",
         city = "OpsCity",
         policystatus = "Active",
         PolicyId = 2
     },
     new EmpRegister
     {
         empno = 5,
         designation = "UI/UX Designer",
         joindate = DateTime.Now.AddDays(-180),
         Salary = 75000,
         firstname = "Dave",
         lastname = "Brown",
         username = "davebrown",
         password = "designpass", // Reminder about hashed passwords
         address = "202 Design St.",
         contactno = "4567890123",
         state = "DesignState",
         country = "CreativeLand",
         city = "DesignCity",
         policystatus = "Active",
         Employee_Pictureurl =  "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg",
         PolicyId = 1
     }
 );

            modelBuilder.Entity<AdminLogin>().HasData(
       new AdminLogin
       {
           Adm_ID = 1,
           AdminName = "Syed Kashan Abbas Naqvi",
           Email = "kashan2209e@aptechgdn.net",
           AdminPassword = "kashan110", // Consider using a hashed password in production
           ConfirmPassword = "kashan110", // Should be the same as AdminPassword for seeding
           AdminPhotourl =  "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", // Placeholder URL
           Role = "Admin",
           Address = "123 Admin St, Admin City",
           Phone = "1234567890",
           AdminAdded = DateTime.Now
       },
       new AdminLogin
       {
           Adm_ID = 2,
           AdminName = "Asghar Abbas",
           Email = "asghar2209e@aptechgdn.net",
           AdminPassword = "asghar110", // Consider using a hashed password in production
           ConfirmPassword = "asghar110", // Should be the same as AdminPassword for seeding
           AdminPhotourl =  "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", // Placeholder URL
           Role = "Admin",
           Address = "456 Admin Lane, Admin Town",
           Phone = "0987654321",
           AdminAdded = DateTime.Now
       }
       ,
       new AdminLogin
       {
           Adm_ID = 3,
           AdminName = "Ali Shan",
           Email = "alishan2209e@aptechgdn.net",
           AdminPassword = "alishan110", // Consider using a hashed password in production
           ConfirmPassword = "alishan110", // Should be the same as AdminPassword for seeding
           AdminPhotourl =  "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", // Placeholder URL
           Role = "Admin",
           Address = "456 Admin Lane, Admin Town",
           Phone = "0987654321",
           AdminAdded = DateTime.Now
       }
       ,
       new AdminLogin
       {
           Adm_ID = 4,
           AdminName = "Zayaan Zubair",
           Email = "zaayan220901e@aptechgdn.net",
           AdminPassword = "zaayan110", // Consider using a hashed password in production
           ConfirmPassword = "zaayan110", // Should be the same as AdminPassword for seeding
           AdminPhotourl =  "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", // Placeholder URL
           Role = "Admin",
           Address = "456 Admin Lane, Admin Town",
           Phone = "0987654321",
           AdminAdded = DateTime.Now
       },
       new AdminLogin
       {
           Adm_ID = 5,
           AdminName = "Waleed Hoth",
           Email = "waleed2209e@aptechgdn.net",
           AdminPassword = "waleed110", // Consider using a hashed password in production
           ConfirmPassword = "waleed110", // Should be the same as AdminPassword for seeding
           AdminPhotourl = "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", // Placeholder URL
           Role = "Admin",
           Address = "456 Admin Lane, Admin Town",
           Phone = "0987654321",
           AdminAdded = DateTime.Now
       }
   // Add more admins as needed
   );

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
