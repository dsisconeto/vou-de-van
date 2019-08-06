using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VouDeVan.Core.Business
{
    public static class ServiceProvider
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataBaseContext>(options => { options.UseSqlServer(connectionString); });
        }
    }
}