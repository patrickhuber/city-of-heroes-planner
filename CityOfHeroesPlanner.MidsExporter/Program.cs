using CityOfHeroesPlanner.Data.Mids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CityOfHeroesPlanner.MidsExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = Environment.UserName;
            // hard coding for now, obviously this will need to be accepted as a parameter
            var path = @$"C:\Users\{username}\AppData\Roaming\Pine's Hero Designer\Data";

            var options = new ExportOptions
            {
                Issue12DatabasePath = Path.Combine(path, "i12.mhd"),
                // needs to be dynamic
                OutputPath = Environment.CurrentDirectory + "\\..\\..\\..\\..\\data\\homecoming",
            };
            Export(options);
        }

        private static void Export(ExportOptions options)
        {   
            using (var file = File.OpenRead(options.Issue12DatabasePath))
            {
                using (var binaryReader = new BinaryReader(file, Encoding.Default, true))
                {
                    var databaseReader = new DatabaseReader(binaryReader);
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
                    switch (options.Format)
                    {
                        case ExportFormat.Yaml:                            
                            ExportYaml(databaseReader, options.OutputPath);
                            break;
                    }

                    while (databaseReader.Read())
                    {
                    }
                }
            }            
        }

        public static void ExportYaml(DatabaseReader databaseReader, string outputPath)
        {
            var archetypeFolder = Path.Combine(outputPath, "archetypes");
            var powersetFolder = Path.Combine(outputPath, "powersets");
            var powersFolder = Path.Combine(outputPath, "powers");
            var playableArchetypes = new Dictionary<string, Archetype>();

            var serializer = new SerializerBuilder()
                .WithNamingConvention(new UnderscoredNamingConvention())
                .Build();

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
    }
}
