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
            var path = @$"C:\Users\{username}\AppData\Roaming\Pine's Hero Designer\Data";

            var options = new ExportOptions
            {
                Issue12DatabasePath = path + @"\i12.mhd",
                OutputPath = Environment.CurrentDirectory + "/../../../../data/homecoming",
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

            databaseReader.OnPowersetHeaderRead += (header) => 
            {
                if (!Directory.Exists(powersetFolder))
                    Directory.CreateDirectory(powersetFolder);
            };

            databaseReader.OnPowersetRead += (powerset) =>
            {
                // special case tanker regeneration
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
        }
    }
}
