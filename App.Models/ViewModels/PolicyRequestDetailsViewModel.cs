using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Models.ViewModels
{
    public class PolicyRequestDetailsViewModel
    {
        //Work For Emp_id

        public int RequestId { get; set; } // Add this line to PolicyRequestDetailsViewModel


        [ValidateNever]
        public int empno { get; set; } // This will be the selected value


        [Required]
        [ValidateNever]
        public int SelectedPolicy_Id { get; set; } // This will be the selected value

        [ValidateNever]
        public IEnumerable<SelectListItem> PolicyOptions { get; set; }


        [StringLength(50)]
        [ValidateNever]
        public string SelectedStatus { get; set; } // Status of the request: "Requested", "Approved", "Disapproved".



        // This is not stored in the database, just used for the form
        [ValidateNever]
        public IEnumerable<SelectListItem> StatusOptions { get; set; }


    }
}
