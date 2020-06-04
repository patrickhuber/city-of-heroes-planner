using CityOfInfo.WebApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Features.Databases.Components
{
    public partial class Browse
    {
        public List<Database> Databases { get; set; }        

        protected override async Task OnInitializedAsync()
        {
            Databases = new List<Database>
            {
                new Database
                {
                    Id = 0,
                    Name = "Homecoming",
                    SemanticVersion = new Domain.SemanticVersion(1, 0, 0)
                }
            };
            await Task.FromResult(1);
        }
    }
}
