
using Microsoft.AspNetCore.Components;

namespace CityOfInfo.WebApp.Client.Features.Builds.Components
{
    public partial class PowerSlot
    {
        [Parameter]
        public CityOfInfo.Data.Mids.PowerSlot Item { get; set; }

        private string GetPowerName(CityOfInfo.Data.Mids.PowerSlot power)
        {
            if (power == null)
                return "( )";

            var name = new System.Text.StringBuilder();
            name.AppendFormat("({0}) ", power.Level + 1);

            if (power.Power is null)
                return name.ToString();

            if (string.IsNullOrWhiteSpace(power.Power.Display))
                name.Append(power.Power.Index);
            else
                name.Append(power.Power.Display);

            return name.ToString();
        }
    }
}
