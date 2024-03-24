using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace App.Models.ViewModels
{
	public class InsuranceCompanyViewModel
	{

        public int Ins_Id { get; set; }

        [Required(ErrorMessage = "Insurance Company Name is required!")]
		[MaxLength(100, ErrorMessage = "It can be max 100 or min 3")]
		[MinLength(3)]
		public string Ins_Name { get; set; }

		[Required(ErrorMessage = "Insurance Description is required!")]
		[MaxLength(350, ErrorMessage = "It can be max 350 or min 10")]
		[MinLength(10)]
		public string Ins_Description { get; set; }

		[Required(ErrorMessage = "Insurance Address is required!")]
		[MaxLength(200, ErrorMessage = "It can be max 200 or min 3")]
		[MinLength(3)]
		public string Address { get; set; }

		[Required(ErrorMessage = "Insurance Phone is required!")]
		[MaxLength(15, ErrorMessage = "It can be max 15 or min 10")]
		[MinLength(10)]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Insurance Company Website is required!")]
		[MaxLength(100, ErrorMessage = "It can be max 100")]
		public string CompantWebsiteUrl { get; set; }

		[Required]
		[ValidateNever]
		public IFormFile Ins_CompanyLogo { get; set; }
	}
}
