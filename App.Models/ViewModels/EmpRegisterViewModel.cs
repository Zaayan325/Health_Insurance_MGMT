using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models.ViewModels
{
    public class EmpRegisterViewModel
    {
        public int empno { get; set; }

        [Required]
        [StringLength(50)]
        public string designation { get; set; }

        [Required]
        public DateTime joindate { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(150)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string contactno { get; set; }

        [Required]
        [StringLength(50)]
        public string state { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [StringLength(30)]
        public string policystatus { get; set; }

        // This property is used to capture the selected PolicyId from the dropdown
        [Required]
        [ValidateNever]
        public int SelectedPolicyId { get; set; }

        // This SelectList will be used to populate the dropdown in the view
        [ValidateNever]
        public IEnumerable<SelectListItem> PolicyOptions { get; set; }


        [ValidateNever]
        public IFormFile Employee_Picture { get; set; }


        // Constructor to initialize the SelectList

        public EmpRegisterViewModel()
        {
            PolicyOptions = new List<SelectListItem>();
        }
    }
}
