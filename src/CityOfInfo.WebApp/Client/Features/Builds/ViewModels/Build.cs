using System.Collections.Generic;

namespace CityOfInfo.WebApp.Client.Features.Builds.ViewModels
{
    public class Build
    {
        public List<PowerSlot> SelectedPowers { get; set; }
        public List<PowerSlot> InherentPowers { get; set; }
    }
}
