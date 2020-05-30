using BlazorDb.EntityFrameworkCore.IndexedDb.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IndexedDbServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkIndexedDbDatabase(this IServiceCollection serviceCollection)
        {
            var builder = new EntityFrameworkServicesBuilder(serviceCollection)
                .TryAdd<IDatabase>(p => p.GetService<IIndexedDbDatabase>())
                .TryAdd<IDatabaseCreator, IndexedDbDatabaseCreator>()

                .TryAddProviderSpecificServices(b => b
                    .TryAddScoped<IIndexedDbStore, IndexedDbStore>()
                    .TryAddScoped<IIndexedDbDatabase, IndexedDbDatabase>());

            builder.TryAddCoreServices();

            return serviceCollection;
        }
    }
}
