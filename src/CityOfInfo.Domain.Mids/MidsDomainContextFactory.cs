using CityOfInfo.Data.Mids;
using CityOfInfo.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CityOfInfo.Domain.Mids
{
    public class MidsDomainContextProvider : IDomainContextFactory
    {
        private readonly DatabaseReader _reader;        

        /// <summary>
        /// Creates an instance of the context provider from the given reader
        /// </summary>
        /// <remarks>may want to encapsulate this usage because reader is stateful and Create modifies that state.</remarks>
        /// <param name="reader">the database reader to use.</param>
        public MidsDomainContextProvider(DatabaseReader reader)
        {
            _reader = reader;            
        }

        public DomainContext Create()
        {
            var options = new DbContextOptionsBuilder<DomainContext>()       
                .UseInMemoryDatabase(databaseName: "Domain")
                .Options;

            var context = new DomainContext(options);

            _reader.OnArchetypeRead += (archetype) => 
            {
                var domainArchetype = new Archetype
                {
                    Name = archetype.ClassName,
                };
                context.Archetypes.Add(domainArchetype);
            };
            _reader.OnPowerSetRead += (powerset) => 
            {

            };
            _reader.OnPowerRead += (power) => 
            {

            };

            while (_reader.Read());

            context.SaveChanges();

            return context;
        }
    }
}
