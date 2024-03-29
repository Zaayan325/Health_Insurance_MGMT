using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    public class Policies
    {
        [Key]
        public int PolicyId { get; set; }

        [Required]
        [StringLength(50)]
        public string PolicyName { get; set; }

        [Required]
        [StringLength(150)]
        public string PolicyDescription { get; set; }

        [Required]
        public double PolicyFullAmount { get; set; }

        [Required]
        public double equatedmonthlyinstalment { get; set; }

        [Required]
        public double policymonths { get; set; }

        [AllowNull]
        public int Ins_Id { get; set; } // Foreign key property

        [AllowNull]
        [ForeignKey("Ins_Id")]
        public virtual InsuranceCompany InsuranceCompany { get; set; } // Navigation property


        [Required]
        [StringLength(50)]
        public string MedicalId { get; set; }

        [Required]
		[ValidateNever]
		public string PolicyTermasandConditionsurl { get; set; }


        [AllowNull]
        public virtual ICollection<EmpRegister> EmpRegister { get; set; } // Collection navigation property
        [AllowNull]
        public virtual ICollection<PolicyRequestDetails> PolicyRequestDetails { get; set; } // Collection navigation property
    }
}
