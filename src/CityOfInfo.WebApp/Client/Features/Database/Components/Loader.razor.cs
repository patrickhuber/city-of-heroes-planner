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
            var pageSize = 100;
            var pageIndex = 1;
            
            NumberLoaded = 0;
            PercentageLoaded = 0;
            TotalCount = 1;

            var annotations = new ODataFeedAnnotations();
            do
            {
                var powers = await DomainContext
                    .Powers
                    .Top(pageSize)
                    .Skip((pageIndex - 1) * pageSize)
                    .Select(x=>x.Id)
                    .FindEntriesAsync(annotations);
                                
                var count = powers.Count();
                if (count == 0)
                    break;

                TotalCount = (int)(annotations.Count ?? 0);

                for (var i = 0; i < count; i++)
                {
                    NumberLoaded++;
                    PercentageLoaded = (int)(100d * ((double)NumberLoaded / (double)TotalCount));
                    StateHasChanged();
                }                                
                pageIndex++;
            } while (NumberLoaded < TotalCount);
        }
    }
}
