using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VouDeVan.Core.Business.Domains.Geo;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Models.StopoverPoints
{
    public class StopoverPointsViewModel
    {
        public string Id { get; set; }

        [Required] [MaxLength(255)] public string Name { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public string CityId { get; set; }


        [Required]
        public Status Status { get; set; } = Status.Active;

        public List<SelectListItem> Statuses { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = ((int) Status.Active).ToString(), Text = "Ativo"},
            new SelectListItem {Value = ((int) Status.Disabled).ToString(), Text = "Desabilitado"},
            new SelectListItem {Value = ((int) Status.Created).ToString(), Text = "Criado"},
        };
    }
}
