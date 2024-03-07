using System;
﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Engine;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Models
{
    public class Policesonemployees
    {
        [Key]
        [StringLength(10)]
        public string empno { get; set; }

        public int policyid { get; set; }

        [StringLength(50)]
        public string policyname { get; set; }


        public int policyamount { get; set; }

        
        public int Policyduration { get; set; }

        public int Emi { get; set; }

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
