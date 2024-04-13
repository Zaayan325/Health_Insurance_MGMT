using Microsoft.AspNetCore.Http;
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
    public class EmpRegister
    {
        [Key]
        public int empno { get; set; }

        [Required]
        [StringLength(50)]
        public string designation { get; set; }

        [Required]
        public DateTime joindate { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string firstname { get; set; }

        [Required]
        [StringLength (50)]
        public string lastname { get; set; }

        [Required]
        [StringLength (50)]
        public string username { get; set; }

        [Required]
        [StringLength (50)]
        public string password { get; set; }

        [Required]
        [StringLength (150)]
        public string address {  get; set; }

        [Required]
        [StringLength (50)]
        public string contactno { get; set; }

        [Required]
        [StringLength (50)]
        public string state {  get; set; }


        [Required]
        [StringLength (50)]
        public string country { get; set; }

        [Required]
        [StringLength (50)]
        public string city { get; set; }

        [Required]
        [StringLength (30)]
        public string? policystatus { get; set; }

		[Required]
		public string Role { get; set; } = "Employee"; // Default to "Employee"

        
        [ValidateNever]
        public string Employee_Pictureurl { get; set; }

        [AllowNull]
        public int PolicyId { get; set; } // Foreign key property

        [AllowNull]
        [ForeignKey("PolicyId")]
        public virtual Policies Policies { get; set; } // Navigation property
        [AllowNull]
        public virtual ICollection<PolicyRequestDetails> PolicyRequestDetails { get; set; } // Collection navigation property

        [AllowNull]
        public virtual ICollection<Hospital> Hospital { get; set; }


        public DateTime EmployeeAdded { get; set; } = DateTime.Now;

    }
}
