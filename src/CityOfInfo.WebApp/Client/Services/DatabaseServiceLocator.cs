using CityOfInfo.WebApp.Shared;

namespace CityOfInfo.WebApp.Client.Services
{
    public class DatabaseServiceLocator : IDatabaseServiceLocator
    {
        private readonly string _baseAddress;

        public DatabaseServiceLocator(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public string Find(Database database)
        {
            var suffix = _baseAddress.EndsWith('/') ? string.Empty : "/";
            suffix += "odata/";
            return _baseAddress + suffix;
        }
    }
}
