using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using VouDeVan.Core.Business.Support;
using Web.Support.Validations;

namespace AdminPanel.TransportationCompanies
{
    public class TransportationCompaniesEditViewModel : TransportationCompanyViewModel
    {
        public string Id { get; set; }

        [MaxFileSizeValidation(100)]
        [ImageValidation]
        public override IFormFile Logo { get; set; }
    }
}