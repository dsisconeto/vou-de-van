using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using VouDeVan.Core.Business.Support;
using Web.Support.Validations;

namespace AdminPanel.TransportationCompanies
{
    public class TransportationCompanyViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Required"), MaxLength(18), MinLength(18)]
        public string CNPJ { get; set; }

        [Required, MaxLength(50), Display(Name = "Nome Fantasia")]
        public string FantasyName { get; set; }

        [Required, MaxLength(100), Display(Name = "Razão Social")]
        public string SocialName { get; set; }

        [Required, MaxLength(400), Display(Name = "Endereço")]
        public string Address { get; set; }

        [Required, MaxLength(100), Display(Name = "Nome do Representante")]
        public string RepresentativeName { get; set; }

        [Required, MinLength(14), MaxLength(15), Display(Name = "Telefone do Representante")]
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


        [Required, MaxFileSizeValidation(100), ImageValidation]
        public IFormFile Logo { get; set; }
    }
}