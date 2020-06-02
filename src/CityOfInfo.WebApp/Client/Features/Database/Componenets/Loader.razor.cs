using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Features.Database.Componenets
{
    public partial class Loader
    {
        protected override Task OnInitializedAsync()
        {

            // Get the first page of data from the server
            // Check if any of the Ids are in the local store
            // For ids not in the local store, request the full data from the server
            // Save the updated entity in the local store
            return base.OnInitializedAsync();
        }
    }
}
