using CityOfInfo.Data.Mids.Builds;

namespace CityOfInfo.WebApp.Client.Features.Builds.ViewModels
{
    public class Character
    {
        public Build Build { get; set; }
        public string Name { get; internal set; }
        public string AlignmentName { get; internal set; }
        public string ArchetypeName { get; internal set; }
        public string Origin { get; internal set; }
    }
}