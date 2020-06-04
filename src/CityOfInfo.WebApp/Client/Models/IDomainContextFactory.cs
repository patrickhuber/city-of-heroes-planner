namespace CityOfInfo.WebApp.Client.Models
{
    public interface IDomainContextFactory
    {
        DomainContext Create(string url);
    }
}