using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    public class HospitalInfo
    {
        [Key]
        public int HospitalId { get; set; }

        [Required]
        [AllowNull]
        [StringLength(50)]

        public string HospitalName { get; set; }

        [Required]
        [AllowNull]
        [StringLength(50)]
        public string PhoneNO { get; set; }

        [Required]
        [AllowNull]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [AllowNull]
        [StringLength(50)]
        public string Url { get; set; }

        public DateTime HospitalInfoAdded { get; set; } = DateTime.Now;

    }
}
