using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    public class CompanyDetails
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
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        [AllowNull]
        public string CompanyURL { get; set;}

        public DateTime CompanyDetailsAdded { get; set; } = DateTime.Now;

        public ICollection<Policesonemployees> Policesonemployees { get; set; }
        public ICollection<Policies> Policies { get; set; }
        public ICollection<PolicyTotalDescription> PolicyTotalDescriptions { get; set; }
        public ICollection<PolicyRequestDetails> PolicyRequestDetails { get; set; }

    }
}
