using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Update;
using System.Linq;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;

namespace BlazorDb.EntityFrameworkCore.IndexedDb.Storage.Internal
{
    public class IndexedDbStore : IIndexedDbStore
    {
        private readonly IndexedDBManager _manager;

        public IndexedDbStore(IndexedDBManager manager)
        {
            _manager = manager;
        }

        public async Task AddAsync(IUpdateEntry entry)
        {            
            var storeRecord = ConvertToObjectRecord(entry);
            await _manager.AddRecord(storeRecord);            
        }

        public void Add(IUpdateEntry entry)
        {
            var task = AddAsync(entry);
            task.Wait();
        }

        private StoreRecord<object> ConvertToObjectRecord(IUpdateEntry entry)
        {
            var entityType = entry.EntityType;            
            var name = entityType.DisplayName();

            var row = entityType.GetProperties()
                .Select(x => SnapshotValue(x, x.GetKeyValueComparer(), entry))
                .ToArray();

            return new StoreRecord<object>()
            { 
                Storename = name,
                Data = row,
            };
        }

        private static object SnapshotValue(IProperty property, ValueComparer comparer, IUpdateEntry entry)
        {
            var value = SnapshotValue(comparer, entry.GetCurrentValue(property));

            var converter = property.GetValueConverter()
                ?? property.FindTypeMapping()?.Converter;
                        
            if (converter != null)
            {
                value = converter.ConvertToProvider(value);
            }

            return value;
        }

        private static object SnapshotValue(ValueComparer comparer, object value)
            => comparer == null ? value : comparer.Snapshot(value);

        public void Update(IUpdateEntry entry)
        {
            var task = UpdateAsync(entry);
            task.Wait();            
        }

        public async Task UpdateAsync(IUpdateEntry entry)
        {
            var storeRecord = ConvertToObjectRecord(entry);
            await _manager.UpdateRecord(storeRecord);
        }

        public void Delete(IUpdateEntry entry)
        {
            var task = DeleteAsync(entry);
            task.Wait();
        }

        public async Task DeleteAsync(IUpdateEntry entry)
        {
            var entityType = entry.EntityType;
            var key = entityType.FindPrimaryKey();
            var name = entityType.DisplayName();
            var data = entry.GetCurrentValue(key.Properties.First());
            await _manager.DeleteRecord<object>(name, data);            
        }

        public bool Clear()
        {
            var task = ClearAsync();
            task.Wait();
            return task.Result;
        }

        public async Task<bool> ClearAsync()
        {
            foreach (var store in _manager.Stores)
                await _manager.ClearStore(store.Name);
            return true;
        }

    }
}
