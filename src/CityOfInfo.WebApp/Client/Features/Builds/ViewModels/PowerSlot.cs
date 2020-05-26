using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Features.Builds.ViewModels
{
    public class PowerSlot
    {
        public string Name { get; internal set; }
        public bool PowerIsSelected { get; internal set; }
        public bool ShowPowerName { get; internal set; }
        public bool ShowPowerLevel { get; internal set; }
    }
}
