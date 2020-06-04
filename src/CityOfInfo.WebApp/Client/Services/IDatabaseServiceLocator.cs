using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Services
{
    public interface IDatabaseServiceLocator
    {
        string Find(WebApp.Shared.Database database);
    }
}
