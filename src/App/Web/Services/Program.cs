using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace VouDeVan.App.Web.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }


    enum Status
    {
        Active,
        Disabled
    }
}
