using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDb.EntityFrameworkCore.IndexedDb.Storage.Internal
{
    public interface IIndexedDbDatabase : IDatabase
    {
        IIndexedDbStore Store { get; }


        bool EnsureDatabaseCreated();
    }
}
