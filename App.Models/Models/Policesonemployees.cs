using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace App.Models.Models
{
    public class Policesonemployees
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Empno { get; set; }

        public int Policyid { get; set; }
        [ValidateNever]
        public Policies Policies { get; set; }

        [StringLength(50)]
        public string Policyname { get; set; }

        public decimal Policyamount { get; set; }

        public decimal Policyduration { get; set; }

        public decimal Emi { get; set; }

        public DateTime Pstartdate { get; set; }

        public DateTime Penddate { get; set;}

        [StringLength(30)]
        public string CompanyId { get; set; }
        [ValidateNever]
        public CompanyDetails CompanyDetails { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set;}

        [StringLength(50)]
        public string Medical { get; set;}
    }
}
