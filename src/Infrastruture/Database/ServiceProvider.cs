using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VouDeVan.Core.Business.TransportationCompanies;
using VouDeVan.Infrastructure.Database.TransportationCompanies;

namespace VouDeVan.Infrastructure.Database
{
    public static class ServiceProvider
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            var mapper = MakeAutoMapper();
            services.AddDbContext<DataBaseContext>(options => { options.UseSqlServer(connectionString); });
            AddTransportationCompanies(services, mapper);
        }

        public static void AddTransportationCompanies(IServiceCollection services, IMapper mapper)
        {
            services.AddSingleton<IDataMapper<TransportationCompany, TransportationCompanyDataRow>>((options)
                => new TransportationCompanyDataMapper(
                    (TransportationCompanyFactory) options.GetService(typeof(TransportationCompanyFactory)),
                    mapper)
            );

            services.AddScoped<ITransportationCompanyRepository, TransportationCompanyRepository>();
        }

        public static IMapper MakeAutoMapper()
        {
            var mappingConfig = MakeMapperConfiguration();

            return mappingConfig.CreateMapper();
        }


        public static MapperConfiguration MakeMapperConfiguration()
        {
            return new MapperConfiguration(mc => { mc.AddProfile(new TransportationCompanyProfile()); });
        }
    }
}