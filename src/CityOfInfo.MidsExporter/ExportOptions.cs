using CommandLine;

namespace CityOfInfo.MidsExporter
{
    [Verb("export",  HelpText="Exports the mids database")]
    public class ExportOptions
    {
        [Option('d', "database", Required = true)]
        public string DatabasePath { get; set; }

        public string Issue12DatabasePath { get; set; }
                
        public string EnhancementSetPath { get; set; }

        [Option('o', "output", Required = true)]
        public string OutputPath { get; set; }

        [Option('f', "format", Required = false, Default = ExportFormat.Yaml, ResourceType =typeof(ExportFormat))]
        public ExportFormat Format {get;set;}

        [Option('s', "silent", Required =false, Default = false, HelpText = "Suppresses output to screen.")]
        public bool Silent { get; set; }
        
    }
}