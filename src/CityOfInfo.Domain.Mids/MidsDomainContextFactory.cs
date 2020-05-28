using CityOfInfo.Data.Mids;
using CityOfInfo.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CityOfInfo.Domain.Mids
{
    public class MidsDomainContextFactory : IDomainContextFactory
    {
        private IDomainContextLoader _loader;

        /// <summary>
        /// Creates an instance of the context provider from the given readers
        /// </summary>
        /// <remarks>may want to encapsulate this usage because reader is stateful and Create modifies that state.</remarks>
        /// <param name="databaseReader">the database reader to use.</param>
        public MidsDomainContextFactory(DatabaseReader databaseReader, EnhancementDatabaseReader enhancementDatabaseReader)
        {
            _loader = new MidsDomainContextLoader(databaseReader, enhancementDatabaseReader);            
        }

        /// <summary>
        /// Creates the context factor with the context loader
        /// </summary>
        /// <param name="loader"></param>
        public MidsDomainContextFactory(IDomainContextLoader loader)
        {
            _loader = loader;
        }

        public DomainContext Create()
        {
            var options = new DbContextOptionsBuilder<DomainContext>()       
                .UseInMemoryDatabase(databaseName: "Domain")
                .Options;

            var context = new DomainContext(options);
            _loader.Load(context);
            return context;
        }
    }
}
