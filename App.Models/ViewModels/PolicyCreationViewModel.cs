using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//

namespace App.Models.ViewModels
{
	public class PolicyCreationViewModel
	{
		[Required]
		[StringLength(50)]
		public string PolicyName { get; set; }

		[Required]
		[StringLength(150)]
		public string PolicyDescription { get; set; }

		[Required]
		public double PolicyFullAmount { get; set; }

		[Required]
		public double EquatedMonthlyInstalment { get; set; }

		[Required]
		public double PolicyMonths { get; set; }

        //[Required]
        //public int SelectedInsuranceCompanyId { get; set; }

        //[ValidateNever]
        //public IEnumerable<> InsuranceCompanies { get; set; }

        [Required]
		[ValidateNever]
        public int SelectedIns_Id { get; set; } // This will be the selected value

		[ValidateNever]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> InsuranceCompanies { get; set; } 




        [Required]
		[StringLength(50)]
		public string MedicalId { get; set; }

        [ValidateNever]
        public IFormFile PolicyTermsAndConditions { get; set; } // For file upload
	}
}
