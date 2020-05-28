using CityOfInfo.Data.Mids;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CityOfInfo.MidsExporter.Exporters
{
    public class YamlExporter : IExporter
    {        
        private bool disposedValue;

        private EnhancementDatabaseReader _enhancementDatabaseReader;
        private DatabaseReader _databaseReader;
        private string _outputPath;

        public YamlExporter(string outputPath)
        {
            _outputPath = outputPath;
        }

        public void Register(EnhancementDatabaseReader enhancementDatabaseReader)
        {
            _enhancementDatabaseReader = enhancementDatabaseReader;            

            var enhancementFolder = Path.Combine(_outputPath, "enhancements");
            var enhancementSetFolder = Path.Combine(_outputPath, "enhancement_sets");

            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitDefaults | DefaultValuesHandling.OmitNull)
                .Build();

            _enhancementDatabaseReader.OnHeaderRead += (header) =>
            {
                if (!Directory.Exists(enhancementFolder))
                    Directory.CreateDirectory(enhancementFolder);

                if (!Directory.Exists(enhancementSetFolder))
                    Directory.CreateDirectory(enhancementSetFolder);
            };

            _enhancementDatabaseReader.OnEnhancementSetRead += (enhancementSet) =>
            {
                var enhancementSetPath = Path.Combine(enhancementSetFolder, enhancementSet.StringId) + ".yml";
                if (File.Exists(enhancementSetPath))
                    File.Delete(enhancementSetPath);
                using (var file = File.Create(enhancementSetPath))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, enhancementSet);
                    }
                }
            };
            _enhancementDatabaseReader.OnEnhancementRead += (enhancement) =>
            {
                var isAttuned = enhancement.UniqueIdentifier.Contains("attuned", StringComparison.CurrentCultureIgnoreCase);
                var isCrafted = enhancement.UniqueIdentifier.Contains("crafted", StringComparison.CurrentCultureIgnoreCase);
                var isSpecial = enhancement.TypeId == EnhancementType.SpecialOrigin.Id;
                var isNormal = !isAttuned && !isCrafted && !isSpecial;

                // TODO: Move this mapping to a data property
                var enhancementPath = enhancementFolder;
                var name = enhancement.UniqueIdentifier;
                if (isAttuned)
                {
                    enhancementPath = Path.Combine(enhancementPath, "attuned");
                    enhancementPath = Path.Combine(enhancementPath, enhancement.EnhancementSetName);
                    name = enhancement.EnhancementSetName + "_" + enhancement.ShortName.Replace("/", "_").Replace(" ", "_");
                }
                else if (isCrafted)
                {
                    // data/enhancements/attuned/aegis/aegis_resdam_endrdx.yml
                    // data/enhancements/attuned/aegis/aegis_psi_status.yml
                    enhancementPath = Path.Combine(enhancementPath, "crafted");
                    enhancementPath = Path.Combine(enhancementPath, enhancement.EnhancementSetName);
                    name = enhancement.EnhancementSetName + "_" + enhancement.ShortName.Replace("/", "_").Replace(" ", "_");
                }
                else if (isSpecial)
                {
                    enhancementPath = Path.Combine(enhancementPath, "special");
                }
                else if (isNormal)
                {
                    // data/enhancements/normal/defense.yml
                    // data/enhancements/normal/flight_speed.yml
                    enhancementPath = Path.Combine(enhancementPath, "normal");
                    name = enhancement.Name.Replace(" ", "_");
                }

                if (!Directory.Exists(enhancementPath))
                    Directory.CreateDirectory(enhancementPath);

                var fileName = name + ".yml";
                enhancementPath = Path.Combine(enhancementPath, fileName);

                if (File.Exists(enhancementPath))
                    File.Delete(enhancementPath);

                using (var file = File.Create(enhancementPath))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, enhancement);
                    }
                }
            };
        }

        public void Register(DatabaseReader databaseReader)
        {
            _databaseReader = databaseReader;            

            var archetypeFolder = Path.Combine(_outputPath, "archetypes");
            var powersetFolder = Path.Combine(_outputPath, "power_sets");
            var powersFolder = Path.Combine(_outputPath, "powers");
            var playableArchetypes = new Dictionary<string, Archetype>();

            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitDefaults | DefaultValuesHandling.OmitNull)
                .Build();
            _databaseReader.OnIssue12HeaderRead += (header) =>
            {
                // metadata contains database header information
                var metadataPath = Path.Combine(_outputPath, "metadata.yml");
                if (File.Exists(metadataPath))
                    File.Delete(metadataPath);

                using (var file = File.Create(metadataPath))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, header);
                    }
                }
            };

            _databaseReader.OnArchetypeHeaderRead += (header) =>
            {
                if (!Directory.Exists(archetypeFolder))
                    Directory.CreateDirectory(archetypeFolder);
            };

            _databaseReader.OnArchetypeRead += (archetype) =>
            {
                if (!archetype.Playable)
                    return;
                playableArchetypes.Add(archetype.ClassName, archetype);

                var fileName = archetype.ClassName.ToLower().Replace("class_", "") + ".yml";
                var filePath = Path.Combine(archetypeFolder, fileName);
                if (File.Exists(filePath))
                    File.Delete(filePath);
                using (var file = File.Create(filePath))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, archetype);
                    }
                }
            };

            _databaseReader.OnPowerSetHeaderRead += (header) =>
            {
                if (!Directory.Exists(powersetFolder))
                    Directory.CreateDirectory(powersetFolder);
            };

            _databaseReader.OnPowerSetRead += (powerset) =>
            {
                // special case tanker regeneration
                // TODO: move to a strategy
                if (powerset.ClassType == string.Empty)
                    foreach (var searchArchetype in playableArchetypes.Values)
                        if (searchArchetype.Column == powerset.Archetype)
                            powerset.ClassType = searchArchetype.ClassName;

                if (!playableArchetypes.TryGetValue(powerset.ClassType, out Archetype archetype))
                    return;

                var archetypeName = archetype.ClassName.ToLower().Replace("class_", "");
                var powersetArchetypeDirectory = Path.Combine(powersetFolder, archetypeName);
                if (!Directory.Exists(powersetArchetypeDirectory))
                    Directory.CreateDirectory(powersetArchetypeDirectory);
                var fileName = powerset.SetName.ToLower() + ".yml";
                var filePath = Path.Combine(powersetArchetypeDirectory, fileName);
                if (File.Exists(filePath))
                    File.Delete(filePath);

                using (var file = File.Create(filePath))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, powerset);
                    }
                }
            };

            _databaseReader.OnPowersHeaderRead += (header) =>
            {
                if (!Directory.Exists(powersFolder))
                    Directory.CreateDirectory(powersFolder);
            };

            _databaseReader.OnPowerRead += (power) =>
            {
                if (string.IsNullOrWhiteSpace(power.GroupName)
                || string.IsNullOrWhiteSpace(power.SetName)
                || string.IsNullOrWhiteSpace(power.Name))
                    return;

                var powerGroupsFolder = Path.Combine(powersFolder, power.GroupName);
                if (!Directory.Exists(powerGroupsFolder))
                    Directory.CreateDirectory(powerGroupsFolder);

                var powerPowerSetFolder = Path.Combine(powerGroupsFolder, power.SetName);
                if (!Directory.Exists(powerPowerSetFolder))
                    Directory.CreateDirectory(powerPowerSetFolder);

                var powerFile = Path.Combine(powerPowerSetFolder, power.Name) + ".yml";
                if (File.Exists(powerFile))
                    File.Delete(powerFile);

                using (var file = File.Create(powerFile))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, power);
                    }
                }
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
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
