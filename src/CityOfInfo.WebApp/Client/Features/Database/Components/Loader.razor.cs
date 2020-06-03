using CityOfInfo.Domain;
using CityOfInfo.WebApp.Client.Model;
using Microsoft.AspNetCore.Components;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Features.Database.Components
{
    public partial class Loader
    {
        public int PercentageLoaded { get; set; }
        public int NumberLoaded { get; set; }
        public int TotalCount { get; set; }

        [Inject]
        private IDomainContext DomainContext { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var annotations = new ODataFeedAnnotations();

            var pageSize = 10;
            var pageIndex = 1;
            
            NumberLoaded = 0;
            PercentageLoaded = 0;
            TotalCount = 0;

            var client = new ODataClient("https://cityof.info/odata/");

            do
            {
                Console.WriteLine($"NumberLoaded: {NumberLoaded}, PercentageLoaded: {PercentageLoaded}, TotalCount: {TotalCount}, pageIndex: {pageIndex}, pageSize: {pageSize}");
                var powers = await client
                    .For<Power>("Powers")
                    .Top(pageSize)
                    .Skip((pageIndex - 1) * pageSize)
                    .FindEntriesAsync();

                TotalCount = (int)(annotations.Count ?? 0);

                var count = powers.Count();
                for (var i = 0; i < count; i++)
                {
                    NumberLoaded++;
                    PercentageLoaded = (int)(100d * ((double)NumberLoaded / TotalCount));
                    StateHasChanged();
                }                                
                pageIndex++;
            } while (NumberLoaded < TotalCount);
        }
    }
}
