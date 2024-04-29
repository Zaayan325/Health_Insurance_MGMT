using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddAllToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    Adm_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPhotourl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogin", x => x.Adm_ID);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Contact_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Contact_Added = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Contact_Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompany",
                columns: table => new
                {
                    Ins_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ins_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ins_Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompantWebsiteUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ins_CompanyLogourl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompanyAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompany", x => x.Ins_Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolicyDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PolicyFullAmount = table.Column<double>(type: "float", nullable: false),
                    equatedmonthlyinstalment = table.Column<double>(type: "float", nullable: false),
                    policymonths = table.Column<double>(type: "float", nullable: false),
                    Ins_Id = table.Column<int>(type: "int", nullable: false),
                    MedicalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolicyTermasandConditionsurl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Policies_InsuranceCompany_Ins_Id",
                        column: x => x.Ins_Id,
                        principalTable: "InsuranceCompany",
                        principalColumn: "Ins_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpRegister",
                columns: table => new
                {
                    empno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    joindate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    contactno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    policystatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_Pictureurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    EmployeeAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRegister", x => x.empno);
                    table.ForeignKey(
                        name: "FK_EmpRegister_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HospitalAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HospitalContactNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    empno = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    ExpenseIncurred = table.Column<double>(type: "float", nullable: false),
                    FullBillPictureUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DocumentsUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StatusReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalReportSended = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_Hospital_EmpRegister_empno",
                        column: x => x.empno,
                        principalTable: "EmpRegister",
                        principalColumn: "empno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospital_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyRequestDetails",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empno = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpRegisterempno = table.Column<int>(type: "int", nullable: true),
                    PoliciesPolicyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRequestDetails", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_PolicyRequestDetails_EmpRegister_EmpRegisterempno",
                        column: x => x.EmpRegisterempno,
                        principalTable: "EmpRegister",
                        principalColumn: "empno");
                    table.ForeignKey(
                        name: "FK_PolicyRequestDetails_EmpRegister_empno",
                        column: x => x.empno,
                        principalTable: "EmpRegister",
                        principalColumn: "empno");
                    table.ForeignKey(
                        name: "FK_PolicyRequestDetails_Policies_PoliciesPolicyId",
                        column: x => x.PoliciesPolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId");
                    table.ForeignKey(
                        name: "FK_PolicyRequestDetails_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId");
                });

            migrationBuilder.InsertData(
                table: "AdminLogin",
                columns: new[] { "Adm_ID", "Address", "AdminAdded", "AdminName", "AdminPassword", "AdminPhotourl", "ConfirmPassword", "Email", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "123 Admin St, Admin City", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7476), "Syed Kashan Abbas Naqvi", "kashan110", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "kashan110", "kashan2209e@aptechgdn.net", "1234567890", "Admin" },
                    { 2, "456 Admin Lane, Admin Town", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7479), "Asghar Abbas", "asghar110", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "asghar110", "asghar2209e@aptechgdn.net", "0987654321", "Admin" },
                    { 3, "456 Admin Lane, Admin Town", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7481), "Ali Shan", "alishan110", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "alishan110", "alishan2209e@aptechgdn.net", "0987654321", "Admin" },
                    { 4, "456 Admin Lane, Admin Town", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7483), "Zayaan Zubair", "zaayan110", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "zaayan110", "zaayan220901e@aptechgdn.net", "0987654321", "Admin" },
                    { 5, "456 Admin Lane, Admin Town", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7485), "Waleed Hoth", "waleed110", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "waleed110", "waleed2209e@aptechgdn.net", "0987654321", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceCompany",
                columns: new[] { "Ins_Id", "Address", "CompantWebsiteUrl", "Ins_CompanyLogourl", "Ins_Description", "Ins_Name", "InsuranceCompanyAdded", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Insurance Lane", "https://www.healthguard.com", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "Comprehensive health insurance for all your needs.", "HealthGuard", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7254), "1234567890" },
                    { 2, "123 Insurance Lane", "https://www.healthguard.com", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "Comprehensive health i for all your needs.", "HealtyLife", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7267), "1234567890" },
                    { 3, "12334 Insurance Lane", "https://www.healthguard.com", "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", "Life is Great do all Work.", "Pure Life", new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7269), "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "Ins_Id", "MedicalId", "PolicyDescription", "PolicyFullAmount", "PolicyName", "PolicyTermasandConditionsurl", "equatedmonthlyinstalment", "policymonths" },
                values: new object[,]
                {
                    { 1, 1, "MED123", "Covers all medical expenses for your family.", 500000.0, "Family Health Plan", "~/documents/Instagram for Business Guide 2023.pdf", 15000.0, 36.0 },
                    { 2, 2, "MED234", "Personal health insurance plan for individuals.", 200000.0, "Individual Health Plan", "~/documents/Instagram for Business Guide 2023.pdf", 5500.0, 24.0 },
                    { 3, 2, "MED345", "Comprehensive dental care for families and individuals.", 100000.0, "Dental Care Plan", "~/documents/Instagram for Business Guide 2023.pdf", 4000.0, 12.0 },
                    { 4, 3, "MED456", "Insurance coverage for eye care and vision health.", 75000.0, "Vision Care Plan", "~/documents/Instagram for Business Guide 2023.pdf", 3100.0, 12.0 },
                    { 5, 1, "MED567", "Emergency health coverage for unexpected medical needs.", 300000.0, "Emergency Health Plan", "~/documents/Instagram for Business Guide 2023.pdf", 8300.0, 18.0 }
                });

            migrationBuilder.InsertData(
                table: "EmpRegister",
                columns: new[] { "empno", "EmployeeAdded", "Employee_Pictureurl", "PolicyId", "Role", "Salary", "address", "city", "contactno", "country", "designation", "firstname", "joindate", "lastname", "password", "policystatus", "state", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7432), "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", 1, "Employee", 80000, "456 Developer Rd.", "DevCity", "0987654321", "TechLand", "Software Engineer", "John", new DateTime(2024, 1, 4, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7434), "Doe", "kashan110", "Active", "TechState", "johndoe" },
                    { 2, new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7443), "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", 2, "Employee", 95000, "789 Project Blvd.", "ManageCity", "1234567890", "LeadLand", "Project Manager", "Alice", new DateTime(2023, 9, 26, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7444), "Johnson", "securepassword", "Active", "ManageState", "alicejohnson" },
                    { 3, new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7447), "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", 3, "Employee", 70000, "101 QA Lane", "TestCity", "2345678901", "QualityLand", "QA Engineer", "Bob", new DateTime(2023, 11, 15, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7448), "Smith", "testpassword", "Active", "TestState", "bobsmith" },
                    { 4, new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7450), "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", 2, "Employee", 85000, "404 DevOps Way", "OpsCity", "3456789012", "DeployLand", "DevOps Specialist", "Carol", new DateTime(2023, 12, 15, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7451), "Williams", "devopspass", "Active", "OpsState", "carolw" },
                    { 5, new DateTime(2024, 4, 13, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7453), "4799de3c-69c5-442c-813c-9d166c2d30dd_catpicture.jpg", 1, "Employee", 75000, "202 Design St.", "DesignCity", "4567890123", "CreativeLand", "UI/UX Designer", "Dave", new DateTime(2023, 10, 16, 1, 7, 16, 462, DateTimeKind.Local).AddTicks(7453), "Brown", "designpass", "Active", "DesignState", "davebrown" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpRegister_PolicyId",
                table: "EmpRegister",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_empno",
                table: "Hospital",
                column: "empno");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_PolicyId",
                table: "Hospital",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_Ins_Id",
                table: "Policies",
                column: "Ins_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRequestDetails_empno",
                table: "PolicyRequestDetails",
                column: "empno");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRequestDetails_EmpRegisterempno",
                table: "PolicyRequestDetails",
                column: "EmpRegisterempno");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRequestDetails_PoliciesPolicyId",
                table: "PolicyRequestDetails",
                column: "PoliciesPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRequestDetails_PolicyId",
                table: "PolicyRequestDetails",
                column: "PolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "PolicyRequestDetails");

            migrationBuilder.DropTable(
                name: "EmpRegister");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "InsuranceCompany");
        }
    }
}
