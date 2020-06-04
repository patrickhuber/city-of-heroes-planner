using CityOfInfo.WebApp.Client.Models;
using CityOfInfo.WebApp.Client.Services;
using CityOfInfo.WebApp.Shared;
using Microsoft.AspNetCore.Components;
using Simple.OData.Client;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Features.Databases.Components
{
    public partial class Loader
    {
        public int PercentageLoaded { get; set; }
        public int NumberLoaded { get; set; }
        public int TotalCount { get; set; }

        public bool IsWorking { get; set; }

        [Inject]
        public IDomainContextFactory DomainContextFactory { get; set; }

        [Inject]
        public IDatabaseQueueService DatabaseQueueService { get; set; }

        [Inject]
        public IDatabaseServiceLocator DatabaseServiceLocator { get; set; }

        protected override void OnInitialized()        
        {
            DatabaseQueueService.OnEnqueue += OnEnqueueAsync;
            IsWorking = false;
        }

        public void Dispose()
        {
            DatabaseQueueService.OnEnqueue -= OnEnqueueAsync;
        }

        private async Task OnEnqueueAsync()
        {
            if (IsWorking)
                return;

            while (DatabaseQueueService.Count > 0)
            {
                NumberLoaded = 0;
                PercentageLoaded = 0;
                TotalCount = 1;

                var database = DatabaseQueueService.Dequeue();
                await ProcessDatabaseAsync(database);
            }

            IsWorking = false;
        }

        private async Task ProcessDatabaseAsync(Database database)
        {
            var pageSize = 100;
            var pageIndex = 1;

            var serviceUri = DatabaseServiceLocator.Find(database);
            var domainContext = DomainContextFactory.Create(serviceUri);

            do
            {
                await ProcessPowerPageAsync(domainContext, pageSize, pageIndex);

                // update ui state
                StateHasChanged();

                pageIndex++;
            } while (NumberLoaded < TotalCount);
        }

        private async Task ProcessPowerPageAsync(DomainContext domainContext, int pageSize, int pageIndex)
        {
            if (pageIndex < 1)
                pageIndex = 1;

            var annotations = new ODataFeedAnnotations();
            var powers = await domainContext
                    .Powers
                    .Top(pageSize)
                    .Skip((pageIndex - 1) * pageSize)
                    .Select(x => x.Id)
                    .FindEntriesAsync(annotations);

            var count = powers.Count();
            if (count == 0)
                return;

            // upate counters
            TotalCount = (int)(annotations.Count ?? 0);
            NumberLoaded += count;
            PercentageLoaded = (int)(100d * ((double)NumberLoaded / (double)TotalCount));
        }

        [Parameter] 
        public RenderFragment ChildContent { get; set; }
    }
}
