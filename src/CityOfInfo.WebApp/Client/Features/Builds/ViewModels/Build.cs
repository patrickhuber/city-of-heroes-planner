using System.Collections.Generic;

namespace CityOfInfo.WebApp.Client.Features.Builds.ViewModels
{
    public class Build
    {
        public List<List<PowerSlot>> SelectedPowerColumns { get; set; }
        public List<List<PowerSlot>> InherentPowerColumns { get; set; }
    }
}
