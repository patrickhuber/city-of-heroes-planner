using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Models
{
    public static class ODataClientExtensions
    {
        public static IPageable<T> WithPagination<T>(this IBoundClient<T> client, int pageSize, int pageIndex)
            where T : class
        {
            return new Pageable<T>(client.Top(pageSize).Skip((pageIndex - 1) * pageSize));
        }
    }
}
