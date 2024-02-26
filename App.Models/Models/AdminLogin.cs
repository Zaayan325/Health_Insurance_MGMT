using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    internal class AdminLogin
    {
        [Key]
        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        public DateTime AdminAdded { get; set; } = DateTime.Now;
    }
}
