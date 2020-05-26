using CityOfInfo.Data.Mids;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CityOfInfo.MidsExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ExportOptions>(args).WithParsed(o => 
            {
                o.Issue12DatabasePath = Path.Combine(o.DatabasePath, "i12.mhd");
                o.EnhancementSetPath = Path.Combine(o.DatabasePath, "EnhDB.mhd");
                Export(o);
            });
        }

        private static void Export(ExportOptions options)
        {
            ExportIssue12Database(options);
            ExportEnhancementDatabase(options);
        }

        private static void ExportEnhancementDatabase(ExportOptions options)
        {
            using (var file = File.OpenRead(options.EnhancementSetPath))
            {
                using (var binaryReader = new BinaryReader(file, Encoding.Default, true))
                {
                    var enhancementDatabaseReader = new EnhancementDatabaseReader(binaryReader);
                    if(!options.Silent)
                        RegisterConsoleEvents(enhancementDatabaseReader);
                    switch (options.Format)
                    {
                        case ExportFormat.Yaml:
                            RegisterYamlExport(enhancementDatabaseReader, options.OutputPath);                            
                            break;
                    }
                    while (enhancementDatabaseReader.Read()) ;
                }
            }
        }

        private static void ExportIssue12Database(ExportOptions options)
        {            
            using (var file = File.OpenRead(options.Issue12DatabasePath))
            {
                using (var binaryReader = new BinaryReader(file, Encoding.Default, true))
                {
                    var databaseReader = new DatabaseReader(binaryReader);
                    if (!options.Silent)
                        RegisterConsoleEvents(databaseReader);
                    switch (options.Format)
                    {
                        case ExportFormat.Yaml:
                            RegisterYamlExport(databaseReader, options.OutputPath);
                            break;
                    }
                    while (databaseReader.Read()) { }
                }
            }
        }

        private static void RegisterConsoleEvents(DatabaseReader databaseReader)
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

        public static void RegisterYamlExport(DatabaseReader databaseReader, string outputPath)
        {
            var archetypeFolder = Path.Combine(outputPath, "archetypes");
            var powersetFolder = Path.Combine(outputPath, "power_sets");
            var powersFolder = Path.Combine(outputPath, "powers");
            var playableArchetypes = new Dictionary<string, Archetype>();

            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            databaseReader.OnIssue12HeaderRead += (header) =>
            {
                // metadata contains database header information
                var metadataPath = Path.Combine(outputPath, "metadata.yml");
                if(File.Exists(metadataPath))
                    File.Delete(metadataPath);

                using (var file = File.Create(metadataPath))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, header);
                    }
                }
            };

            databaseReader.OnArchetypeHeaderRead += (header) => 
            {                
                if (!Directory.Exists(archetypeFolder))
                    Directory.CreateDirectory(archetypeFolder);
            };

            databaseReader.OnArchetypeRead += (archetype) =>
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

            databaseReader.OnPowerSetHeaderRead += (header) => 
            {
                if (!Directory.Exists(powersetFolder))
                    Directory.CreateDirectory(powersetFolder);
            };

            databaseReader.OnPowerSetRead += (powerset) =>
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

            databaseReader.OnPowersHeaderRead += (header) => 
            {
                if (!Directory.Exists(powersFolder))
                    Directory.CreateDirectory(powersFolder);
            };

            databaseReader.OnPowerRead += (power) => 
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
        
        private static void RegisterConsoleEvents(EnhancementDatabaseReader enhancementDatabaseReader)
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


        private static void RegisterYamlExport(EnhancementDatabaseReader enhancementDatabaseReader, string outputPath)
        {
            var enhancementFolder = Path.Combine(outputPath, "enhancements");
            var enhancementSetFolder = Path.Combine(outputPath, "enhancement_sets");

            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();

            enhancementDatabaseReader.OnHeaderRead += (header) =>
            {
                if (!Directory.Exists(enhancementFolder))
                    Directory.CreateDirectory(enhancementFolder);
                
                if (!Directory.Exists(enhancementSetFolder))
                    Directory.CreateDirectory(enhancementSetFolder);
            };

            enhancementDatabaseReader.OnEnhancementSetRead += (enhancementSet) =>
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
            enhancementDatabaseReader.OnEnhancementRead += (enhancement) =>
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
    }
}
