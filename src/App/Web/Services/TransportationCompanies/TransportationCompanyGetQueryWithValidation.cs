using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VouDeVan.App.Web.Services.TransportationCompanies
{
    public class TransportationCompanyGetQueryWithValidation
    {
        [Required] public int Page { get; set; }
        [Required] public int PerPage { get; set; }
        public string FantasyName { get; set; }
        public string CityId { get; set; }
    }
}