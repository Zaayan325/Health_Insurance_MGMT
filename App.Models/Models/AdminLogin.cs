﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace App.Models.Models
{
    public class AdminLogin
    {
        [Key]
        public int  Adm_ID { get; set; }

       
        [Required]
        [MaxLength(25,ErrorMessage ="It should be max 25 or min 3")]
        [MinLength(3)]
        public string AdminName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("AdminPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [ValidateNever]
        public string AdminPhotourl { get; set; }

		[Required]
		public string Role { get; set; } = "Admin"; // Default to "Admin"

		[Required]
        public string Address { get; set; }    
        
        [Required]
        public string Phone { get; set; }

        public DateTime AdminAdded { get; set; } = DateTime.Now;
    }
}
