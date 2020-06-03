using CityOfInfo.Domain;
using CityOfInfo.Domain.EntityFramework;
using CityOfInfo.WebApp.Client;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddDbContext<DomainContext>(
                options=> 
            {
                options.UseInMemoryDatabase("database");
            }, 
            ServiceLifetime.Singleton);

            services.AddControllersWithViews();
            services.AddOData();
            services.AddRazorPages();

            services.AddHttpClient(Shared.Globals.DatabaseBlobClient, client =>
                    client.BaseAddress = Shared.Globals.DatabaseBlobBaseAddress);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
                endpoints.MapODataRoute("odata", "odata", GetEdmModel());

                endpoints.MapFallback("odata/{**slug}", HandleOdataFallbackAsync);
                endpoints.MapFallbackToFile("{**slug}", "index.html");
            });

            var task = app.PopulateDomainContextAsync();
            
            task.Wait();
        }

        private Task HandleOdataFallbackAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return Task.FromResult(0);
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Power>("Powers");
            return builder.GetEdmModel();
        }
    }
}
