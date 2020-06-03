using CityOfInfo.Data.Mids;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Model
{
    public class DomainContext : IDomainContext
    {
        private ODataClient _client;

        public DomainContext(string uri)
        {
            Console.WriteLine("Odata URL: " + uri);
            _client = new ODataClient(uri);
        }

        public IBoundClient<Power> Powers => _client.For<Power>("Powers");
        public IBoundClient<Enhancement> Enhancements => _client.For<Enhancement>("Enhancements");
    }
}
