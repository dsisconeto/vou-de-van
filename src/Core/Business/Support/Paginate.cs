using System;
using System.Collections.Generic;
using System.Text;

namespace VouDeVan.Core.Business.Support
{
    public class Paginate<T>
    {
        public int Total { get; set; }

        public int PerPage { get; set; }

        public List<T> Items { get; set; }


        public Paginate(List<T> items, int total, int perPage = 10)
        {
            Items = items;
            Total = total;
            PerPage = perPage;
        }
    }
}
