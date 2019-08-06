using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using VouDeVan.Core.Business.Support;


namespace VouDeVan.App.Web.AdminPainel.Models.TransportationCompany
{
    public class TransportationCompanyViewModel
    {
        [Required] [MaxLength(14)] public string CNPJ { get; set; }

        [Required] [MaxLength(50)] public string FantasyName { get; set; }

        [Required] [MaxLength(100)] public string SocialName { get; set; }

        [Required] [MaxLength(400)] public string Address { get; set; }

        [Required] [MaxLength(100)] public string RepresentativeName { get; set; }

        [Required] [MaxLength(11)] public string RepresentativePhone { get; set; }

        [Column(TypeName = "text")]
        [MaxLength(1000)]
        public string Observation { get; set; }

        [Required] [MaxLength(40)] public Status Status { get; set; } = Status.Active;


        public List<SelectListItem> Statuses { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = ((int) Status.Active).ToString(), Text = "Ativo"},
            new SelectListItem {Value = ((int) Status.Disabled).ToString(), Text = "Desabilitado"},
            new SelectListItem {Value = ((int) Status.Created).ToString(), Text = "Criado"},
        };
    }
}