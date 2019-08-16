using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NonFactors.Mvc.Grid;
using VouDeVan.App.Web.AdminPainel.Filters;
using VouDeVan.App.Web.AdminPainel.Support.Storage;
using VouDeVan.Core.Business;
using NToastNotify;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Dynamic;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace VouDeVan.App.Web.AdminPainel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase(Configuration.GetConnectionString("DefaultConnection"));

            services.AddTransient<IStorage>(provider =>
            {
                var rootPath = provider.GetService<IHostingEnvironment>().WebRootPath;

                rootPath = Path.Combine(rootPath, "storage");

                return new StorageFile(rootPath);
            });

            services.AddTransient(typeof(IToastNotification), typeof(ToastrNotification));

            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions(){
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight
            });



            services.AddMvc();

            services.AddMvcGrid(filters =>
            {
                filters.BooleanTrueOptionText = () => "True";
                filters.BooleanFalseOptionText = () => "False";
                filters.Register(typeof(int), "contains", typeof(NumberContainsFilter));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // O middleware de localização precisa ser configurado antes de qualquer middleware 
            var supportedCultures = new[]
            {
                new CultureInfo("en-US")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });


            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

                app.UseExceptionHandler((error) =>
                {
                    error.Run(async context => {
 
                        context.Response.StatusCode = context.Response.StatusCode;
                        context.Response.ContentType = "application/json";
 
                        string errorMessage = context.Features.Get<IExceptionHandlerPathFeature>().Error.GetBaseException().Message;

                        dynamic errorComponent = new ExpandoObject();
                        errorComponent.ErrorCode = context.Response.StatusCode;
                        errorComponent.ErrorMessage = errorMessage;
                        
                        string responseMessage = JsonConvert.SerializeObject(errorMessage);
                       
                        //toastNotification.AddErrorToastMessage(responseMessage, new ToastrOptions() { Title = "Erro" });

                        await context.Response.WriteAsync(responseMessage);
                    });
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseNToastNotify();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}