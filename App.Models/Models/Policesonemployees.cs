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
    internal class Policesonemployees
    {
        [StringLength(10)]
        public string empno { get; set; }

        public int policyid { get; set; }

        [StringLength(50)]
        public string policyname { get; set; }

        public SqlMoney policyamount { get; set; }

        
        public decimal Policyduration { get; set; };

    }
}
