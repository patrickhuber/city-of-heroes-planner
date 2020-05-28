using CityOfInfo.Data.Mids;
using System;

namespace CityOfInfo.MidsExporter.Exporters
{
    public interface IExporter : IDisposable
    {
        void Register(DatabaseReader databaseReader);
        void Register(EnhancementDatabaseReader enhancementDatabaseReader);
    }
}