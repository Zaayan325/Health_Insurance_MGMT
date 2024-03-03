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
        [AllowNull]
        public string designation { get; set; }

        [Required]
        [AllowNull]
        public DateTime joindate { get; set; }

        [Required]
        [AllowNull]
        [Precision(7,2)]
        public decimal Salary { get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string firstname { get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string lastname { get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string username { get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string password { get; set; }

        [Required]
        [AllowNull]
        [StringLength (150)]
        public string address {  get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string contactno { get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string state {  get; set; }


        [Required]
        [AllowNull]
        [StringLength (50)]
        public string country { get; set; }

        [Required]
        [AllowNull]
        [StringLength (50)]
        public string city { get; set; }

        [Required]
        [AllowNull]
        [StringLength (30)]
        public string policystatus { get; set; }

        [Required]
        [AllowNull]
        public int Policyid { get; set; }

        public DateTime EmployeeAdded { get; set; } = DateTime.Now;


    }
}
