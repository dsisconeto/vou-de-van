using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VouDeVan.Core.Support;

namespace VouDeVan.Core.Business.Support
{
    public static class PaginateExtension
    {
        public static async Task<Paginate<T>> ToPaginate<T>(this IQueryable<T> query,
            int page, int perPage)
        {
            var paginate = new Paginate<T>()
            {
                PerPage = perPage,
                Page = page,
                Total = await query.CountAsync()
            };

            paginate.Items = await query
                .Skip(paginate.Skip)
                .Take(paginate.PerPage)
                .ToListAsync();
        }
    }
}