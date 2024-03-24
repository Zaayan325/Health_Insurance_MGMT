using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace App.Models.Models
{
    public class InsuranceCompany
    {
        [Key]
        public int Ins_Id { get; set; }

        [Required(ErrorMessage = "Insurance Company Name is required !")]
        [MaxLength(100, ErrorMessage = "It can be max 100 or min 3")]
        [MinLength(3)]
        public string Ins_Name { get; set; }

        [Required(ErrorMessage = "Insurance Description  is required !")]
        [MaxLength(350, ErrorMessage = "It can be max 350 or min 10")]
        [MinLength(10)]
        public string Ins_Description { get; set; }


        [Required(ErrorMessage = "Insurance Address  is required !")]
        [MaxLength(200, ErrorMessage = "It can be max 200 or min 3")]
        [MinLength(3)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Insurance Phone is required!")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "The phone number must be between 10 and 15 digits.")]
        public string Phone { get; set; } // Changed to string to hold phone numbers as text

        [Required(ErrorMessage = "Insurance Company Website is required!")]
        [MaxLength(100, ErrorMessage = "It can be max 100")]
        [Url(ErrorMessage = "Please enter a valid URL")] // Ensures the property contains a valid URL
        public string CompantWebsiteUrl { get; set; } // Changed to string to store URL


        [ValidateNever]
        [Required]
        public string Ins_CompanyLogourl { get; set; }

        public DateTime InsuranceCompanyAdded { get; set; } = DateTime.Now;



    }
}
