using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDb.EntityFrameworkCore.IndexedDb.Storage.Internal
{
    public class IndexedDbDatabaseCreator : IDatabaseCreator
    {
        private IIndexedDbDatabase _database;

        protected virtual IIndexedDbDatabase Database { get; }

        public IndexedDbDatabaseCreator(IIndexedDbDatabase database)
        {
            Database = database;
        }

        public bool CanConnect()
        {
            // TODO: call into window.indexedDb
            return true;
        }

        public virtual Task<bool> CanConnectAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(true);

        public virtual bool EnsureCreated() => Database.EnsureDatabaseCreated();

        public virtual Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(Database.EnsureDatabaseCreated());

        public bool EnsureDeleted()
            => Database.Store.Clear();

        public Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(Database.EnsureDatabaseCreated());
    }
}
