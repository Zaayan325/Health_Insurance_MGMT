﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    internal class PolicyRequestDetails
    {
        [Key]
        public int RequestId { get; set; }

        [AllowNull]
        public DateTime RequestDate { get; set; }

        public int EmpNo { get; set; }

        [AllowNull]
        public int PolicyId { get; set; }

        [AllowNull]
        [StringLength(50)]
        public string PolicyName { get; set; }

        [AllowNull]
        public SqlMoney PolicyAmount { get; set; }

        [AllowNull]
        public SqlMoney Emi { get; set;}

        [AllowNull]
        public int CompanyId { get; set; }


        [AllowNull]
        [StringLength(50)]
        public string CompanyName { get; set;}

        [StringLength(50)]
        public string Status { get; set;}
    }
}