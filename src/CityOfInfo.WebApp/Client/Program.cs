using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using TG.Blazor.IndexedDB;
using System.Collections.Generic;

namespace CityOfInfo.WebApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons()                
                .AddIndexedDB(dbStore =>
                {
                    dbStore.DbName = "Database"; //example name
                    dbStore.Version = 1;

                    dbStore.Stores.Add(new StoreSchema
                    {
                        Name = "Powers",
                        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = false },
                        Indexes = new List<IndexSpec>
                        {
                            new IndexSpec{Name="name", KeyPath = "name", Auto=false}
                        }
                    });
                })
                .AddHttpClient(WebApp.Shared.Globals.DatabaseBlobClient, client =>
                    client.BaseAddress = WebApp.Shared.Globals.DatabaseBlobBaseAddress);

            var host = builder.Build();

            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
