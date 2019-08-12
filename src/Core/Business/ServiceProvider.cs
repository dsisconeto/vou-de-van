using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VouDeVan.Core.Business.Domains.Geo;
using VouDeVan.Core.Business.Domains.StopoverPoints;
using VouDeVan.Core.Business.Domains.TransportationCompanies;

namespace VouDeVan.Core.Business
{
    public static class ServiceProvider
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataBaseContext>(options => { options.UseSqlServer(connectionString); });
            services.AddScoped<TransportationCompanyServices>();
            services.AddScoped<StopoverPointServices>();
            services.AddScoped<CityServices>();
        }
    }
}