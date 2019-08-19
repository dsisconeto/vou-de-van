using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using VouDeVan.Core.Business.Support;

namespace AdminPanel.TransportationCompanies
{
    public abstract class TransportationCompanyViewModel
    {
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(18, ErrorMessage = "MaxLength")]
        [MinLength(18, ErrorMessage = "MinLength")]
        public string CNPJ { get; set; }

        [Display(Name = "nome fantasia")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(50, ErrorMessage = "MaxLength")]
        public string FantasyName { get; set; }

        [Display(Name = "razão social")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(100, ErrorMessage = "MaxLength")]
        public string SocialName { get; set; }

        [Display(Name = "endereço")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(400, ErrorMessage = "MaxLength")]
        public string Address { get; set; }

        [Display(Name = "nome do representante")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(100, ErrorMessage = "MaxLength")]
        public string RepresentativeName { get; set; }

        [Display(Name = "telefone do representante")]
        [Required(ErrorMessage = "Required")]
        [MinLength(14, ErrorMessage = "MinLength")]
        [MaxLength(15, ErrorMessage = "MaxLength")]
        public string RepresentativePhone { get; set; }

        [Display(Name = "observação")]
        [MaxLength(1000, ErrorMessage = "MaxLength")]
        public string Observation { get; set; }

        [Required(ErrorMessage = "Required")] public Status Status { get; set; }


        public abstract IFormFile Logo { get; set; }

        public List<SelectListItem> Statuses { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = ((int) Status.Active).ToString(), Text = "Ativo"},
            new SelectListItem {Value = ((int) Status.Disabled).ToString(), Text = "Desabilitado"},
            new SelectListItem {Value = ((int) Status.Created).ToString(), Text = "Criado"},
        };
    }
}