using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace App.Models.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }

        [Required]
        [StringLength(100)]
        public string HospitalName { get; set; }

        [Required]
        [StringLength(200)]
        public string HospitalAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string HospitalContactNo { get; set; }

        // Foreign key for Employee
        [ForeignKey("EmpRegister")]
        [AllowNull]
        [ValidateNever]
        public int empno { get; set; }
        [AllowNull]
        [ValidateNever]
        public virtual EmpRegister EmpRegister { get; set; }

        // Foreign key for Policy
        [ForeignKey("Policies")]
        [AllowNull]
        [ValidateNever]
        public int? PolicyId { get; set; }
        [AllowNull]
        [ValidateNever]
        public virtual Policies Policies { get; set; }

        [Required]
        public double ExpenseIncurred { get; set; }

        [StringLength(255)]
        [ValidateNever]
        public string FullBillPictureUrl { get; set; }

        [StringLength(255)]
        [ValidateNever]
        public string DocumentsUrl { get; set; }

        [Required]
        public string StatusReport { get; set; }

        public DateTime HospitalReportSended { get; set; } = DateTime.Now;
    }
}
