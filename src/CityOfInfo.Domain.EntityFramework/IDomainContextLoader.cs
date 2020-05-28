using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Domain.EntityFramework
{
    public interface IDomainContextLoader
    {
        /// <summary>
        /// Loads the domain context with
        /// </summary>
        /// <param name="domainContext"></param>
        void Load(DomainContext domainContext);
    }
}
