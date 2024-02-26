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
    internal class PolicyApprovalDetails
    {
        [Key]
        public int PolicyId { get; set; }

        [Required]
        [AllowNull]
        public int RequestId { get; set; }

        [Required]
        [AllowNull]
        public DateTime Date { get; set; }

        [AllowNull]
        public SqlMoney Amount { get; set; }

        [AllowNull]
        [MaxLength(3)]
        public string Status { get; set; }

        [AllowNull]
        [StringLength(50)]
        public string Reason { get; set; }
    }
}
