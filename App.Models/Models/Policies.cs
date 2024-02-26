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
    internal class Policies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [AllowNull]
        [StringLength(50)]
        public string PolicyName { get; set; }

        [Required]
        [AllowNull]
        [StringLength(150)]
        public string PolicyDescription { get; set; }

        [Required,AllowNull]
        public SqlMoney Amount { get; set; }

        [Required,AllowNull]
        public SqlMoney Emi { get; set; }

        [Required,AllowNull]
        public int CompanyId { get; set; }


        [Required]
        [AllowNull]
        [StringLength(50)]
        public string MedicalId { get; set; }
    }
}
