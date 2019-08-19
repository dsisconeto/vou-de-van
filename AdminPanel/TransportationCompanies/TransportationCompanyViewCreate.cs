using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using VouDeVan.Core.Business.Support;
using Web.Support.Validations;

namespace AdminPanel.TransportationCompanies
{
    public class TransportationCompanyViewCreate : TransportationCompanyViewModel
    {
        [Required(ErrorMessage = "Required")]
        [MaxFileSizeValidation(100)]
        [ImageValidation]
        public override IFormFile Logo { get; set; }
    }
}