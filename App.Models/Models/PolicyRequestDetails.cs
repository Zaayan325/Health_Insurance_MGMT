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
    public class PolicyRequestDetails
    {
        [Key]
        public int RequestId { get; set; }

        [AllowNull]
        public DateTime RequestDate { get; set; }

        public int EmpNo { get; set; }

        [AllowNull]
        public int PolicyId { get; set; }
        [ValidateNever]
        public Policies Policies { get; set; }

        [AllowNull]
        [StringLength(50)]
        public string PolicyName { get; set; }

        [AllowNull]
        public int PolicyAmount { get; set; }

        [AllowNull]
        public int Emi { get; set;}

        [AllowNull]
        public int CompanyId { get; set; }
        [ValidateNever]
        public CompanyDetails CompanyDetails { get; set; }

        [StringLength(50)]
        public string Status { get; set;}

        public ICollection<PolicyTotalDescription> PolicyTotalDescriptions { get; set; }
        public ICollection<PolicyApprovalDetails> PolicyApprovalDetails { get; set; }
    }
}
