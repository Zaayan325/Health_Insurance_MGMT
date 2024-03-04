using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogins",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogins", x => x.UserName);
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
                name: "EmpRegister",
                columns: table => new
                {
                    empno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    joindate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
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
                    Policyid = table.Column<int>(type: "int", nullable: false),
                    EmployeeAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRegister", x => x.empno);
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
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolicyDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Emi = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyDetailsCompanyId = table.Column<int>(type: "int", nullable: false),
                    MedicalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_CompanyDetails_CompanyDetailsCompanyId",
                        column: x => x.CompanyDetailsCompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policesonemployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empno = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Policyid = table.Column<int>(type: "int", nullable: false),
                    PoliciesId = table.Column<int>(type: "int", nullable: true),
                    Policyname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Policyamount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Policyduration = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Emi = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Pstartdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Penddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CompanyDetailsCompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Medical = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policesonemployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policesonemployees_CompanyDetails_CompanyDetailsCompanyId",
                        column: x => x.CompanyDetailsCompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policesonemployees_Policies_PoliciesId",
                        column: x => x.PoliciesId,
                        principalTable: "Policies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PolicyRequestDetails",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpNo = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    PoliciesId = table.Column<int>(type: "int", nullable: false),
                    PolicyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolicyAmount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Emi = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyDetailsCompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRequestDetails", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_PolicyRequestDetails_CompanyDetails_CompanyDetailsCompanyId",
                        column: x => x.CompanyDetailsCompanyId,
                        principalTable: "CompanyDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyRequestDetails_Policies_PoliciesId",
                        column: x => x.PoliciesId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyApprovalDetails",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliciesId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    RequestDetailsRequestId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyApprovalDetails", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_PolicyApprovalDetails_Policies_PoliciesId",
                        column: x => x.PoliciesId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyApprovalDetails_PolicyRequestDetails_RequestDetailsRequestId",
                        column: x => x.RequestDetailsRequestId,
                        principalTable: "PolicyRequestDetails",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTotalDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    policyId = table.Column<int>(type: "int", nullable: false),
                    PolicyRequestDetailsRequestId = table.Column<int>(type: "int", nullable: false),
                    Policyname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Policydes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    policyamount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    EMI = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    PolicyDurationMonths = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MedicalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTotalDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyTotalDescription_PolicyRequestDetails_PolicyRequestDetailsRequestId",
                        column: x => x.PolicyRequestDetailsRequestId,
                        principalTable: "PolicyRequestDetails",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policesonemployees_CompanyDetailsCompanyId",
                table: "Policesonemployees",
                column: "CompanyDetailsCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policesonemployees_PoliciesId",
                table: "Policesonemployees",
                column: "PoliciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_CompanyDetailsCompanyId",
                table: "Policies",
                column: "CompanyDetailsCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyApprovalDetails_PoliciesId",
                table: "PolicyApprovalDetails",
                column: "PoliciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyApprovalDetails_RequestDetailsRequestId",
                table: "PolicyApprovalDetails",
                column: "RequestDetailsRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRequestDetails_CompanyDetailsCompanyId",
                table: "PolicyRequestDetails",
                column: "CompanyDetailsCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRequestDetails_PoliciesId",
                table: "PolicyRequestDetails",
                column: "PoliciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTotalDescription_PolicyRequestDetailsRequestId",
                table: "PolicyTotalDescription",
                column: "PolicyRequestDetailsRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogins");

            migrationBuilder.DropTable(
                name: "EmpRegister");

            migrationBuilder.DropTable(
                name: "HospitalInfo");

            migrationBuilder.DropTable(
                name: "Policesonemployees");

            migrationBuilder.DropTable(
                name: "PolicyApprovalDetails");

            migrationBuilder.DropTable(
                name: "PolicyTotalDescription");

            migrationBuilder.DropTable(
                name: "PolicyRequestDetails");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "CompanyDetails");
        }
    }
}
