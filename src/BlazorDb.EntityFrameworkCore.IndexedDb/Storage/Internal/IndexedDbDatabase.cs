using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDb.EntityFrameworkCore.IndexedDb.Storage.Internal
{
    public class IndexedDbDatabase : Database, IIndexedDbDatabase
    {
        public IndexedDbDatabase(DatabaseDependencies dependencies) 
            : base(dependencies)
        {
        }

        public IIndexedDbStore Store => throw new NotImplementedException();

        public bool EnsureDatabaseCreated()
        {
            throw new NotImplementedException();
        }

        public override int SaveChanges(IList<IUpdateEntry> entries)
        {
            var task = SaveChangesAsync(entries);
            task.Wait();
            return task.Result;
        }

        public override async Task<int> SaveChangesAsync(IList<IUpdateEntry> entries, CancellationToken cancellationToken = default)
        {
            var recordCount = 0;

            foreach (var entry in entries)
            {
                switch (entry.EntityState)
                {
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                        continue;
                    case EntityState.Added:
                        await Store.AddAsync(entry);
                        break;
                }
            }
            return recordCount;
        }
    }
}
