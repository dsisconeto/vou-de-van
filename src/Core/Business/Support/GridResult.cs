using System;
using System.Collections.Generic;
using System.Text;

namespace VouDeVan.Core.Business.Support
{
    public class GridResult<T>
    {
        public int Total { get; }
        public int RowsRowsPerPage { get; }

        public IReadOnlyList<T> Items { get; }

        public GridResult(IReadOnlyList<T> items, int total, int rowsPerPage = 10)
        {
            Items = items;
            Total = total;
            RowsRowsPerPage = rowsPerPage;
        }
    }
}