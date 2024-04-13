using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // For IFormFile
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering; // For SelectList

namespace App.Models.ViewModels
{
    public class HospitalViewModel
    {
        public int HospitalId { get; set; }

        [Required(ErrorMessage = "Hospital name is required.")]
        [StringLength(100, ErrorMessage = "Hospital name cannot be longer than 100 characters.")]
        public string HospitalName { get; set; }

        [Required(ErrorMessage = "Hospital address is required.")]
        [StringLength(200, ErrorMessage = "Hospital address cannot be longer than 200 characters.")]
        public string HospitalAddress { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [StringLength(20, ErrorMessage = "Contact number cannot be longer than 20 characters.")]
        public string HospitalContactNo { get; set; }

        // Static, not for SelectList
        [ValidateNever]
        public int empno { get; set; }

        [ValidateNever]
        public int? PolicyId { get; set; }

        [Required(ErrorMessage = "Expense incurred is required.")]
        public double ExpenseIncurred { get; set; }

        [Display(Name = "Upload Full Bill Picture")]
        [ValidateNever]
        public IFormFile BillPictureFile { get; set; }

        [Display(Name = "Upload Documents")]
        [ValidateNever]
        public IFormFile DocumentsFile { get; set; }

        [Required(ErrorMessage = "Status report is required.")]
        public string StatusReport { get; set; }

        [ValidateNever]
        public DateTime HospitalReportSended { get; set; }

        // SelectList for StatusReport options, assuming this is dynamically populated elsewhere
        public SelectList StatusReportOptions { get; set; }

        // Constructor to initialize with current date or any defaults
        public HospitalViewModel()
        {
            HospitalReportSended = DateTime.Now;
        }
    }
}
