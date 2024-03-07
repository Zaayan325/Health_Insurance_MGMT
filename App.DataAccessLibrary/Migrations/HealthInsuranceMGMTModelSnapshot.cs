﻿// <auto-generated />
using System;
using App.DataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.DataAccessLibrary.Migrations
{
    [DbContext(typeof(HealthInsuranceMGMT))]
    partial class HealthInsuranceMGMTModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Models.Models.AdminLogin", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("AdminAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserName");

                    b.ToTable("AdminLogins");
                });

            modelBuilder.Entity("App.Models.Models.CompanyDetails", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CompanyDetailsAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyURL")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CompanyId");

                    b.ToTable("CompanyDetails");
                });

            modelBuilder.Entity("App.Models.Models.EmpRegister", b =>
                {
                    b.Property<int>("empno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empno"));

                    b.Property<DateTime>("EmployeeAdded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Policyid")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("contactno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("joindate")
                        .HasColumnType("datetime2");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("policystatus")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("empno");

                    b.ToTable("EmpRegister");
                });

            modelBuilder.Entity("App.Models.Models.HospitalInfo", b =>
                {
                    b.Property<int>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalId"));

                    b.Property<DateTime>("HospitalInfoAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNO")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HospitalId");

                    b.ToTable("HospitalInfo");
                });

            modelBuilder.Entity("App.Models.Models.Policesonemployees", b =>
                {
                    b.Property<string>("empno")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("CompanyDetailsCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Emi")
                        .HasColumnType("int");

                    b.Property<string>("Medical")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Penddate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Policyduration")
                        .HasColumnType("int");

                    b.Property<DateTime>("Pstartdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("policyamount")
                        .HasColumnType("int");

                    b.Property<int>("policyid")
                        .HasColumnType("int");

                    b.Property<string>("policyname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("empno");

                    b.HasIndex("CompanyDetailsCompanyId");

                    b.ToTable("Policesonemployees");
                });

            modelBuilder.Entity("App.Models.Models.Policies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CompanyDetailsCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Emi")
                        .HasColumnType("int");

                    b.Property<string>("MedicalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PolicyDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PolicyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyDetailsCompanyId");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("App.Models.Models.PolicyApprovalDetails", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PoliciesId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("PolicyId");

                    b.HasIndex("PoliciesId");

                    b.HasIndex("RequestId");

                    b.ToTable("PolicyApprovalDetails");
                });

            modelBuilder.Entity("App.Models.Models.PolicyRequestDetails", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<int>("CompanyDetailsCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Emi")
                        .HasColumnType("int");

                    b.Property<int>("EmpNo")
                        .HasColumnType("int");

                    b.Property<int>("PolicyAmount")
                        .HasColumnType("int");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.Property<string>("PolicyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RequestId");

                    b.HasIndex("CompanyDetailsCompanyId");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicyRequestDetails");
                });

            modelBuilder.Entity("App.Models.Models.PolicyTotalDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EMI")
                        .HasColumnType("int");

                    b.Property<string>("MedicalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PolicyDurationMonths")
                        .HasColumnType("int");

                    b.Property<int>("PolicyRequestDetailsRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Policydes")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Policyname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("policyId")
                        .HasColumnType("int");

                    b.Property<int>("policyamount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolicyRequestDetailsRequestId");

                    b.ToTable("PolicyTotalDescription");
                });

            modelBuilder.Entity("App.Models.Models.Policesonemployees", b =>
                {
                    b.HasOne("App.Models.Models.CompanyDetails", "CompanyDetails")
                        .WithMany()
                        .HasForeignKey("CompanyDetailsCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyDetails");
                });

            modelBuilder.Entity("App.Models.Models.Policies", b =>
                {
                    b.HasOne("App.Models.Models.CompanyDetails", "CompanyDetails")
                        .WithMany()
                        .HasForeignKey("CompanyDetailsCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyDetails");
                });

            modelBuilder.Entity("App.Models.Models.PolicyApprovalDetails", b =>
                {
                    b.HasOne("App.Models.Models.Policies", "Policies")
                        .WithMany()
                        .HasForeignKey("PoliciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Models.PolicyRequestDetails", "RequestDetails")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Policies");

                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("App.Models.Models.PolicyRequestDetails", b =>
                {
                    b.HasOne("App.Models.Models.CompanyDetails", "CompanyDetails")
                        .WithMany()
                        .HasForeignKey("CompanyDetailsCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Models.Policies", "Policies")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CompanyDetails");

                    b.Navigation("Policies");
                });

            modelBuilder.Entity("App.Models.Models.PolicyTotalDescription", b =>
                {
                    b.HasOne("App.Models.Models.PolicyRequestDetails", "PolicyRequestDetails")
                        .WithMany()
                        .HasForeignKey("PolicyRequestDetailsRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PolicyRequestDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
