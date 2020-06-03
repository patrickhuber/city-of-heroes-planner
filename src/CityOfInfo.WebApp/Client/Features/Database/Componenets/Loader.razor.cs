using CityOfInfo.Domain;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Features.Database.Componenets
{
    public partial class Loader
    {
        public int PercentageLoaded { get; set; }
        public int NumberLoaded { get; set; }
        public int TotalCount { get; set; }

        protected async override Task OnInitializedAsync()
        {            
            var annotations = new ODataFeedAnnotations();
            var client = new ODataClient("https://cityof.info/odata");

            var pageSize = 10;
            var pageIndex = 1;

            do
            {
                var powers = await client
                    .For<Power>("Powers")
                    .Top(pageSize)
                    .Skip((pageIndex - 1) * pageSize)
                    .FindEntriesAsync(annotations);

                TotalCount = (int)(annotations.Count ?? 0);

                NumberLoaded += powers.Count();
                PercentageLoaded = (int)(100d * ((double)NumberLoaded / TotalCount));
                StateHasChanged();
            } while (NumberLoaded < TotalCount);
        }
    }
}
