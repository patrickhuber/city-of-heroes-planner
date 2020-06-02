using CityOfInfo.Domain.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System;
using CityOfInfo.Domain.EntityFramework.Sqlite;

namespace CityOfInfo.WebApp.Server
{
    /// <summary>
    /// An extension dedicated to loading the database into memory. 
    /// </summary>
    public static class DatabaseExtensions
    {
        public static async Task PopulateDomainContextAsync(this IApplicationBuilder app)
        {   
            var client = CreateBlobClient(app);
            var response = await GetDatabaseBlobAsync(client);

            var filePath = Path.GetTempFileName();
            await WriteToFileAsync(response, filePath);

            using var sqlLiteContext = new SqliteDomainContext(filePath);

            // do not dispose of this or you will break the odata enpoint
            var context = app.ApplicationServices.GetService<DomainContext>();
            context.Database.EnsureCreated();

            CopyPowers(sqlLiteContext, context);
            context.SaveChanges();
        }

        private static async Task WriteToFileAsync(HttpResponseMessage response, string filePath)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            var zipFile = new ZipArchive(stream);
            foreach (var entry in zipFile.Entries)
            {
                using var inputStream = entry.Open();
                using var outputStream = new FileStream(filePath, FileMode.OpenOrCreate);
                await inputStream.CopyToAsync(outputStream);
            }
        }

        private static void CopyPowers(DomainContext sqlLiteContext, DomainContext context)
        {
            foreach (var power in sqlLiteContext.Powers)
                context.Powers.Add(power);
        }

        private static Task<HttpResponseMessage> GetDatabaseBlobAsync(HttpClient client)
        {
            var url = "https://cityofheroes.blob.core.windows.net/databases/homecoming-19-1021004.zip";            
            var response = client.GetAsync(url);
            return response;
        }

        private static HttpClient CreateBlobClient(IApplicationBuilder app)
        {
            var httpClientFactory = app.ApplicationServices.GetService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient(Shared.Globals.DatabaseBlobClient);
            return client;
        }
    }
}
