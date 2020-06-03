using CityOfInfo.Data.Mids;
using Simple.OData.Client;

namespace CityOfInfo.WebApp.Client.Model
{
    public interface IDomainContext
    {
        IBoundClient<Enhancement> Enhancements { get; }
        IBoundClient<Power> Powers { get; }
    }
}