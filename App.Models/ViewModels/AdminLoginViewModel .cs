using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace App.Models.ViewModels
{
    public class AdminLoginViewModel
    {
        
        public int Adm_ID { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "It should be max 25 or min 3 characters.")]
        [MinLength(3, ErrorMessage = "It should be max 25 or min 3 characters.")]
        public string AdminName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("AdminPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

   

        
        [ValidateNever]
        public IFormFile AdminPhoto { get; set; }

        [Required(ErrorMessage = "Please provide an address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please provide a phone number.")]
        public string Phone { get; set; }

        public DateTime AdminAdded { get; set; } = DateTime.Now;
    }
}
