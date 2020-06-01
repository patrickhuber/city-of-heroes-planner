using CityOfInfo.Domain.EntityFramework;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using CityOfInfo.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CityOfInfo.WebApp.Server
{
    public static class AppExtensions
    {
        public static void PopulateDomainContext(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<DomainContext>();
            var powers = new string[]
            {
                "Single_Shot",
                "Pummel",
                "Burst",
                "WS_Wide_Area_Web_Grenade",
                "Heavy_Burst",
            }.Select((x, i) => new Power { Id = i, Name = x });
            foreach (var power in powers)
                context.Add(power);
            context.SaveChanges();
        }
    }
}
