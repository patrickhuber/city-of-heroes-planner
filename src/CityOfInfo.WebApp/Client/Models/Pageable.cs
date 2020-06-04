using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Models
{
    public class Pageable<T> : IPageable<T>
        where T : class
    {
        private IBoundClient<T> _client;

        public Pageable(IBoundClient<T> client)
        {
            _client = client;
        }

        public async Task<IPageResult<T>> FindEntriesAsync()
        {
            var annotations = new ODataFeedAnnotations();
            var results = await _client.FindEntriesAsync(annotations);
            return new PageResult<T>(results, annotations);
        }
    }

}
