using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace App.Models.Models
{
    public class PolicyRequestDetails
    {
        [Key]
        public int RequestId { get; set; } // Primary key.

        [ForeignKey("EmpRegister")]
        [ValidateNever]
        [AllowNull]
        public int empno { get; set; } // Foreign key from the employees table.

        [ForeignKey("Policies")]
        [ValidateNever]
        [AllowNull]
        public int PolicyId { get; set; } // Foreign key from the policies table.

        [ValidateNever]
        [AllowNull]
        public virtual EmpRegister EmpRegister { get; set; } // Navigation property for the Employee.

        [ValidateNever]
        [AllowNull]
        public virtual Policies Policies { get; set; } // Navigation property for the Policy.

        [StringLength(50)]
        [ValidateNever]
        public string Status { get; set; } // Status of the request: "Requested", "Approved", "Disapproved".

        public DateTime RequestDate { get; set; } // Date when the request was made.
    }
}
