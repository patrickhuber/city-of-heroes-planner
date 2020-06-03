using Simple.OData.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Model
{
    public interface IPageResult<T> : IEnumerable<T>
    { 
        ODataFeedAnnotations Annotations { get; }        
    }

    public interface IPageable<T>
    {
        Task<IPageResult<T>> FindEntriesAsync();
    }
}
