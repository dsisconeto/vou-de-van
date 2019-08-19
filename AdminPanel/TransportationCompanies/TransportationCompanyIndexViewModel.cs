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
    public class TransportationCompanyIndexViewModel
    {
        public string Id { get; set; }
        public string CNPJ { get; set; }
        public string FantasyName { get; set; }
        public string Status { get; set; }
        public string Logo { get; set; }

    }
}