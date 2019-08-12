using System;
using System.Collections.Generic;
using System.Text;

namespace VouDeVan.Core.Support.TransportationCompanies
{
    public class TransportationCompaniesGetQuery : PaginateQuery
    {
        public string CityId { get; set; }
        public string FantasyName { get; set; }
    }
}