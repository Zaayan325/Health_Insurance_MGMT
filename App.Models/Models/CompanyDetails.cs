using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    internal class CompanyDetails
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set;}

        [Required]
        [MaxLength(150)]
        [AllowNull]
        public string Address { get; set;}

        [Required]
        [MaxLength(20)]
        [AllowNull]

        public string Phone {  get; set;}

        [Required]
        [MaxLength(50)]
        [AllowNull]
        public string CompanyURL { get; set;}
    }
}
