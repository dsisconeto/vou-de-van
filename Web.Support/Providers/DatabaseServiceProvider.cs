using Business;
using Business.Geo;
using Business.StopoverPoints;
using Business.TransportationCompanies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Support.Providers
{
    public static class DatabaseServiceProvider
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataBaseContext>(options => { options.UseSqlServer(connectionString); });

        
        }
    }
}