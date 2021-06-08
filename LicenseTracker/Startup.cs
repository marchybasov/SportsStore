using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using LicenseTracker.Models;
using LicenseTracker.Models.DbContext;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LicenseTracker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LicenseUsageStatisticContext>(options => options.UseSqlServer(Configuration["Data:LicenseTrackerDb:ConnectionString"]));
            services.AddTransient<ISolidworksUsageRepository, EFSolidworksLicenseUsagesRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{LicenseUsagesPage:int}",
                    defaults: new { controller = "LicenseUsages", action = "List" });


                routes.MapRoute(
                    name: null,
                    template: "Page{LicenseUsagestPage:int}",
                    defaults: new { controller = "LicenseUsages", action = "List", LicenseUsagesPage = 1 });
                
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "LicenseUsages", action = "List", LicenseUsagesPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "LicenseUsages", action = "List", LicenseUsagesPage = 1 });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
                //routes.MapRoute(
                //    name: "pagination",
                //    template: "Products/Page{productPage}",
                //    defaults: new { Controller = "Product", action = "List" });
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Product}/{action=List}/{id?}");
            });
            
        }

    }
}
