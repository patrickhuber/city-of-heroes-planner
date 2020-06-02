using CityOfInfo.Data.Mids;
using CityOfInfo.Domain.EntityFramework;
using CityOfInfo.Domain.EntityFramework.Sqlite;
using CityOfInfo.Domain.Mids;
using System;
using System.IO;

namespace CityOfInfo.MidsExporter.Exporters
{
    public class SqliteExporter : IExporter
    {
        private MidsDomainContextMapper _contextMapper;        
        private DomainContext _domainContext;
        private bool disposedValue;

        public SqliteExporter(string outputPath)
        {
            var path = Path.Combine(outputPath, "database.db");
            if (File.Exists(path))
                File.Delete(path);

            _domainContext = new SqliteDomainContext(path);
            _domainContext.Database.EnsureCreated();
            _domainContext.ChangeTracker.AutoDetectChangesEnabled = false;
            _contextMapper = new MidsDomainContextMapper(_domainContext);
        }

        public void Register(EnhancementDatabaseReader enhancementDatabaseReader)
        {
            _contextMapper.Register(enhancementDatabaseReader);
        }

        public void Register(DatabaseReader databaseReader)
        {
            _contextMapper.Register(databaseReader);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _domainContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
