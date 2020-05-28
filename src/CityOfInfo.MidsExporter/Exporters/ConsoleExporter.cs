using CityOfInfo.Data.Mids;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.MidsExporter.Exporters
{
    public class ConsoleExporter : IExporter
    {
        public void Register(DatabaseReader databaseReader)
        {
            databaseReader.OnIssue12HeaderRead += (header) =>
            {
                Console.WriteLine($"Database (Version: {header.Version}, Issue: {header.Issue})");
            };
            databaseReader.OnArchetypeHeaderRead += (header) =>
            {
                Console.WriteLine($"Archetypes (Count: {header.Count})");
            };
            databaseReader.OnArchetypeRead += (archetype) =>
            {
                if (archetype.Playable)
                    Console.WriteLine($"Name: {archetype.DisplayName}");
            };
            databaseReader.OnPowerSetHeaderRead += (header) =>
            {
                Console.WriteLine($"PowerSets (Count: {header.Count})");
            };
            databaseReader.OnPowerSetRead += (powerSet) =>
            {
                Console.WriteLine($"Name: {powerSet.FullName}");
            };
            databaseReader.OnPowersHeaderRead += (header) =>
            {
                Console.WriteLine($"Powers (Count: {header.Count}");
            };
            databaseReader.OnPowerRead += (power) =>
            {
                Console.WriteLine($"Name: {power.FullName}");
            };
        }

        public void Register(EnhancementDatabaseReader enhancementDatabaseReader)
        {
            enhancementDatabaseReader.OnHeaderRead += (header) =>
            {
                Console.WriteLine($"Enhancement Database Version: {header.Version}");
            };
            enhancementDatabaseReader.OnEnhancementRead += (enhancement) =>
            {
                Console.WriteLine($"Enhancement: {enhancement.Name}");
            };
            enhancementDatabaseReader.OnEnhancementSetRead += (enhancementSet) =>
            {
                Console.WriteLine($"Enhancement Set: {enhancementSet.DisplayName}");
            };
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
