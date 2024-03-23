using App.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Models.ViewModels
{
    public class PoliciesVM
    {
        public Policies Policies { get; set; } = new Policies();

        [ValidateNever]
        public IEnumerable<Policies> Policy { get; set; } = new List<Policies>();

        [ValidateNever]
        public IEnumerable<SelectListItem> CompanyDetails { get; set; }
    }
}
