using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                name: "CompanyDetails",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyURL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyDetailsAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.CompanyId);
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
                name: "HospitalInfo",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HospitalInfoAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalInfo", x => x.HospitalId);
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

            migrationBuilder.CreateIndex(
                name: "IX_EmpRegister_PolicyId",
                table: "EmpRegister",
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
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "HospitalInfo");

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
