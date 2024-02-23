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
    internal class EmpRegister
    {
        [Key]
        public int empno { get; set; }

        [Required]
        [StringLength(50)]
        [AllowNull]
        public string designation { get; set; }

        [Required]
        [AllowNull]
        public DateTime joindate { get; set; }

        [Required]
        [AllowNull]

        public SqlMoney salary { get; set; }
    }
}
