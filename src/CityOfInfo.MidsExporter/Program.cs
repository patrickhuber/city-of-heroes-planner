using CityOfInfo.Data.Mids;
using CityOfInfo.MidsExporter.Exporters;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.MidsExporter
{
    class Program
    {
        private static readonly int Success = 0;
        private static readonly int Failure = -1;

        static int Main(string[] args)
        {
            var returnCode = Success;
            var parser = new Parser(options => options.CaseInsensitiveEnumValues = true);
            var result = parser.ParseArguments<ExportOptions>(args)
                .WithParsed(o =>
                {
                    o.Issue12DatabasePath = Path.Combine(o.DatabasePath, "i12.mhd");
                    o.EnhancementSetPath = Path.Combine(o.DatabasePath, "EnhDB.mhd");
                    Export(o);
                })
                .WithNotParsed(errors => 
                {
                    returnCode = Failure;
                    foreach (var error in errors)                    
                        Console.Error.WriteLine(error.ToString());                    
                });

            return returnCode;
        }

        private static void Export(ExportOptions options)
        {
            var exporters = CreateExporters(options);
            ExportIssue12Database(options, exporters);
            ExportEnhancementDatabase(options, exporters);
        }

        private static List<IExporter> CreateExporters(ExportOptions options)
        {
            var exporters = new List<IExporter>();
            switch (options.Format)
            {
                case ExportFormat.Sqlite:
                    exporters.Add(new SqliteExporter(options.OutputPath));
                    break;
                case ExportFormat.Yaml:
                    exporters.Add(new YamlExporter(options.OutputPath));
                    break;
            }

            if (!options.Silent)
                exporters.Add(new ConsoleExporter());

            return exporters;
        }

        private static void ExportEnhancementDatabase(ExportOptions options, IList<IExporter> exporters)
        {
            using (var file = File.OpenRead(options.EnhancementSetPath))
            {
                using (var binaryReader = new BinaryReader(file, Encoding.Default, true))
                {
                    var enhancementDatabaseReader = new EnhancementDatabaseReader(binaryReader);
                    foreach (var exporter in exporters)
                        exporter.Register(enhancementDatabaseReader);
                    while (enhancementDatabaseReader.Read()) ;
                }
            }
        }

        private static void ExportIssue12Database(ExportOptions options, IList<IExporter> exporters)
        {            
            using (var file = File.OpenRead(options.Issue12DatabasePath))
            {
                using (var binaryReader = new BinaryReader(file, Encoding.Default, true))
                {
                    var databaseReader = new DatabaseReader(binaryReader);
                    foreach (var exporter in exporters)
                        exporter.Register(databaseReader);
                    while (databaseReader.Read()) { }
                }
            }
        }
    }
}
