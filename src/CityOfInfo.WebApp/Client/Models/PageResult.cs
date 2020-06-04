using Simple.OData.Client;
using System.Collections;
using System.Collections.Generic;

namespace CityOfInfo.WebApp.Client.Models
{
    public class PageResult<T> : IPageResult<T>
    {
        public ODataFeedAnnotations Annotations { get; private set; }
        private IEnumerable<T> _results;

        public PageResult(IEnumerable<T> results, ODataFeedAnnotations annotations)
        {
            Annotations = annotations;
            _results = results;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
}
