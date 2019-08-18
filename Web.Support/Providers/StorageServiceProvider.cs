using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage;

namespace Web.Support.Providers
{
    public static class StorageServiceProvider
    {

        public static void AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<IStorage>(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();

                var driverString = configuration.GetSection("Storage").GetSection("Driver").Value;
                var driver = Enum.Parse<StorageDriverEnum>(driverString);

                if (driver.IsAzure())
                {
                    return AddAzure(provider);
                }

                return AddFile(provider);
            });
        }


        private static AzureStorage AddAzure(IServiceProvider provider)
        {
            var configuration = provider.GetService<IConfiguration>();
            var connectionString = configuration.GetSection("Storage").GetSection("AzureString").Value;

            var account = CloudStorageAccount.Parse(connectionString);

            var cloudBlobClient = account.CreateCloudBlobClient();

            return new AzureStorage(cloudBlobClient);
        }

        private static StorageFile AddFile(IServiceProvider provider)
        {
            var host = provider.GetService<IHostingEnvironment>();
            var configuration = provider.GetService<IConfiguration>();


            var url = configuration.GetSection("Storage").GetSection("AppUrl").Value;

            return new StorageFile("storage", host.WebRootPath, url);
        }
    }
}

