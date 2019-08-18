using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Business.Geo;
using Business.StopoverPoints;
using Business.TransportationCompanies;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Support.Providers
{
    public static class BusinessServiceProvider
    {

        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<TransportationCompanyServices>();
            services.AddScoped<StopoverPointServices>();
            services.AddScoped<CityServices>();
        }
    }
}