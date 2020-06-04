using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Models
{
    public class DomainContextFactory : IDomainContextFactory
    {
        public DomainContext Create(string url)
        {
            return new DomainContext(url);
        }
    }
}
