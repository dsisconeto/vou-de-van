using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Models.TransportationCompanies
{
    public class TransportationCompanyViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Required"), MaxLength(18)]
        public string CNPJ { get; set; }

        [Required, MaxLength(50), Display(Name = "Nome Fantasia")]
        public string FantasyName { get; set; }

        [Required, MaxLength(100), Display(Name = "Razão Social")]
        public string SocialName { get; set; }

        [Required, MaxLength(400), Display(Name = "Endereço")]
        public string Address { get; set; }

        [Required, MaxLength(100), Display(Name = "Nome do Representante")]
        public string RepresentativeName { get; set; }

        [Required, MaxLength(15), Display(Name = "Telefone do Representante")]
        public string RepresentativePhone { get; set; }

        [MaxLength(1000), Display(Name = "Observação")]
        public string Observation { get; set; }

        [Required] public Status Status { get; set; } = Status.Active;

        public List<SelectListItem> Statuses { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = ((int) Status.Active).ToString(), Text = "Ativo"},
            new SelectListItem {Value = ((int) Status.Disabled).ToString(), Text = "Desabilitado"},
            new SelectListItem {Value = ((int) Status.Created).ToString(), Text = "Criado"},
        };

        [Required] public IFormFile Logo { get; set; }

        public bool LogoSizeIsValid => Logo != null && Logo.Length > 0 && Logo.Length < 10000;
    }
}