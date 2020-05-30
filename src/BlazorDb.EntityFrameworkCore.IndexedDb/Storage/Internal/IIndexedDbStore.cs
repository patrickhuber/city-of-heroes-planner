using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDb.EntityFrameworkCore.IndexedDb.Storage.Internal
{
    public interface IIndexedDbStore
    {
        bool Clear();
        Task<bool> ClearAsync();
        void Add(IUpdateEntry entry);
        Task AddAsync(IUpdateEntry entry);
        void Update(IUpdateEntry entry);
        Task UpdateAsync(IUpdateEntry entry);

    }
}
