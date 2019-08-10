using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Models.TransportationCompanies
{
    public class TransportationCompanyGridViewModel
    {
        public Guid Id { get; set; }

        public string CNPJ { get; set; }

        public string FantasyName { get; set; }

        public string SocialName { get; set; }

        public string RepresentativeName { get; set; }

        public string RepresentativePhone { get; set; }

        public string Logo
        {
            get;
            set;
        }

        public string _logo;
    }
}