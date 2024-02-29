using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    public class PolicyTotalDescription
    {
        [Key]
        public int Id { get; set; }
        
        public int policyId { get; set; }
        [ValidateNever]
        public PolicyRequestDetails PolicyRequestDetails { get; set; }

        [AllowNull]
        [StringLength(50)]
        public string Policyname { get; set; }

        [AllowNull]
        [StringLength(250)]
        public string Policydes { get; set; }

        [AllowNull]
        public decimal policyamount { get; set; }

        [AllowNull]
        public decimal EMI {  get; set; }

        [AllowNull]
        public int PolicyDurationMonths { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string MedicalId { get; set; }
    }
}
